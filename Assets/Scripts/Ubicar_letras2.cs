using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ubicar_letras2 : MonoBehaviour
{
    public Text[] letrar;
    public Button botoon;
    public Color color;
    private void Awake()
    {
        for (int i = 0; i < letrar.Length; i++)
        {
            char valor = Convert.ToChar(UnityEngine.Random.Range(65, 90));
            letrar[i].text = valor.ToString();
        }
       
    }
    public void cambiar_color()
    {
        ColorBlock cb = botoon.colors;
        cb.disabledColor = color;
        botoon.colors = cb;
    }
}
