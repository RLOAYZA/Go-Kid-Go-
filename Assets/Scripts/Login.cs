using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MySql.Data.MySqlClient;

public class Login : MonoBehaviour
{
    public InputField usuarioTxt;
    public InputField passTxt;
    public LoginErrorScript loginScript;
    public static string userToken;
    public bool error = false;

    public void Logear()
    {
        string _log = "`usuarios` WHERE `usuario` LIKE '" + usuarioTxt.text +
                        "' AND `pass` LIKE '" + passTxt.text + "'";
        AdminMySQL _adminMYSQL = GameObject.Find("AdminDatabase").GetComponent<AdminMySQL>();
        MySqlDataReader Resultado = _adminMYSQL.Select(_log);

        if (Resultado.HasRows)
        {
            while(Resultado.Read()) {
                userToken = Resultado.GetString(0);
            }
            Resultado.Close();
            Debug.Log("Login correcto");
            if ((int)System.DateTime.Now.DayOfWeek == 1) {
                Resultado = _adminMYSQL.ReseteaDias();
                Resultado.Close();
            }
        }
        else
        {
            Debug.Log("Usuario o contrase�a incorrectos");
            error = true;
            Resultado.Close();
        }
    }

    public void ventanaError()
    {
        if(error == true)
        {
            loginScript.Setup();
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    
}
