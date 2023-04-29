using System;
using System.Data;
using System.Globalization;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine;

namespace Client.Scripts.Services
{
    public class SqlLiteDB : MonoBehaviour
    {
        private const string FileName = "db.bytes";
        private static string _dbPath;
        private static SqliteConnection _connection;
        private static SqliteCommand _command;


        static SqlLiteDB()
        {
            _dbPath = GetDatabasePath();
        }

        /// <summary> Возвращает путь к БД. Если её нет в нужной папке на Андроиде, то копирует её с исходного apk файла. </summary>
        private static string GetDatabasePath()
        {
#if UNITY_EDITOR
            return Path.Combine(Application.streamingAssetsPath, FileName);
#endif
#if UNITY_STANDALONE
            string filePath = Path.Combine(Application.dataPath, fileName);
            if(!File.Exists(filePath)) UnpackDatabase(filePath);
            return filePath;
#endif
#if UNITY_ANDROID
            string filePath = Path.Combine(Application.persistentDataPath, FileName);
            if (!File.Exists(filePath)) UnpackDatabase(filePath);
            return filePath;
#endif
#if UNITY_IOS
            Debug.Log("iOS");
#endif
        }

        /// <summary> Распаковывает базу данных в указанный путь. </summary>
        /// <param name="toPath"> Путь в который нужно распаковать базу данных. </param>
        private static void UnpackDatabase(string toPath)
        {
            string fromPath = Path.Combine(Application.streamingAssetsPath, FileName);

            WWW reader = new WWW(fromPath);
            while (!reader.isDone)
            {
            }

            File.WriteAllBytes(toPath, reader.bytes);
        }

        /// <summary> Этот метод открывает подключение к БД. </summary>
        private static void OpenConnection()
        {
            _connection = new SqliteConnection("Data Source=" + _dbPath);
            _command = new SqliteCommand(_connection);
            _connection.Open();
        }

        /// <summary> Этот метод закрывает подключение к БД. </summary>
        public static void CloseConnection()
        {
            _connection.Close();
            _command.Dispose();
        }

        /// <summary> Этот метод выполняет запрос query. </summary>
        /// <param name="query"> Собственно запрос. </param>
        public static void ExecuteQueryWithoutAnswer(string query)
        {
            OpenConnection();
            _command.CommandText = query;
            _command.ExecuteNonQuery();
            CloseConnection();
        }

        /// <summary> Сохраняем данные объектов мира  </summary>
        public void SaveCellObjectData(string table, int id, string title, int level, Vector3 position)
        {
            float x = position.x;
            float y = position.y;
            float z = position.z;

            OpenConnection();
            string sqlQuery = $"INSERT or IGNORE INTO {table} VALUES ('" + id + "', '" + title + "', '" + level +
                              "','" +
                              x.ToString(CultureInfo.InvariantCulture) + "', '" +
                              y.ToString(CultureInfo.InvariantCulture) + "', '" +
                              z.ToString(CultureInfo.InvariantCulture) + "')";
            ExecuteQueryWithoutAnswer(sqlQuery);
            CloseConnection();
        }

        /// <summary> Обновляем данные объектов мира. </summary>
        public void UpdateCellObjectData(string table, string colum, object data, object place)
        {
            OpenConnection();
            string sqlQuery = $"UPDATE {table} SET {colum} = {data} WHERE ID = {place}";
            ExecuteQueryWithoutAnswer(sqlQuery);
            CloseConnection();
        }

        /// <summary> Сохранияем информацию о ресурсах игры </summary>
        public void SaveResData(string table, int gold, int exp, int diamonds, int level)
        {
            OpenConnection();
            string sqlQuery = $"UPDATE {table} SET Gold = {gold}, Exp = {exp}, Diamond = {diamonds}, Level = {level}";
            ExecuteQueryWithoutAnswer(sqlQuery);
            CloseConnection();
        }

        public int GetRowCount(string table)
        {
            OpenConnection();
            _command.CommandText = $"SELECT count(id) FROM {table}";
            _command.CommandType = CommandType.Text;
            int rowCount;
            rowCount = Convert.ToInt32(_command.ExecuteScalar());
            _command.ExecuteNonQuery();
            CloseConnection();
            return rowCount;
        }

        public DataTable GetTable(string query)
        {
            OpenConnection();

            SqliteDataAdapter adapter = new SqliteDataAdapter(query, _connection);

            DataSet DS = new DataSet();
            adapter.Fill(DS);
            adapter.Dispose();

            CloseConnection();

            return DS.Tables[0];
        }

        public WorldElement GetSqlData(string table, int id)
        {
            WorldElement worldElement = new WorldElement();
            // List<WorldElement> worldElements = new List<WorldElement>();
            OpenConnection();

            _command.CommandText = $"SELECT * FROM {table} WHERE ID = {id}";
            using (var reader = _command.ExecuteReader())
            {
                if (reader.Read())
                {
                    worldElement.Id = reader.GetInt32(0);
                    worldElement.Title = reader.GetString(1);
                    worldElement.Level = reader.GetInt32(2);
                    worldElement.PosX = reader.GetFloat(3);
                    worldElement.PosY = reader.GetFloat(4);
                    worldElement.PosZ = reader.GetFloat(5);
                    // worldElements.Add(worldElement);
                }
            }

            _command.ExecuteNonQuery();
            CloseConnection();
            return worldElement;
        }

        public void DeleteDataFromTable(string table)
        {
            OpenConnection();
            string query = "DELETE FROM WorldElements";
            ExecuteQueryWithoutAnswer(query);
            CloseConnection();
        }
    }

    public class WorldElement
    {
        public int Id;
        public string Title;
        public int Level;
        public float PosX;
        public float PosY;
        public float PosZ;
    }
}