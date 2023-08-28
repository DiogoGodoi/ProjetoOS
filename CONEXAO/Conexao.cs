using System.Data.SqlClient;

namespace CONEXAO {
    public class Conexao
    {
        public SqlConnection Connection()
        {
            // Cria��o da conex�o
            var builder = new SqlConnectionStringBuilder { DataSource = "localhost", InitialCatalog = "OS", IntegratedSecurity = true };
            SqlConnection connection = new SqlConnection(builder.ConnectionString) ;
            return connection;
        }
    }    
}
