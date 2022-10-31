using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class CheckReto : MonoBehaviour
{
    public Image img0, img02, img1, img12, img2, img22, img3,img32, img4, img42, img5, img52, img6, img62;
    public bool flag;
    void Start()
    {
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {   if (flag == false) {
        img0.enabled = false;
        img02.enabled = true;
        img1.enabled = false;
        img12.enabled = true;
        img2.enabled = false;
        img22.enabled = true;
        img3.enabled = false;
        img32.enabled = true;
        img4.enabled = false;
        img42.enabled = true;
        img5.enabled = false;
        img52.enabled = true;
        img6.enabled = false;
        img62.enabled = true;
        string _log = "`historial_juego` WHERE `usuario_id` = '" + Login.userToken + "' AND `Juego_ID` = '" + 4 + "'";
        AdminMySQL _adminMYSQL = GameObject.Find("AdminDatabase").GetComponent<AdminMySQL>();
        MySqlDataReader ResultadoImage = _adminMYSQL.Select(_log);

        if (ResultadoImage.HasRows)
        {
            List<string> challenges1 = new List<string>();
            while(ResultadoImage.Read()) {
                if ((int)ResultadoImage.GetValue(2) == 4) {
                challenges1.Add((string)ResultadoImage.GetString(3));
               }
            }
            string[] terms = challenges1.ToArray();
            for (int i = 0; i < terms.Length; i++) {
                DateTime oDate = DateTime.ParseExact(terms[i], "dd-MM-yyyy", null);
                Debug.Log("Fecha: " + (int)oDate.DayOfWeek);
                switch ((int)oDate.DayOfWeek) {
                    case 0:
                        img0.enabled = true;
                        img02.enabled = false;
                        break;
                    case 1:
                        img1.enabled = true;
                        img12.enabled = false;
                        break;
                    case 2:
                        img2.enabled = true;
                        img22.enabled = false;
                        break;
                    case 3:
                        img3.enabled = true;
                        img32.enabled = false;
                        break;
                    case 4:
                        img4.enabled = true;
                        img42.enabled = false;
                        break;
                    case 5:
                        img5.enabled = true;
                        img52.enabled = false;
                        break;
                    case 6:
                        img6.enabled = true;
                        img62.enabled = false;
                        break;
                    default:
                        break;
                }
            }
            Debug.Log("Historial correcto");
            ResultadoImage.Close();
        }
        else {
            Debug.Log("No hay registro de retos.");
            ResultadoImage.Close();
        }
        flag = true;
     }
    }
}
