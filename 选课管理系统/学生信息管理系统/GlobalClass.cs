using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace 登录案例
{
    class GlobalClass
    {
        public static string StrCnn;
        public static SqlConnection ConLoginDB = new SqlConnection();
    }
}
