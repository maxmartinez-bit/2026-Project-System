using MySql.Data.MySqlClient;

public class Db
{
    private readonly string _connectionString;

    public Db(string connectionString)
    {
        _connectionString = connectionString;
    }

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(_connectionString);
    }
}