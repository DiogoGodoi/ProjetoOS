using System.Data.SqlClient;

namespace CONEXAO {
    public class Conexao
    {
        public SqlConnection Connection()
        {
            string connectionString = "Data Source=localhost; Initial Catalog=OS; Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString) ;
            return connection;
        }
    }    
}
