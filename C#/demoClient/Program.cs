using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

namespace demoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // var url = "http://localhost:18525/";
            var url = "http://localhost:5000/";

            using (var client = new WebClient())
            {
                client.QueryString.Add("name", "Max");
                client.QueryString.Add("sex", "M");
                client.QueryString.Add("age", "30");
                var responseString = client.DownloadString(url);
                Console.WriteLine(responseString);
            }

            using (var client = new WebClient())
            {
                var data = new NameValueCollection();
                data.Add("name", "Max");
                data.Add("sex", "M");
                data.Add("age", "30");
                var response = client.UploadValues(url, data);
                var responseString = Encoding.Default.GetString(response);
                Console.WriteLine(responseString);
            }

            Console.ReadLine();
        }
    }
}
