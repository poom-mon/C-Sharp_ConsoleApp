using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using System.Dynamic;
using System.Net;
using System.IO;

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
             a.getCon2();  
            a.matchPhone("สวัสดีครับ เบอผมเบอร์ 083-2640621 ครับบบบบ");
        }   

    }
}
