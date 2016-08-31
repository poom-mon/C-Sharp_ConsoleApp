using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;

namespace c_Shap_consoleApp.allclass
{
    public class cCallFacebook
    {

        public static string AccessToken = "EAAWh0ZAZAHVgcBABynj6lyl2oIUOjpKZBQX2xK3YmnrOlvVqeqqDlbzLdMZCa7pWKIaHw0gYpEYlVrlRCyL39PGp10BmmGiVMhVHdA4L2aFIaw7XTEZChhotQIFITjFNDegZBSFZBGeHFBJmNoTGqTB31R0kcD9wy2rWUcZBRUEtNQZDZD";
        public static string AppId = "1585296425047559";
        public static string AppSecrete = "bc2c8d0d5a808d54dd3368b00f627689";


        /***
         remark: 
         *  download facebook client : 
            Install-Package Facebook
         
         * refer : http://blog.prabir.me/posts/facebook-csharp-sdk-making-requests
         */
        public cCallFacebook() {

            AccessToken = getToken();
            getCode();
        }
        public string getToken() { 

            var fb = new FacebookClient();//applicationId,
            dynamic result = fb.Get("oauth/access_token", new
            {
                client_id = AppId,
                client_secret = AppSecrete,
                grant_type = "client_credentials"
            });
            fb.AccessToken = result.access_token;
            return result.access_token;
        }
        public string getCode()
        {

            var fb = new FacebookClient();//applicationId,
            dynamic result = fb.Get("oauth/authorize?client_id="+AppId+"&redirect_uri=http://www.silkspan.com/carinsur/test/testfb.aspx&scope=ads_management,manage_pages");
            //dynamic result = fb.Get("oauth/authorize?client_id="+AppId+"&redirect_uri="http://www.silkspan.com/carinsur/test/testfb.aspx&scope=ads_management,manage_pages", new
            //{
            //    client_id = AppId,
            //    redirect_uri = "http://www.silkspan.com/carinsur/test/testfb.aspx",
            //    scope = "ads_management,manage_pages"
            //}); 
            return result;
        }
        public   IEnumerable<string> getChatFacebook()
        {
            try
            {
                var fb = new FacebookClient(AccessToken) { AppId = AppId, AppSecret = AppSecrete };
                List<string> _lisObj = new List<string>();
                dynamic results = fb.Get("/silkspan/?fields=conversations");
                 
                foreach (var result in results.data)
                { 
                    // _lisObj.Add(result.id);
                }
                return _lisObj;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
                return null;
            }
        }
    }
}
