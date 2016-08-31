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
                proc.StartInfo.Arguments = @"http://192.168.0.2";
            }
            else
                proc.StartInfo.Arguments = @"http://www.silkspan.com/banner/log_cbanner_counter.asp?fname=http://www.silkspan.com/silkspan_ssl/credit/detail_cc_citi_platinum_rewards.asp&typedealer=Toi";
                //proc.StartInfo.Arguments = @"http://192.168.0.2/car_loan/detail_carloan.asp?typedealer=toi";
               // proc.StartInfo.Arguments = @"http://www.silkspan.com";
            
            proc.Start();  
            proc.Close(); 
        }
	}
}
