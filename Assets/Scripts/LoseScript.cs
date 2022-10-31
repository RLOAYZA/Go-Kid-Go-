using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{
    public Text pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "Puntaje: " + score.ToString();
    }
    public void SetupChall()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Differences");
    }
    public void RestartMemoryButton()
    {
        SceneManager.LoadScene("MemoryTest");
    }
    public void RestartAlphabetButton()
    {
        SceneManager.LoadScene("Alphabet");
    }
    public void ExitButton()
    {
        SceneManager.LoadScene("Games");
    }


}
