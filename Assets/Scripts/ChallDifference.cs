using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChallDifference : MonoBehaviour
{
    public LoginErrorScript loginScript;
    public bool error = false;
    [SerializeField] private GameObject[] game; 
    [SerializeField] private Transform diferencias, canvas;
    [SerializeField] private Temporizador tiempo;
    [SerializeField] private Text scoreText;
    public int numDiferencias = 0;
    int score = 0;
    public Login id;
    public GameObject prueba;
    public WinScript winscript;
    public LoseScript losescript;

    public void perdio()
    {
        losescript.SetupChall();
        Debug.Log("Perdió");
    }
    public void gano()
    {
        if (tiempo.tiempo >=61 && tiempo.tiempo <=120)
            {
                score += 200;
            }
        else if (tiempo.tiempo >= 1 && tiempo.tiempo <= 60)
            {
                score += 100;
            }
        int hours;
        int minutes;
        int seconds;
        seconds = (int)tiempo.tiempo;
        hours = (int)(System.Math.Floor((double)(seconds / 3600)));
        seconds = seconds % 3600;
        minutes = (int)(System.Math.Floor((double)(seconds / 60)));
        seconds = seconds % 60;
        tiempo.enabled = false;
        AdminMySQL _adminMYSQL = GameObject.Find("AdminDatabase").GetComponent<AdminMySQL>();
        string _log = $"Historial_Juego (usuario_id, Juego_ID, Juego_Date, Juego_Score, Juego_Time) VALUES('{Login.userToken}', '{2}', '{System.DateTime.Now.ToString("dd-MM-yyyy")}', '{score}', '{minutes + ":" + seconds}');";
        MySqlDataReader Resultado = _adminMYSQL.Insert(_log);
        Resultado.Close();
        Debug.Log("Ganó");
        SceneManager.LoadScene("ChallMemory");
    }

    private void Awake()
    {
        int random = Random.Range(0, game.Length);
        game[random].SetActive(true);
        diferencias = game[random].transform;
        prueba = diferencias.GetChild(0).gameObject;
        numDiferencias = diferencias.GetChild(0).transform.childCount;
    }

    private void Update()
    {
        if (diferencias.GetChild(0).transform.childCount <= 0)
        {
            gano();
        }
        if (tiempo.tiempo == 0)
        {
            perdio();
        }
        if (numDiferencias != diferencias.GetChild(0).transform.childCount)
        {
            if (tiempo.tiempo >=61 && tiempo.tiempo <=120)
            {
                score += 200;
            }
            else if (tiempo.tiempo >= 1 && tiempo.tiempo <= 60)
            {
                score += 100;
            }
            scoreText.text = "Puntaje: " + score;
            numDiferencias = diferencias.GetChild(0).transform.childCount;
            return;
        }
        else
        {
            return;
        }
    }
}
