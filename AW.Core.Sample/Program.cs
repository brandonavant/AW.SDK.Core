using System;

namespace AW.Core.Sample
{
    class Program
    {
        private static Instance _aw;

        static int Main(string[] args)
        {
            Result rc = 0;
            _aw = new Instance();

            var privilegePassword = string.Empty;
            var world = string.Empty;


            _aw.EventAvatarAdd += EventAvatarAdd_EventHandler;

            Console.WriteLine("Please enter your citizen number:");
            
            if(!int.TryParse(Console.ReadLine(), out int citizenNumber))
            {
                Console.WriteLine("You enter an invalid value.");
                return 1;
            }

            Console.WriteLine("Please enter your privilege password.");
            privilegePassword = Console.ReadLine();

            if (string.IsNullOrEmpty(privilegePassword))
            {
                Console.WriteLine("You must enter a privilege password.");
                return 1;
            }

            _aw.SetInt(Attributes.LoginOwner, citizenNumber);
            _aw.SetString(Attributes.LoginPrivilegePassword, privilegePassword);
            _aw.SetString(Attributes.LoginApplication, ".NET Standard Test");
            _aw.SetString(Attributes.LoginName, ".NET Standard Test");

            rc = _aw.Login();
            if (rc != Result.Success)
            {
                Console.WriteLine($"Failed to login (reason {rc})");
                return 1;
            }

            Console.WriteLine("Which world would you like to enter?");
            world = Console.ReadLine();

            rc = _aw.Enter(world);
            if (rc != Result.Success)
            {
                Console.WriteLine($"Failed to enter world '{world}' (reason {rc})");
                return 1;
            }

            _aw.SetInt(Attributes.MyX, 0);
            _aw.SetInt(Attributes.MyZ, 0);
            _aw.SetInt(Attributes.MyYaw, 0);

            rc = _aw.StateChange();
            if (rc != Result.Success)
            {
                Console.WriteLine($"Failed to change state (reason {rc})");
                return 1;
            }

            while (Utility.Wait(-1) != Result.Success) ;

            return 0;
        }

        private static void EventAvatarAdd_EventHandler(IInstance sender)
        {
            Console.WriteLine($"{_aw.GetString(Attributes.AvatarName)} entered");
        }
    }
}
