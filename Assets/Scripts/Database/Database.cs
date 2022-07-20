using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;

public class Database : MonoBehaviour
{
    string urlDataBase = "URI=file:MasterSQLite.db";
    private IDbCommand _command;

    private void Start()
    {
        Iniciar();
    }

    void Iniciar()
    {
        IDbConnection _connection = new SqliteConnection(urlDataBase);
        _command = _connection.CreateCommand();
        _connection.Open();

        string sql  = "CREATE TABLE IF NOT EXISTS highscores(name VARCHAR(20), time INT)";

        _command.CommandText = sql;
        _command.ExecuteNonQuery();
    }

    public void Inserir(string nome, int tempo)

    {

        string sql = "INSERT INTO highscores(name, time) VALUES('" + nome + "', " + tempo +")";

        _command.CommandText = sql;

        _command.ExecuteNonQuery();

    }

    public IDataReader Recuperar()
    {
        string sqlQuery = "SELECT * FROM highscores ORDER BY time ASC";

        _command.CommandText = sqlQuery;
        return _command.ExecuteReader();
    }
}
