using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using System.Net;
using System.IO;

namespace c_Shap_consoleApp.allclass
{
    public class cCallFacebook
    {

        //public static string AccessToken = "EAAWh0ZAZAHVgcBABynj6lyl2oIUOjpKZBQX2xK3YmnrOlvVqeqqDlbzLdMZCa7pWKIaHw0gYpEYlVrlRCyL39PGp10BmmGiVMhVHdA4L2aFIaw7XTEZChhotQIFITjFNDegZBSFZBGeHFBJmNoTGqTB31R0kcD9wy2rWUcZBRUEtNQZDZD";
        //public static string AppId = "1585296425047559";
        //public static string AppSecrete = "bc2c8d0d5a808d54dd3368b00f627689";

        public static string AccessToken  = "EAAWh0ZAZAHVgcBAPP8ueUZAneYcC69m1VQyZAVax0vSUZCskbShChcXx8XaZAp3M3DopsZBq5QpyFSxOyE3c7TomAycMnDIZA5qJZCh4WonWwOKmx5opCeUAnaMC8zioiphmydFfrSdZC5ZAKU0KrYKJCEtplGJ8TgIhCZB9SYfwQRp3DgZDZD";
        public static string AppId = "1585296425047559";
        public static string AppSecrete = "bc2c8d0d5a808d54dd3368b00f627689";

        /***
         remark: 
         *  download facebook client : 
            Install-Package Facebook
         
         * refer : http://blog.prabir.me/posts/facebook-csharp-sdk-making-requests
         */
        public cCallFacebook() {   

        } 
        public object excuteGraph(string _graphUrl)
        {
            try
            {
                var fb = new FacebookClient(AccessToken) { AppId = AppId, AppSecret = AppSecrete }; 
                List<object> _lisObj = new List<object>();
                return fb.Get(_graphUrl); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
                return null;
            }
        }


        public   object getChatFacebook()
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
       // public IEnumerable<string> getFeed()
        public object getFeed()
        {
            try
            {
                var fb = new FacebookClient(AccessToken) { AppId = AppId, AppSecret = AppSecrete };
                List<object> _lisObj = new List<object>();
                List<object> _lisObj2 = new List<object>();
                dynamic results = fb.Get("/55269232341_10154511844402342/comments");
                var a = results[1].next;

                dynamic results2 = fb.Get(a);
                var b = results[1].next;
                foreach (object result in results2.data)
                {
                    _lisObj2.Add(result);
                }
                var c = results2[1].next;


                foreach (object result in results.data)
                {
                     _lisObj.Add(result);
                }
                return _lisObj;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
                return null;
            }
        } 

    }
}
