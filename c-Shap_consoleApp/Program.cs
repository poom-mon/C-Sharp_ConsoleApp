using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace c_Shap_consoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string deviceId = getItem();
            Console.WriteLine(deviceId);
            Console.ReadKey();

            //for (int i = 0; i <= 5; i++)
            //{
            //    var obj = MODEL.Model.systemType.callWebUrl;

            //    switch (obj)
            //    {
            //        case MODEL.Model.systemType.callWebUrl:
            //            allclass.callWeb.RunApp(args);
            //            break;
            //    }
            //}
        }
        public static string getItem()
        {

            WebRequest request = WebRequest.Create("https://graph.facebook.com/v2.7/act_104383949750732/campaigns?fields=insights.fields(social_spend%2Cspend%2Cfrequency%2Csocial_clicks%2Cclicks%2Creach%2Ccampaign_name%2Cadset_delivery)&access_token=EAAHrti6pKZCYBAPRnNw0dZB4g5N05c4stcJJwr6iQYPsEmXxpdp8v9KlXkZBLZABQvNFQdWcDpgKpXGxBIxnwgsV7sZAQrjZB1jCGsSXnkIHZCfl4mZCdDlsjTNZBZAA1NmBWVj7b43jOsJmDHQN8s5dqxozbZC5HIzc094YacQYNvIhQZDZD&__mref=message_bubble");

                request.Method = "POST"; 
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";

                // Get the request stream.
                Stream dataStream = request.GetRequestStream();

                // Close the Stream object.
                dataStream.Close();

                // Get the response.
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();

                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);

                // Read the content.
                string accesstoken = reader.ReadToEnd();
                Console.WriteLine("xxx");

                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
                return accesstoken;
        }
    }
}
