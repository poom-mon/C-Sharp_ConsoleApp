﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

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

        public object getCon2()
        {
            try
            {
                var fb = new FacebookClient(AccessToken) { AppId = AppId, AppSecret = AppSecrete };
                List<object> _lisObj = new List<object>();
                List<object> _lisObj2 = new List<object>();

                DateTime dtStart = DateTime.Now, dtEnd = DateTime.Now;
                dtStart = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, 0, 0, 0); //01:00:00 AM
                dtEnd = new DateTime(dtEnd.Year, dtEnd.Month, dtEnd.Day, 23, 59, 59); //01:00:00 AM


                dynamic results = fb.Get("silkspan/?fields=conversations");

              //  dynamic results222 = fb.Get("t_mid.1458116143347:c6e07ab5f509750622"); 

                var a = results.conversations.paging.next;
                var b = results.conversations.paging.previous;  

                //dynamic results2 = fb.Get(a);
                //var b = results[1].next;
                //foreach (object result in results2.data)
                //{
                //    _lisObj2.Add(result);
                //}
                //var c = results2[1].next; 
                 
                 
                List<objChat> _objchat = new List<objChat>();
                int count = 1;
                foreach (dynamic result in results.conversations.data) 
                { 
                    var _obj_id = result.id;
                    var _updatetime = result.updated_time;

                    //"2016-09-09T10:17:46+0000"

                     string strdate = _updatetime;
                    int yy = Convert.ToInt32(strdate.Split('-')[0]);

                    string a1= strdate.Split('-')[0];
                    string a2= strdate.Split('-')[1];
                    string c = strdate.Split('-')[2];// 09T10:21:57+0000
                    string d = strdate.Split(':')[0]; //2016-09-09T10
                    string e= strdate.Split(':')[1];
                    string f= strdate.Split(':')[2];

                    var dt = DateTime.Parse(_updatetime);
                    string output = dt.ToString(@"MM/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);


                   // DateTime dtm = new DateTime(
                   //         Convert.ToInt32(strdate.Split('-')[0]) , 
                   //         Convert.ToInt32(strdate.Split('-')[1]) , 
                   //         Convert.ToInt32(strdate.Split('-')[2]) , 

                   //);
                     
                    if(_updatetime >= dtStart && _updatetime <= dtEnd)
                    {
                        var g  ="";
                    }
                    else {
                        var cccc = _updatetime;
                        count++;
                    }
                 

                    foreach(var g in result.messages.data){ // วน message  

                            var _comment = "";
                            if (g.message == "")
                            { 
                              dynamic _obattact = g[6].data[0]; 
                              if (_obattact[0] == null)
                              {
                                  //sticker  
                                 // var _linkstatu = g[6].data[0].link;
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
                                  else {
                                      _comment += ";[@attachfile][name=" + g[6][0][0].image_data.name + "]" + g[6][0][0].image_data.file_url;
                                  }  
                              } 
                        }
                        else
                        {
                            _comment = g.message;
                            _lisObj.Add(g.message);
                        }

                        var gto = g.to.data[0].id;
                        var gname = g.to.data[0].name;
                        var gform = g.from.id;
                        var createdate = g.created_time; 
                        var _post_id = g.id; 

                        string _phone = (gform == "55269232341" ? "" : matchPhone(_comment));
                       
                        _objchat.Add(new objChat() {
                            id_facebook = gform,
                            name_facebook = gname,
                            comment = _comment,
                            phone  = _phone ,
                            action_date = createdate,
                            id_facebook_to  = gto,
                            name_facebook_to = gname,
                            action_status = "inbox"  ,
                            obj_id = _obj_id ,
                            post_id = _post_id 
                        });

                    }
                }
                return _objchat;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
                return null;
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

    public class objChat 
    {
        public string id_facebook { get; set; }
        public string name_facebook{ get; set; }
        public string comment { get; set; }
        public string phone { get; set; }
        public string action_date { get; set; }
        public string id_facebook_to { get; set; }
        public string name_facebook_to { get; set; }
        public string action_status { get; set; }
        public string obj_id { get; set; }
        public string post_id { get; set; }  
    }

}
