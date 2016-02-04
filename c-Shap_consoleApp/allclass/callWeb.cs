using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace c_Shap_consoleApp.allclass
{
	public class callWeb
	{
        public  static void RunApp(string[] args)
        { 
            Process proc = new Process();
            proc.StartInfo.FileName = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            if (args.Length > 0)
            {
                proc.StartInfo.Arguments = @"http://localhost:52988/Stat/Default.aspx?mail=y";
            }
            else
                proc.StartInfo.Arguments = @"http://192.168.0.53/ClaimService/stat/default.aspx?mail=y";
            proc.Start(); 
        }
	}
}
