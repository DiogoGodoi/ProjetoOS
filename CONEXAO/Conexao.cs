using System.Data.SqlClient;

namespace CONEXAO {
    public class Conexao
    {
        public SqlConnection Connection()
        {
            var builder = new SqlConnectionStringBuilder { DataSource = "localhost", InitialCatalog = "OS", IntegratedSecurity = true };
            SqlConnection connection = new SqlConnection(builder.ConnectionString) ;
            return connection;
        }
    }    
}
