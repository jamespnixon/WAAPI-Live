using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace WAAPI_Create
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

    var objectID = await client.Call(
        ak.wwise.core.@object.create,
        new
        {
            name = "My Second New Object",
            parent = @"\Actor-Mixer Hierarchy\Default Work Unit\WAAPI_Tests",
            type = "BlendContainer"
        },
        null);

    Console.WriteLine("Made " + objectID["name"]);
        
}
    }
}

