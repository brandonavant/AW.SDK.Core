using AW.Core.Sample.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AW.Core.Sample
{
    public class GreeterService : BackgroundService
    {
        private Instance _aw;

        /// <summary>
        /// Configuration settings for bot creation.
        /// </summary>
        private readonly AwConfig _config;

        /// <summary>
        /// Initializes a new instance of <see cref="GreeterService"/>.
        /// </summary>
        /// <param name="configuration"></param>
        public GreeterService(IConfiguration configuration)
        {
            _aw = new Instance();
            _config = new AwConfig();

            configuration.Bind("AwConfig", _config);

            WireUpEventHandlers();
            WireUpCallbackHandlers();
        }


        /// <summary>
        /// Wires up all <see cref="AW.AW_EVENT" handlers./>
        /// </summary>
        private void WireUpEventHandlers()
        {
            _aw.EventAvatarAdd += EventAvatarAdd_EventHandler;
        }

        /// <summary>
        /// Wire up all <see cref="AW.AW_CALLBACK"/> handlers.
        /// </summary>
        private void WireUpCallbackHandlers()
        {
            _aw.CallbackLogin += CallbackLogin_CallbackHandler;
            _aw.CallbackEnter += CallbackEnter_CallbackHandler;
        }

        /// <summary>
        /// Starts up the Greeter bot.
        /// </summary>
        /// <param name="stoppingToken">Token which signals that the operation should be terminated.</param>
        /// <returns><see cref="Task.CompletedTask"/> when the task is complete.</returns>
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            ReasonCode rc;

            _aw.Attributes.LoginOwner = _config.CitizenNumber;
            _aw.Attributes.LoginPrivilegePassword = _config.PrivilegePassword;
            _aw.Attributes.LoginApplication = ".NET 5 AW.Core Sample Application";
            _aw.Attributes.LoginName = "Greeterbot";

            _aw.Login();
                
            while (!stoppingToken.IsCancellationRequested && Utility.Wait(-1) != ReasonCode.Success) ;

            return Task.CompletedTask;
        }

        #region Callback Handlers

        /// <summary>
        /// Callback handler which processes a <see cref="AW.AW_CALLBACK.AW_CALLBACK_LOGIN"/> callback.
        /// </summary>
        /// <param name="sender">The <see cref="AW.IInstance"/> instance which triggered the callback.</param>
        /// <param name="reasonCode">The <see cref="AW.ReasonCode"/> result of the call to <see cref="AW.IInstance.Login"/>.</param>
        private void CallbackLogin_CallbackHandler(IInstance sender, ReasonCode reasonCode)
        {
            if (reasonCode != ReasonCode.Success)
            {
                throw new Exception($"Failed to login (reason {reasonCode})");
            }

            Console.WriteLine("Login Successful!");

            _aw.Enter(_config.EntryWorld);
        }

        /// <summary>
        /// Callback handler which prcoesses a <see cref="AW.AW_CALLBACK.AW_CALLBACK_ENTER"/> callback.
        /// </summary>
        /// <param name="sender">The <see cref="AW.IInstance"/> instance which triggered the callback.</param>
        /// <param name="reasonCode">The <see cref="AW.ReasonCode"/> result of the call to <see cref="AW.IInstance.Enter()"/>.</param>
        private void CallbackEnter_CallbackHandler(IInstance sender, ReasonCode reasonCode)
        {
            ReasonCode rc = 0;

            if (reasonCode != ReasonCode.Success)
            {
                throw new Exception($"Failed to enter {_config.EntryWorld} (reason {reasonCode})");
            }

            Console.WriteLine($"Successfully entered world {_config.EntryWorld}!");

            _aw.Attributes.MyX = 0;
            _aw.Attributes.MyZ = 0;
            _aw.Attributes.MyYaw = 2250;

            rc = _aw.StateChange();
            if (rc != ReasonCode.Success)
            {
                throw new Exception($"Failed to change state (reason {rc})");
            }
        }

        #endregion


        #region Event Handlers

        /// <summary>
        /// Event that fires each time a user enters the world.
        /// </summary>
        /// <param name="sender">The AW SDK instance.</param>
        private void EventAvatarAdd_EventHandler(IInstance sender)
        {
            Console.WriteLine($"{_aw.Attributes.AvatarName} entered.");

            _aw.Say($"Welcome, {_aw.Attributes.AvatarName} to {_aw.Attributes.WorldName}!");
        }

        #endregion
    }
}
