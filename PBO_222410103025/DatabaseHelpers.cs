using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace PBO_222410103025
{
    internal class DatabaseHelpers
    {
        string connString = "Host=localhost;Username=postgres;Password=1;Database=Kantor";
        NpgsqlConnection conn;

        public void connect()
        {
            if (conn == null)
            {
                conn = new NpgsqlConnection(connString);
            }
            conn.Open();
        }

        public DataTable getData(string sql)
        {
            DataTable table = new DataTable();
            connect();
            try
            {
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, conn);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conn.Close();
            }
            return table;
        }

        public void exc(String sql)
        {
            connect();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
        }
    }
}
