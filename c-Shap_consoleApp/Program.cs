using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using System.Dynamic;
using System.Net;
using System.IO;
using MODEL;

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


            //DateTime dt1 = new DateTime(2016, 9, 12, 01, 00, 00, 0);
            //DateTime dt2 = new DateTime(2016, 9, 12, 16, 25, 46, 0);

                
            // Console.WriteLine(dt1.CompareTo(dt2));
            // Console.WriteLine(dt2.CompareTo(dt1));



             DateTime dtStart = DateTime.Now, dtEnd = DateTime.Now;
             dtStart = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, 01, 00, 00); //01:00:00 AM
             dtEnd = new DateTime(dtEnd.Year, dtEnd.Month, dtEnd.Day, 23, 59, 59); //01:00:00 AM

            allclass.cCallFacebook a = new allclass.cCallFacebook();
            List<objChat> g = (a.getConversation(dtStart, dtEnd)); 

            Console.WriteLine("count>>" +g.Count);
          //  Console.OutputEncoding = System.Text.Encoding;
            foreach(objChat item in g){
                string _nth = string.Format("name {0} to {1} day {2}  "
                    , item.name_facebook, item.name_facebook_to, item.action_date );
                //string _nth = string.Format("name {0} to {1} day {2} \n message : {3}" 
                //    ,item.name_facebook,item.name_facebook_to,
                //    item.action_date,item.comment);

                Console.WriteLine(_nth);
                Console.WriteLine("=======================");
            }
            
            Console.ReadKey();
           // a.matchPhone("สวัสดีครับ เบอผมเบอร์ 083-2640621 ครับบบบบ");

        }   

    }
}


/*



//var _url = "https://graph.facebook.com/v2.2/silkspan/feed?&since=" + startDate + "&until=" + endDate + "&access_token=EAAWh4qqtIIoBAGtS3n2qrS5arDUT89fZAXdFW8Jw28bZBhnGQ5kxxftRuLPZC7vzGHzddPzVTwjs5eBDtVmIYpZBCUColdZBU2iqwlVFchUGWIZBCZAVZAfP1kaZCqZAIrDhJN2NHZAkHTQna7mBCSweVr2rJf3PFzfUINkMntyz41fSQZDZD";
    var _url = "https://graph.facebook.com/v2.2/silkspan/feed?&since=" + startDate + "&until=" + endDate + "&access_token=EAAWh0ZAZAHVgcBABtxWD4hsgRx0byg83prAZB3VqZAD7vo06LI4eyZBtDX29SYA8BAqBw3ZBZAsNryFBMIawfhZBOxoYKbCkV23MJ8Kfq4PLOJ4VcGW331FMhXwZCuMJoXpzZBiNgMBJJX0qwg1WjO4xtLYZAXGwC4g2KXCYFKV7KPAVAZDZD&callback=?";

    $.getJSON(_url, function (obj) {
        var response = obj
            , _comment = ''
            , _phone = ''
            , _id_face = ''
            , _obj_id = ''
            , _post_id = '';
        $('#dvRes_Comment').append('<p> >>> start comment !!!</p>');
        for (var i = 0; i < response.data.length; i++) {
            if (typeof response.data[i].comments != 'undefined') {
                for (var j = 0; j < response.data[i].comments.data.length; j++) {

                    _comment = response.data[i].comments.data[j].message || '';
                    if (_comment) {

                        _post_id = ''
                        _obj_id = response.data[i].comments.data[j].id || ''
                        _id_face = response.data[i].comments.data[j].from.id || '';
                        _phone = _id_face == '55269232341' ? '' : matchPhone(_comment);

                        var temp = {};
                        temp.id_facebook = _id_face;
                        temp.name_facebook = response.data[i].comments.data[j].from.name || '';
                        temp.id_facebook_to = '';
                        temp.name_facebook_to = '';
                        temp.action_date = response.data[i].comments.data[j].created_time || '';
                        temp.comment = _comment;
                        temp.post_id = response.data[i].id
                        temp.article = response.data[i].message || response.data[i].description;
                        temp.link = response.data[i].link || '';
                        temp.action_status = 'comment';
                        temp.phone = _phone;
                        temp.obj_id = _obj_id;
                        data.push(temp);

                        //console.log('comment : ' + _id_face);
                        $('#dvRes_Comment').append('<p>' + _id_face + '</p>');
                    }
                }
            }
        }
        data = data.reverse();

*/