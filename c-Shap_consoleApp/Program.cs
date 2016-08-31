using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using System.Dynamic;

namespace c_Shap_consoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
           //var obj =   MODEL.Model.systemType.callWebUrl;
           
           // switch (obj)
           //{
           //    case MODEL.Model.systemType.callWebUrl:
           //        allclass.callWeb.RunApp(args);
           //        break ; 
           //}
            fbApi();

            //    switch (obj)
            //    {
            //        case MODEL.Model.systemType.callWebUrl:
            //            allclass.callWeb.RunApp(args);
            //            break;
            //    }
            //}
        }
        public static void fbApi() {

            const string applicationId = "540642676124662";
            const string applicationSecret = "329c5070ac5d9ca074f8233437f77078";
            const string pageId = "102661313114041";

            var fb = new FacebookClient();//applicationId,
            dynamic result = fb.Get("oauth/access_token", new
            {
                client_id = applicationId,
                client_secret = applicationSecret,
                grant_type = "client_credentials"
            });
            fb.AccessToken = result.access_token;

            string g = "xxx";

            //https://business.facebook.com/settings/system-users?business_id=104383949750732

            //dynamic parametersa = new ExpandoObject();
            //parametersa.fields = "id,name,last_name";

            //dynamic result1 = fb.Get("390936304428827", parametersa);
            //var id = result1.id;
            //var name = result1.name;


            var parameters = new Dictionary<string, object>();
            parameters["fields"] = "insights.fields(social_spend,spend,frequency,social_clicks,clicks,reach,campaign_name,adset_delivery)";
            parameters["access_token"] = "EAAHrti6pKZCYBAMDbwOT8BOn5fPKaRNO0nZBwkDg6QikqIaGrj902eAVHZCz0ZBW2oYdBhYW3urka2eiwZAudzfzH9gBNU5YNOWuWL0QjgGAZC7LZCqjtE9BGNoCPZARZBxNa906ILnsTII5nx1YbqCehOewO7EAgSvTr2vKR9q8CrAZDZD";
            var _path ="http://graph.facebook.com/me?fields=id,name,picture";
            //var rr = (IDictionary<string, object>)fb.Get(_path);
            //var rr = (IDictionary<string, object>)fb.Get("graph.facebook.com/v2.7/act_104383949750732/campaigns?fields=insights.fields(social_spend,spend,frequency,social_clicks,clicks,reach,campaign_name,adset_delivery)&access_token=EAAHrti6pKZCYBAMDbwOT8BOn5fPKaRNO0nZBwkDg6QikqIaGrj902eAVHZCz0ZBW2oYdBhYW3urka2eiwZAudzfzH9gBNU5YNOWuWL0QjgGAZC7LZCqjtE9BGNoCPZARZBxNa906ILnsTII5nx1YbqCehOewO7EAgSvTr2vKR9q8CrAZDZD");
           
            // var result2 = (IDictionary<string, object>)fb.Get("4", parameters);
            //var id = (string)result2["id"];
            //var name = (string)result2["name"];


        }
    }
}
