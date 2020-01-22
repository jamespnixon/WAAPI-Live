using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace WAAPI_Commands_Execute
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            _Main().Wait();
        }

        static async Task _Main()
        {
            AK.Wwise.Waapi.JsonClient client = new AK.Wwise.Waapi.JsonClient();

            await client.Connect();

            client.Disconnected += () =>
            {
                System.Console.WriteLine("We lost connection!");
            };

            await client.Call(
                ak.wwise.ui.commands.execute, new
                {
                    command = "Solo",
                    
                },
                null
            );

            await client.Close();
        }
    }
}
