using System;
using System.Data;
using System.Data.SQLite;

namespace NavegaTeus.Database
{
    public static class DatabaseController
    {
        public static SQLiteConnection SqlConnection = new SQLiteConnection("Data Source=data.db;Version=3;New=True;Compress=True;");

        public readonly static object Lock = new object();
        public static SQLiteConnection OpenConnection()
        {
            if (SqlConnection.State == ConnectionState.Closed)
            {
                SqlConnection.Open();
            }

            return SqlConnection;
        }

        public static void CloseConnection()
        {
            if (SqlConnection.State == ConnectionState.Open)
            {
                SqlConnection.Close();
            }
        }

        public static void Initialize()
        {
            lock (Lock)
            {
                var connector = OpenConnection();
                try
                {
                    string queryCheckTable = $"SELECT count(*) FROM sqlite_master WHERE type='table' AND name='PAGES'";

                    string queryCreateTable = $"CREATE TABLE PAGES (\r\n    ID INTEGER    PRIMARY KEY AUTOINCREMENT\r\n NOT NULL,\r\n    URL TEXT (500) NOT NULL,\r\n    AUTO_UPDATE      INTEGER    NOT NULL\r\n DEFAULT (0),\r\n    UPDATE_FREQUENCY TEXT NOT NULL,\r\n    LAST_UPDATE TEXT NOT NULL,\r\n    INDEX_POSITION   NUMERIC    NOT NULL\r\n DEFAULT (0) \r\n);\r\n";

                    bool tableExist = false;

                    using (SQLiteCommand cmd = new SQLiteCommand(queryCheckTable, connector))
                    {
                        int existeTabela = Convert.ToInt32(cmd.ExecuteScalar());

                        tableExist = existeTabela > 0;
                    }

                    if (!tableExist)
                    {
                        using (SQLiteCommand cmd = new SQLiteCommand(queryCreateTable, connector))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                finally
                {
                    CloseConnection();
                }
            }
        }
    }
}
