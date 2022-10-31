using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class History : MonoBehaviour
{

    public GameObject userInfoContainer;
    public GameObject userInfoTemplate;
    // Start is called before the first frame update
    void Start()
    {
        string _log = "`historial_juego` WHERE `usuario_id` = '" + Login.userToken + "'";
        AdminMySQL _adminMYSQL = GameObject.Find("AdminDatabase").GetComponent<AdminMySQL>();
        MySqlDataReader Resultado = _adminMYSQL.Select(_log);

        if (Resultado.HasRows)
        {
            List<string> history = new List<string>();
            List<string> history2 = new List<string>();
            List<string> history3 = new List<string>();
            while(Resultado.Read()) {
                if ((int)Resultado.GetValue(2) != 4) {
                history.Add((string)Resultado.GetString(5));
                if((int)Resultado.GetValue(2) == 1) {
                    history2.Add("Memory Cards");
                }
                if((int)Resultado.GetValue(2) == 2) {
                    history2.Add("Find the Differences");
                }
                if((int)Resultado.GetValue(2) == 3) {
                    history2.Add("Alphabet Soup");
                }
                history3.Add((string)Resultado.GetString(3));
               }
            }
            string[] terms = history.ToArray();
            string[] terms2 = history2.ToArray();
            string[] terms3 = history3.ToArray();
            for (int i = 0; i < terms.Length; i++) {
                Debug.Log("Juego: " + terms2[i] + "Día: " + terms3[i] + "Tiempo: " + terms[i]);

                GameObject gobj = (GameObject)Instantiate(userInfoTemplate);
                gobj.transform.SetParent(userInfoContainer.transform);

                gobj.GetComponent<UserInfo>().Juego.text = terms2[i];

                gobj.GetComponent<UserInfo>().Dia.text = terms3[i];

                gobj.GetComponent<UserInfo>().Tiempo.text = terms[i];

            }
            Debug.Log("Historial correcto");
            Resultado.Close();
        }
        else {
            Debug.Log("error");
            Resultado.Close();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
