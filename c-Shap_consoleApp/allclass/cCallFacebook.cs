using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using MODEL; 

namespace c_Shap_consoleApp.allclass
{
    public class cCallFacebook
    {

        //public static string AccessToken = "EAAWh0ZAZAHVgcBABynj6lyl2oIUOjpKZBQX2xK3YmnrOlvVqeqqDlbzLdMZCa7pWKIaHw0gYpEYlVrlRCyL39PGp10BmmGiVMhVHdA4L2aFIaw7XTEZChhotQIFITjFNDegZBSFZBGeHFBJmNoTGqTB31R0kcD9wy2rWUcZBRUEtNQZDZD";
        //public static string AppId = "1585296425047559";
        //public static string AppSecrete = "bc2c8d0d5a808d54dd3368b00f627689";

        public static string AccessToken = "EAAWh0ZAZAHVgcBAPg3Bdos3pMpTR7eh74oAstDZCxoT2NcWZCjhVyyT2ZAefuqPNm7gqpviNTXhxMeMGKbHNA2RFpofnTf4J7eltovAT9p1vWWj0BsMNRoEXygGocFzdgUphobT2AZB53Bai3ZBQkDZBaFZB0ZAIn4pkLKujnum2NAOQZDZD";
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



        public object getConversion() {
            DateTime dt = DateTime.Now;

            return null;
        }

        public List<objChat> getCon2()
        {
            try
            {
                var fb = new FacebookClient(AccessToken) { AppId = AppId, AppSecret = AppSecrete }; 

                DateTime dtStart = DateTime.Now, dtEnd = DateTime.Now;
                dtStart = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, 0, 0, 0); //01:00:00 AM
                dtEnd = new DateTime(dtEnd.Year, dtEnd.Month, dtEnd.Day, 23, 59, 59); //01:00:00 AM


                dynamic results = fb.Get("silkspan/?fields=conversations");

                List<objChat> _objchat = new List<objChat>(); 
                 
                generateObjChat(results, ref _objchat,
                       new objPassValue(){ startDate = dtStart , endDate =dtEnd });

                
              //  dynamic results222 = fb.Get("t_mid.1458116143347:c6e07ab5f509750622"); 

                var a = results.conversations.paging.next;
                var b = results.conversations.paging.previous;  
                 
                
               
                return _objchat;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
                return null;
            }
        }
        private void recusive(ref List<objChat> _objchat, objPassValue objPassValue)
        {
            dynamic results = excuteGraph("silkspan/?fields=conversations");
            var _next = results.conversations.paging.next;
            var _previous = results.conversations.paging.previous; 
          

        }
         

        private void generateObjChat(dynamic results, ref List<objChat> _objchat, objPassValue objPassValue)
        { 
            foreach (dynamic result in results.conversations.data)
            {
                var _obj_id = result.id;
                var _updatetime = result.updated_time;

                DateTime _update = DateTime.Parse(_updatetime);  //"2016-09-09T10:17:46+0000" 
                if (_update >= objPassValue.startDate && _update <= objPassValue.endDate)
                {
                    var g = "";
                    // อยู่ในเงือนไขวันไปต่อ
                }
                else
                {
                    var cccc = _updatetime; 
                    break;// ไม่อยู่ในเงือนไขวันให้จบ
                }

                foreach (var g in result.messages.data)
                { // วน message  

                    var _comment = "";
                    if (g.message == "")
                    {
                        dynamic _obattact = g[6].data[0];
                        if (_obattact[0] == null)
                        { //sticker   
                            _comment += "<img class=\"_comment_sticker\" src='" + g[6].data[0].link + "' />";
                        }
                        else
                        {
                            dynamic _filetype = _obattact.mime_type;
                            if (_filetype.Contains("image")) // image attact
                            {
                                var _urlimage = g[6][0][0].image_data.url;
                                _comment += "<img class=\"_comment_picture\" src='" + _urlimage + "' />";
                            }
                            else
                            {
                                _comment += ";[@attachfile][name=" + g[6][0][0].image_data.name + "]" + g[6][0][0].image_data.file_url;
                            }
                        }
                    }
                    else
                    {
                        _comment = g.message; 
                    }

                    var gto = g.to.data[0].id;
                    var gnameto = g.to.data[0].name;
                    var gform = g.from.id;
                    var gnamefrom = g.from.name;
                    var createdate = g.created_time;
                    var _post_id = g.id;

                    string _phone = (gform == "55269232341" ? "" : matchPhone(_comment));

                    _objchat.Add(new objChat()
                    {
                        id_facebook = gform,
                        name_facebook = gnamefrom,
                        comment = _comment,
                        phone = _phone,
                        action_date = createdate,
                        id_facebook_to = gto,
                        name_facebook_to = gnameto,
                        action_status = "inbox",
                        obj_id = _obj_id,
                        post_id = _post_id
                    });

                }
            }
        }
         


        public string matchPhone(string _comment)
        {
            Regex regex = new Regex(@"0[6,8,9]{1}-?[0-9]{1}[ -]?[0-9]{3}[ -]?[0-9]{4}");
            Match match = regex.Match(_comment);
            string phone = "";
	        if (match.Success)
	        {
                phone = match.Value;
	        }
            return phone;
        }


    }

    

}
