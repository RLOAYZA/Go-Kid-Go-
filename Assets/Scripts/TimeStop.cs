using System;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TimeStop : MonoBehaviour
{
    public GameObject botoncito;
    // Start is called before the first frame update
    public void Pausar()
    {
        Time.timeScale = 0;
        botoncito.SetActive(true);
    }
    public void Continuar()
    {
        Time.timeScale = 1;
        botoncito.SetActive(false);
    }
}
