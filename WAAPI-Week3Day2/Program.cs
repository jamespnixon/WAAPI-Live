using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace WAAPI_Week3Day2
{
    class  MainClass
    {
        public static void Main (string[] args)
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

            var args = new JObject
                (
                     new JProperty("from", new JObject
                     (
                     new JProperty("id", new JArray(new string[]
                    {"<PUT YOUT GUID HERE>"})))
                )
                );
            var options = new JObject
                (
                new JProperty("return", new string[] { "name", "id", "@Volume" }
                )
                );

            var result = await client.Call(
                ak.wwise.core.@object.get,
                args,
                options
                );

            Console.WriteLine(result);
        }
    }
}
