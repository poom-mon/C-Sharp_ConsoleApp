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
              
                       
            allclass.cCallFacebook a = new allclass.cCallFacebook();
            List<objChat> g = (a.getCon2());
            Console.WriteLine(g.Count);
          //  Console.OutputEncoding = System.Text.Encoding;
            foreach(objChat item in g){
                string _nth = string.Format("name {0} to {1} day {2} \n message : {3}" 
                    ,item.name_facebook,item.name_facebook_to,
                    item.action_date,item.comment);

                Console.WriteLine(_nth);
                Console.WriteLine("=======================");
            }
            
            Console.ReadKey();
           // a.matchPhone("สวัสดีครับ เบอผมเบอร์ 083-2640621 ครับบบบบ");

        }   

    }
}
