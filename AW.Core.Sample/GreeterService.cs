﻿using AW.Core.Sample.Models;
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
        }

        /// <summary>
        /// Wire up all AW SDK Event Handlers./>
        /// </summary>
        private void WireUpEventHandlers()
        {
            _aw.EventAvatarAdd += EventAvatarAdd_EventHandler;
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

            rc = _aw.Login();
            if (rc != ReasonCode.Success)
            {
                throw new Exception($"Failed to login (reason {rc})");
            }

            rc = _aw.Enter(_config.EntryWorld);
            if (rc != ReasonCode.Success)
            {
                throw new Exception($"Failed to enter {_config.EntryWorld} (reason {rc})");
            }

            _aw.Attributes.MyX = 3000000;
            _aw.Attributes.MyZ = 3000000;
            _aw.Attributes.MyYaw = 2250;

            rc = _aw.StateChange();
            if (rc != ReasonCode.Success)
            {
                throw new Exception($"Failed to change state (reason {rc})");
            }

            while (!stoppingToken.IsCancellationRequested && Utility.Wait(-1) != ReasonCode.Success) ;

            return Task.CompletedTask;
        }


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