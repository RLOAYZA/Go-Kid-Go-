using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Register : MonoBehaviour
{
    public InputField usuarioTxt;
    public InputField passTxt;
    public InputField nombresTxt;
    public InputField apellidosTxt;
    public TextMeshProUGUI fecha;
    public LoginErrorScript loginScript;
    public bool error = false;


    public void RegistrarUsuario()
    {
        string _log = "`usuarios` WHERE `usuario` LIKE '" + usuarioTxt.text + "'";
        AdminMySQL _adminMYSQL = GameObject.Find("AdminDatabase").GetComponent<AdminMySQL>();
        MySqlDataReader Resultado = _adminMYSQL.Select(_log);

        if (Resultado.HasRows)
        {
            Debug.Log("El usuario ya existe");
            error = true;
            Resultado.Close();
        }
        else
        {
            //_log = "`usuarios` (`usuario`, `pass`, `nombres`, `apellidos`, `fecha`) VALUES (" +
            //    usuarioTxt.text + "', '" + passTxt.text + "', '" + nombresTxt.text + "', '" + apellidosTxt.text + "', '" +
            //    fechaTxt.text + "')";
            Resultado.Close();
            _log = $"usuarios (usuario, pass, nombres, apellidos, fecha) VALUES('{usuarioTxt.text}', '{passTxt.text}', '{nombresTxt.text}', '{apellidosTxt.text}', '{fecha.text}');";
            Resultado = _adminMYSQL.Insert(_log);
            Debug.Log("El nuevo usario ha sido creado");
            Resultado.Close();
        }
    }
    public void ventanaError()
    {
        if (error == true)
        {
            loginScript.Setup();
        }
        else
        {
            SceneManager.LoadScene("Login");
        }
    }
}
