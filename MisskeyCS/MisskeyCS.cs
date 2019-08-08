using Nancy.Json;
using System;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MisskeyCS
{
    public class Misskey
    {
        private string __Address;
        private string Address
        {
            get
            {
                return __Address;
            }

            set
            {
                client.BaseAddress = new Uri($"https://{value}/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                __Address = value;
            }
        }
        private string __ApiToken;
        private static HttpClient client = new HttpClient();
        public string ApiToken
        {
            get
            {
                return __ApiToken;
            }

            set
            {
                __ApiToken = value;
            }
        }

        public Misskey(string address = "misskey.io", string i = null)
        {
            Address = address;
            ApiToken = i;
        }

        public string getAddress()
        {
            return this.Address;
        }

        async public Task API(string name, bool isUseToken = false)
        {
            var param = new Hashtable();
            if (isUseToken)
            {
                param["i"] = this.ApiToken;
            }
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(param);
            var content = new StringContent(json);
            var res = await client.PostAsync(name, content);
            Console.WriteLine(res);
        }
    }
}
