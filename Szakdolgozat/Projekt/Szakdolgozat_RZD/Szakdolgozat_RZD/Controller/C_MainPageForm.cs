using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdolgozat_RZD
{
    class C_MainPageForm
    {
        
        public static string country_name { get; set; }
        public string form_of_government { get; set; }
        public static string tech_age { get; set; }
        public static int plain { get; set; }
        public static int hill { get; set; }
        public static int mountain { get; set; }
        public static int sunshine_hours_class { get; set; }
        public static int population { get; set; }
        public static int population_change { get; set; }
        public static bool beach { get; set; }
        public static string currency_name { get; set; }
        public static int currency_value { get; set; }

        public static int area { get; set; }
        

        public C_MainPageForm() { }

        public C_MainPageForm(List<string> data)
        {
            country_name = data[0];
            form_of_government = data[1];
            tech_age = data[2];
            plain = Convert.ToInt32(data[3]);
            hill = Convert.ToInt32(data[4]);
            mountain = Convert.ToInt32(data[5]);
            sunshine_hours_class = Convert.ToInt32(data[6]);
            population = Convert.ToInt32(data[7]);
            population_change = Convert.ToInt32(data[8]);
            beach = Convert.ToBoolean(data[9]);
            currency_name = data[10];
            currency_value = Convert.ToInt32(data[11]);
            area = plain + hill + mountain;
        }
        
    }
}
