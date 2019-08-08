using System;
using MisskeyCS;

namespace MisskeyCSTest
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Misskey misskey = new Misskey("yuzulia.xyz", "hogehoge");
            Console.WriteLine("MisskeyCS misskey.address = " + misskey.getAddress());
            Console.WriteLine("MisskeyCS misskey.apiToken = " + misskey.ApiToken);
            await misskey.API("meta");
        }
    }
}
