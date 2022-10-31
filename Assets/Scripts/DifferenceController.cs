using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifferenceController : MonoBehaviour
{
    [SerializeField] private GameObject[] game; 
    [SerializeField] private Transform diferencias, canvas;
    [SerializeField] private Temporizador tiempo;
    [SerializeField] private Text scoreText;
    public int numDiferencias = 0;
    int score = 0;
    public GameObject prueba;
    public WinScript winscript;
    public LoseScript losescript;

    public void perdio()
    {
        losescript.Setup(score);
        Debug.Log("perdio");
    }
    public void gano()
    {
        tiempo.enabled = false;
        winscript.Setup(score);
        Debug.Log("gano");
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
            if (tiempo.tiempo >=120 && tiempo.tiempo <=180)
            {
                score += 200;
            }
            else if (tiempo.tiempo >= 60 && tiempo.tiempo <= 119)
            {
                score += 100;
            }
            else if (tiempo.tiempo >= 0 && tiempo.tiempo <= 59)
            {
                score += 50;
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
