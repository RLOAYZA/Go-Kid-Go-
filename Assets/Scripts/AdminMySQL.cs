using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

public class AdminMySQL : MonoBehaviour
{
    public string servidorBaseDatos;
    public string nombreBaseDatos;
    public string usuarioBaseDatos;
    public string contraseñaBaseDatos;

    private string datosConexion;
    private MySqlConnection conexion;


    void Start()
    {
        datosConexion = "Server=" + "servergokidgo.mysql.database.azure.com"
        + ";Database= " + "gokidgo"
        + ";Uid= " + "Rodrigo14600"
        + ";Pwd= " + "Tesis2022gokidgo"
        + ";Port=" + "3306"
        + ";sslmode = None;";
        //datosConexion = "Server=" + servidorBaseDatos
        //              + ";Database= " + nombreBaseDatos
        //              + ";Uid= " + usuarioBaseDatos
        //              + ";Pwd= " + contrase�aBaseDatos
        //              + ";";
        ConectarServer();
    }

    private void ConectarServer()
    {
        conexion = new MySqlConnection(datosConexion);

        try
        {
            conexion.Open();
            Debug.Log("Conexion exitosa");
        }
        catch(MySqlException error)
        {
            Debug.LogError("Imposible conectar: " + error);
        }
    }

    public MySqlDataReader Select(string _select)
    {
        MySqlCommand cmd = conexion.CreateCommand();
        cmd.CommandText = "SELECT * FROM " + _select;
        MySqlDataReader Resultado = cmd.ExecuteReader();
        return Resultado;
    }

    public MySqlDataReader Insert(string _insert)
    {
        MySqlCommand cmd = conexion.CreateCommand();
        cmd.CommandText = "INSERT INTO " + _insert;
        MySqlDataReader Resultado = cmd.ExecuteReader();
        return Resultado;
    }

    public MySqlDataReader ReseteaDias()
    {
        MySqlCommand cmd = conexion.CreateCommand();
        cmd.CommandText = "DELETE FROM `historial_juego` where `Juego_ID` = '4' and `usuario_id` = '" + Login.userToken + "'";
        MySqlDataReader Resultado = cmd.ExecuteReader();
        return Resultado;
    }
}
