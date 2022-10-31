using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class control_puntaje_sopa : MonoBehaviour
{
    int escuela_numero, pelota_numero, gato_numero, carro_numero, casa_numero, lapiz_numero = 0;
    int palabra = 0;
    public Text puntuacion;
    public Text tiempo;
    [SerializeField] private Temporizador tempo;
    public WinScript winscript;
    public LoseScript losescript;
    [SerializeField] private GameObject[] game;
    [SerializeField] private Transform alfabeto, canvas;
    private void Awake()
    {
        int random = UnityEngine.Random.Range(0, game.Length);
        game[random].SetActive(true);
        alfabeto = game[random].transform;
    }
    public void Validador_Escuela(string Letra) {
        switch (Letra)
        {
            case "E1":
                escuela_numero++;
                break;
            case "E2":
                escuela_numero++;
                break;
            case "E3":
                escuela_numero++;
                break;
            case "E4":
                escuela_numero++;
                break;
            case "E5":
                escuela_numero++;
                break;
            case "E6":
                escuela_numero++;
                break;
            case "E7":
                escuela_numero++;
                break;
        }

        if (escuela_numero == 7) {
            Asignar_Puntuacion();
            palabra++;
            gano();
            perdio();
        }
    }
    public void Validador_Pelota(string Letra)
    {
        switch (Letra)
        {
            case "P1":
                pelota_numero++;
                break;
            case "P2":
                pelota_numero++;
                break;
            case "P3":
                pelota_numero++;
                break;
            case "P4":
                pelota_numero++;
                break;
            case "P5":
                pelota_numero++;
                break;
            case "P6":
                pelota_numero++;
                break;
        }

        if (pelota_numero == 6)
        {
            Asignar_Puntuacion();
            palabra++;
            gano();
            perdio();
        }
    }
    public void Validador_Gato(string Letra)
    {
        switch (Letra)
        {
            case "G1":
                gato_numero++;
                break;
            case "G2":
                gato_numero++;
                break;
            case "G3":
                gato_numero++;
                break;
            case "G4":
                gato_numero++;
                break;
        }

        if (gato_numero == 4)
        {
            Asignar_Puntuacion();
            palabra++;
            gano();
            perdio();
        }
    }
    public void Validador_Casa(string Letra)
    {
        switch (Letra)
        {
            case "C1":
                casa_numero++;
                break;
            case "C2":
                casa_numero++;
                break;
            case "C3":
                casa_numero++;
                break;
            case "C4":
                casa_numero++;
                break;
        }

        if (casa_numero == 4)
        {
            Asignar_Puntuacion();
            palabra++;
            gano();
            perdio();
        }
    }
    public void Validador_Lapiz(string Letra)
    {
        switch (Letra)
        {
            case "L1":
                lapiz_numero++;
                break;
            case "L2":
                lapiz_numero++;
                break;
            case "L3":
                lapiz_numero++;
                break;
            case "L4":
                lapiz_numero++;
                break;
            case "L5":
                lapiz_numero++;
                break;
        }

        if (lapiz_numero == 5)
        {
            Asignar_Puntuacion();
            palabra++;
            gano();
            perdio();
        }
    }
    public void Validador_Carro(string Letra)
    {
        switch (Letra)
        {
            case "A1":
                carro_numero++;
                break;
            case "A2":
                carro_numero++;
                break;
            case "A3":
                carro_numero++;
                break;
            case "A4":
                carro_numero++;
                break;
            case "A5":
                carro_numero++;
                break;
        }

        if (carro_numero == 5)
        {
            Asignar_Puntuacion();
            palabra++;
            gano();
            perdio();
        }
    }

    public string Asignar_Puntuacion()
    {
        int p = int.Parse(puntuacion.text);
        string t = tiempo.text;
        string[] divisor = t.Split(':');
        if (divisor[1]=="02") puntuacion.text = (200 + p ) + "";
        if (divisor[1] == "01") puntuacion.text = (100 + p) +  "";
        if (divisor[1] == "00") puntuacion.text = (50 + p) + "";
        return puntuacion.text;
    }

    public void perdio()
    {
        if(tempo.tiempo == 0)
        {
            int score = Int32.Parse(puntuacion.text);
            losescript.Setup(score);
            Debug.Log("perdio");
        }
    }
    public void gano()
    {
        if (palabra == 6)
        {
            int score = Int32.Parse(puntuacion.text);
            winscript.Setup(score);
            Debug.Log("gano");
            tempo.enabled = false;
        }
    }
}
