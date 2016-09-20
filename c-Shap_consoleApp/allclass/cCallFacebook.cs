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

         

        public List<objChat> getConversation(DateTime dtStart,DateTime dtEnd)
        {
            try
            {   
                List<objChat> _objchat = new List<objChat>();    
                queryConversation(ref _objchat
                  ,new objPassValue(){ startDate = dtStart , endDate =dtEnd ,nodetype = node.mother }
                  ,"silkspan/?fields=conversations");
               
                return _objchat;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
                return null;
            }
        }
        private void queryConversation(ref List<objChat> _objchat, objPassValue objPassValue, String url)
        {// recusive in Node next
            dynamic results = excuteGraph(url);

            String _next = "";
            if (objPassValue.nodetype == node.mother)  
                _next = results.conversations.paging.next;
            else
                _next = results.paging.next; 

            bool _enprocess = true;
            generateObjChat(results, ref _objchat, objPassValue, ref _enprocess);

            string g = "";
            if (_enprocess == true)
            {
                objPassValue.nodetype = node.child;
                queryConversation(ref _objchat, objPassValue, _next); 
            } 
        } 
         
        private void generateObjChat(dynamic results, ref List<objChat> _objchat, objPassValue objPassValue,ref bool endprocess)
        { 
            if (objPassValue.nodetype == node.mother) {
                results = results.conversations;
            }
            foreach (dynamic result in results.data) 
            { 
               var _obj_id = result.id;
               var _updatetime = result.updated_time;

               DateTime _update = DateTime.Parse(_updatetime);  //"2016-09-09T10:17:46+0000"  

               if (objPassValue.startDate >= _update)
                {// วันที่ update facebook <  วันที่เริ่ม
                    endprocess = false;
                    break; 
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
                                    _comment += ";[@attachfile][name=" + g[6][0][0].name + "]" + g[6][0][0].file_url;
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

                        DateTime _createdate = DateTime.Parse(createdate);
                        if (objPassValue.startDate >=  _createdate   )
                        { 
                            break;// node การสนทนาข้างในวันที่เริ่มต้องมากกว่าวันที่ สร้าง
                        } 
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
