using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace WAAPI_GetSwitchInfo
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
            
            //get selected object (single object selection for now)
            var result = await client.Call(
                ak.wwise.ui.getSelectedObjects);  

            Console.WriteLine(result);

            //return object type from selected object
            
            //notify user if no switch container is selected

            //get switchgroup assignment from container.  Notify user.
        }
    }
}
