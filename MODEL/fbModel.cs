using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{ 
        public class objChat
        {
            public string id_facebook { get; set; }
            public string name_facebook { get; set; }
            public string comment { get; set; }
            public string phone { get; set; }
            public string action_date { get; set; }
            public string id_facebook_to { get; set; }
            public string name_facebook_to { get; set; }
            public string action_status { get; set; }
            public string obj_id { get; set; }
            public string post_id { get; set; }
        }
        public class objPassValue
        {
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }
            public node nodetype { get; set; }
        } 
        public enum node{
          mother,
          child
        }

}
