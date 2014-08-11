using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Connectiontest
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection( "Server=localhost\sqlexpress;uid=USERNAME;pwd=PASSWORD;database=DBID" )
            <add name="myConnName" 
connectionString="Data Source=&quot;bamboo.arvixe.com &quot;;Initial Catalog=myDB;User ID=myID;Password=myPASWORD" 
providerName="System.Data.SqlClient"/>
</connectionStrings> 
        }
    }
}
