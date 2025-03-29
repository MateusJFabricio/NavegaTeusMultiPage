using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavegaTeus.Database.Models;

namespace NavegaTeus.Database.DTO
{
    public class PagesDTO
    {
        public static PagesModel PagesInsert(PagesModel pages)
        {
            lock (DatabaseController.Lock)
            {
                var connector = DatabaseController.OpenConnection();

                try
                {
                    if (pages == null)
                    {
                        throw new Exception("pages não pode ser nulo");
                    }

                    if (pages.URL == null)
                    {
                        throw new Exception("URL não pode ser nulo");
                    }

                    if (pages.UpdateFrequency == null)
                    {
                        throw new Exception("Update frequency não pode ser nulo");
                    }

                    if (pages.IndexPosition < 0)
                    {
                        throw new Exception("Index não pode ser menor ou igual a zero");
                    }

                    SQLiteCommand cmd = new SQLiteCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO PAGES (URL, AUTO_UPDATE, UPDATE_FREQUENCY, INDEX_POSITION, LAST_UPDATE) " +
                        "VALUES (@URL, @AUTO_UPDATE, @UPDATE_FREQUENCY, @INDEX_POSITION, @LAST_UPDATE); " +
                        "SELECT last_insert_rowid();";

                    cmd.Parameters.AddWithValue("@URL", pages.URL);
                    cmd.Parameters.AddWithValue("@AUTO_UPDATE", pages.AutoUpdate ? 1 : 0);
                    cmd.Parameters.AddWithValue("@UPDATE_FREQUENCY", pages.UpdateFrequency.ToString());
                    cmd.Parameters.AddWithValue("@INDEX_POSITION", pages.IndexPosition);
                    cmd.Parameters.AddWithValue("@LAST_UPDATE", DateTime.MinValue);

                    cmd.Connection = connector;
                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    pages.Id = id;

                    return pages;
                }
                finally
                {
                    DatabaseController.CloseConnection();
                }
            }
        }

        public static List<PagesModel> PagesGetAll()
        {
            lock (DatabaseController.Lock)
            {
                var connector = DatabaseController.OpenConnection();
                List<PagesModel> pagesList = new List<PagesModel>();
                try
                {
                    SQLiteCommand sqlCommand = connector.CreateCommand();

                    //Monta a consulta
                    sqlCommand.CommandText = "SELECT * FROM PAGES ORDER BY INDEX_POSITION";
                    sqlCommand.Connection = connector;


                    // Executa o comando e obtém os dados com SqliteDataReader
                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Preenche o modelo com os dados "YYYY/MM/DD HH:mm:ss"
                            var pages = new PagesModel
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                                URL = reader.GetString(reader.GetOrdinal("URL")).Trim(),
                                UpdateFrequency = TimeSpan.Parse(reader.GetString(reader.GetOrdinal("UPDATE_FREQUENCY"))),
                                IndexPosition = reader.GetInt32(reader.GetOrdinal("INDEX_POSITION")),
                                AutoUpdate = reader.GetInt32(reader.GetOrdinal("AUTO_UPDATE")) == 1,
                                LastUpdate = DateTime.Parse(reader.GetString(reader.GetOrdinal("LAST_UPDATE")))
                            };
                            pagesList.Add(pages);

                        }
                    }

                    return pagesList;
                }
                finally
                {
                    DatabaseController.CloseConnection();
                }
            }
        }

        public static PagesModel PagesGetById(int id)
        {
            lock (DatabaseController.Lock)
            {
                var connector = DatabaseController.OpenConnection();
                try
                {
                    SQLiteCommand sqlCommand = connector.CreateCommand();

                    //Monta a consulta
                    sqlCommand.CommandText = "SELECT * FROM PAGES WHERE ID = @ID";
                    sqlCommand.Connection = connector;
                    sqlCommand.Parameters.AddWithValue("ID", id);


                    // Executa o comando e obtém os dados com SqliteDataReader
                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Preenche o modelo com os dados
                            var pages = new PagesModel
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                                URL = reader.GetString(reader.GetOrdinal("URL")).Trim(),
                                UpdateFrequency = TimeSpan.Parse(reader.GetString(reader.GetOrdinal("UPDATE_FREQUENCY"))),
                                IndexPosition = reader.GetInt32(reader.GetOrdinal("INDEX_POSITION")),
                                AutoUpdate = reader.GetInt32(reader.GetOrdinal("AUTO_UPDATE")) == 1,
                                LastUpdate = DateTime.Parse(reader.GetString(reader.GetOrdinal("LAST_UPDATE")))
                            };
                            return pages;
                        }
                    }
                }
                finally
                {
                    DatabaseController.CloseConnection();
                }

                return null;
            }
        }

        public static bool PagesDeleteById(PagesModel pages)
        {
            lock (DatabaseController.Lock)
            {
                var connector = DatabaseController.OpenConnection();
                try
                {
                    SQLiteCommand sqlCommand = connector.CreateCommand();

                    //Monta a consulta
                    sqlCommand.CommandText = "DELETE FROM PAGES WHERE ID = @ID";
                    sqlCommand.Connection = connector;
                    sqlCommand.Parameters.AddWithValue("ID", pages.Id);
                    sqlCommand.ExecuteNonQuery();

                    return true;
                }
                finally
                {
                    DatabaseController.CloseConnection();
                }
            }
        }

        public static PagesModel PageUpdate(PagesModel folder)
        {
            lock (DatabaseController.Lock)
            {
                var connector = DatabaseController.OpenConnection();

                lock (DatabaseController.Lock)
                {
                    try
                    {
                        SQLiteCommand sqlCommand = connector.CreateCommand();

                        //Monta a consulta
                        sqlCommand.CommandText = "UPDATE PAGES SET LAST_UPDATE = @LAST_UPDATE, URL = @URL, AUTO_UPDATE = @AUTO_UPDATE, UPDATE_FREQUENCY= @UPDATE_FREQUENCY, INDEX_POSITION= @INDEX_POSITION WHERE ID = @ID";
                        sqlCommand.Parameters.AddWithValue("@URL", folder.URL);
                        sqlCommand.Parameters.AddWithValue("@AUTO_UPDATE", folder.AutoUpdate);
                        sqlCommand.Parameters.AddWithValue("@UPDATE_FREQUENCY", folder.UpdateFrequency.ToString());
                        sqlCommand.Parameters.AddWithValue("@INDEX_POSITION", folder.IndexPosition);
                        sqlCommand.Parameters.AddWithValue("@ID", folder.Id);
                        sqlCommand.Parameters.AddWithValue("@LAST_UPDATE", folder.LastUpdate);

                        sqlCommand.Connection = connector;
                        sqlCommand.ExecuteNonQuery();

                        return folder;
                    }
                    finally
                    {
                        DatabaseController.CloseConnection();
                    }
                }
            }

        }
    }
}
