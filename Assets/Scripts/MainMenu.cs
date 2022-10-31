using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PrincipalInicio()
    {
        SceneManager.LoadScene("Inicio");
    }
    public void escenaLogRegister()
    {
        SceneManager.LoadScene("LogRegister");
    }
    public void escenaLogin()
    {
        SceneManager.LoadScene("Login");
    }
    public void escenaRegister()
    {
        SceneManager.LoadScene("Register");
    }
    public void escenaAlphabet()
    {
        SceneManager.LoadScene("Alphabet");
    }
    public void escenaChallenge()
    {
        SceneManager.LoadScene("Challenge");
    }
    public void escenaDifferences()
    {
        SceneManager.LoadScene("Differences");
    }
    public void escenaJuegos()
    {
        SceneManager.LoadScene("Games");
    }
    public void escenaHistory()
    {
        SceneManager.LoadScene("History");
    }
    public void escenaMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void escenaMemory()
    {
        SceneManager.LoadScene("MemoryTest");
    }
    public void escenaProfile()
    {
        SceneManager.LoadScene("Profile");
    }
    public void escenaChallDiff()
    {
        SceneManager.LoadScene("ChallDifferences");
    }
    public void Salir()
    {
        Application.Quit();
    }
}
