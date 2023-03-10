using System.Data.SqlClient;

namespace DesignPatterns_Singleton_3.DBManager
{
    public class DatabaseConnectionManager
    {
        private static readonly Lazy<DatabaseConnectionManager> instance = new Lazy<DatabaseConnectionManager>();

        private readonly string connectionString;
        private SqlConnection connection;

        public DatabaseConnectionManager(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        public static DatabaseConnectionManager Instance => instance.Value;

        public SqlConnection GetConnection()
        {
            if (connection == null)
                connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}
