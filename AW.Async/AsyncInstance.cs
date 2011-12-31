﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AW.Async
{
    public static class AsyncInstance
    {
        private static readonly Dictionary<IInstance, Dictionary<Callbacks, Queue<CallbackWorkItem>>> CallbackWorkItemQueue = new Dictionary<IInstance, Dictionary<Callbacks, Queue<CallbackWorkItem>>>();

        /// <summary>
        /// Asynchronously retrieves the IP address for the given session.
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="session">The session to retrieve the IP address of.</param>
        /// <returns></returns>
        public static Task<Result> AddressAsync(this IInstance instance, int session)
        {
            return instance.CreateCallbackTask(Callbacks.Address,
                                               () => instance.Address(session),
                                               handler => instance.CallbackAddress += handler);
        }

        public static Task<Result> AvatarLocationAsync(this IInstance instance, int citizenNumber = 0, int session = 0, string name = "")
        {
            return instance.CreateCallbackTask(Callbacks.AvatarLocation,
                                               () => instance.AvatarLocation(citizenNumber, session, name),
                                               handler => instance.CallbackAvatarLocation += handler);
        }

        public static Task<Result> EnterAsync(this IInstance instance, string worldName)
        {
            return instance.CreateCallbackTask(Callbacks.Enter,
                                               () => instance.Enter(worldName),
                                               handler => instance.CallbackEnter += handler);
        }

        public static Task<Result> LoginAsync(this IInstance instance)
        {
            return instance.CreateCallbackTask(Callbacks.Login,
                                               instance.Login,
                                               handler => instance.CallbackLogin += handler);
        }

        public static Task<Result> WorldResetAttributesAsync(this IInstance instance)
        {
            return instance.CreateCallbackTask(Callbacks.AttributesResetResult,
                                               instance.WorldAttributesReset,
                                               handler => instance.CallbackAttributesResetResult += handler);
        }

        public static Task<Result> BotgramSendAsync(this IInstance instance)
        {
            return instance.CreateCallbackTask(Callbacks.BotgramResult,
                                               instance.BotgramSend,
                                               handler => instance.CallbackBotgramResult += handler);
        }

        public static Task<Result> BotmenuSendAsync(this IInstance instance)
        {
            return instance.CreateCallbackTask(Callbacks.BotmenuResult,
                                               instance.BotmenuSend,
                                               handler => instance.CallbackBotmenuResult += handler);
        }

        public static Task<Result> CellNextAsync(this IInstance instance)
        {
            return instance.CreateCallbackTask(Callbacks.CellResult,
                                               instance.CellNext,
                                               handler => instance.CallbackCellResult += handler);
        }

        public static Task<Result> CavRequestAsync(this IInstance instance, int citizen = 0, int session = 0)
        {
            return instance.CreateCallbackTask(Callbacks.Cav,
                                               () => instance.CavRequest(citizen, session),
                                               handler => instance.CallbackCav += handler);
        }

        public static Task<Result> DeleteAllObjectsAsync(this IInstance instance)
        {
            return instance.CreateCallbackTask(Callbacks.DeleteAllObjectsResult,
                                               instance.DeleteAllObjects,
                                               handler => instance.CallbackDeleteAllObjectsResult += handler);
        }

        public static Task<Result> HudCreateAsync(this IInstance instance)
        {
            return instance.CreateCallbackTask(Callbacks.HudResult,
                                               instance.HudCreate,
                                               handler => instance.CallbackHudResult += handler);
        }

        public static Task<Result> ObjectQueryAsync(this IInstance instance)
        {
            return instance.CreateCallbackTask(Callbacks.ObjectQuery,
                                               instance.ObjectQuery,
                                               handler => instance.CallbackObjectQuery += handler);
        }

        public static Task<Result> QueryAsync(this IInstance instance, int xSector, int zSector, int[,] sequence)
        {
            return instance.CreateCallbackTask(Callbacks.Query,
                                               () => instance.Query(xSector, zSector, sequence),
                                               handler => instance.CallbackQuery += handler);
        }

        public static Task<Result> Query5x5Async(this IInstance instance, int xSector, int zSector, int[,] sequence)
        {
            return instance.CreateCallbackTask(Callbacks.Query,
                                               () => instance.Query5x5(xSector, zSector, sequence),
                                               handler => instance.CallbackQuery += handler);
        }

        #region Helper methods

        private static Task<Result> CreateCallbackTask(this IInstance instance, Callbacks callback, Func<Result> workUnit, Action<InstanceCallbackHandler> handler)
        {
            instance.AddCallbackHandlerIfNeeded(callback, handler);

            var callbackWorkItemQueue = CallbackWorkItemQueue[instance][callback];
            var taskCompletionSource = new TaskCompletionSource<Result>();

            var callbackWorkItem = new CallbackWorkItem
                                       {
                                           TaskCompletionSource = taskCompletionSource,
                                           WorkUnit = workUnit
                                       };

            callbackWorkItemQueue.Enqueue(callbackWorkItem);

            if (callbackWorkItemQueue.Count <= 1)
            {
                try
                {
                    var result = callbackWorkItem.WorkUnit();

                    if(result != Result.Success)
                    {
                        taskCompletionSource.SetResult(result);
                    }
                }
                catch(Exception exception)
                {
                    callbackWorkItem.TaskCompletionSource.SetException(exception);
                    return taskCompletionSource.Task;
                }
            }

            return taskCompletionSource.Task;
        }

        private static void AddCallbackHandlerIfNeeded(this IInstance instance, Callbacks callback, Action<InstanceCallbackHandler> addHandlerAction)
        {
            if(!CallbackWorkItemQueue.ContainsKey(instance))
            {
                CallbackWorkItemQueue[instance] = new Dictionary<Callbacks, Queue<CallbackWorkItem>>();
                
                instance.Disposing += HandleInstanceDisposing;
            }

            if (CallbackWorkItemQueue[instance].ContainsKey(callback))
            {
                return;
            }

            CallbackWorkItemQueue[instance].Add(callback, new Queue<CallbackWorkItem>());

            addHandlerAction(InstanceCallbackHandler(callback));
        }

        private static InstanceCallbackHandler InstanceCallbackHandler(Callbacks callback)
        {
            return (sender, result) =>
                       {
                           var callbackWorkItemQueue = CallbackWorkItemQueue[sender][callback];
                           CallbackWorkItem callbackWorkItem = callbackWorkItemQueue.Dequeue();

                           callbackWorkItem.TaskCompletionSource.SetResult(result);

                           if (callbackWorkItemQueue.Count != 0)
                           {
                               var next = callbackWorkItemQueue.Peek();

                               try
                               {
                                   var nextResult = next.WorkUnit();

                                   if (nextResult != Result.Success)
                                   {
                                       next.TaskCompletionSource.SetResult(nextResult);
                                   }
                               }
                               catch (Exception exception)
                               {
                                   callbackWorkItemQueue.Dequeue();
                                   next.TaskCompletionSource.SetException(exception);
                               }
                           }
                       };
        }

        private static void HandleInstanceDisposing(IInstance sender)
        {
            CallbackWorkItemQueue.Remove(sender);
            sender.Disposing -= HandleInstanceDisposing;
        }

        #endregion
    }
}
