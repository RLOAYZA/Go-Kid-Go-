using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public int numeroEscena;

    public void escenaLogRegister()
    {
        SceneManager.LoadScene("LogRegister");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Juego finalizado");
    }
}
