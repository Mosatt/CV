using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szakdolgozat_RZD
{
    class M_db_mainpagef
    {
        public string sql_countrys_table = $"SELECT * FROM countrys WHERE ID = '{C_Login.ID}'";
        public List<string> list_own_country_sql_query_columns = new List<string>()
        {
            "country_name", "form_of_government", "tech_age", "plain", "hill", "mountain", "sunshine_hours_class",
            "population", "population_change", "beach", "currency_name", "currency_value"
        };
    }
}
