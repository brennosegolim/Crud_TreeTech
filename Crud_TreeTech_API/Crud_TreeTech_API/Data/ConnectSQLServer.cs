using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.Data
{
    public class ConnectSQLServer
    {
        public SqlConnection GetConnection()
        {
            string connection = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DB_TreeTech;Data Source=BRENNO-PC";

            return new SqlConnection(connection);
        }
    }
}
