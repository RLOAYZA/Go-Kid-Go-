using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public const int columns = 6;
    public const int rows = 2;

    public const float Xspace = 2.5f;
    public const float Yspace = -3.5f;

    [SerializeField] private MainImageScript startObject;
    [SerializeField] private Sprite[] images;
    public WinScript winscript;
    public LoseScript losescript;

    private int[] Randomizer(int[] locations)
    {
        int[] array = locations.Clone() as int[];
        for (int i = 0; i < array.Length; i++)
        {
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }
        return array;
    }

    private void Start()
    {
        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
        locations = Randomizer(locations);

        Vector3 startPosition = startObject.transform.position;

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                MainImageScript gameImage;
                if (i == 0 && j == 0)
                {
                    gameImage = startObject;
                }
                else
                {
                    gameImage = Instantiate(startObject) as MainImageScript;
                }
                int index = j * columns + i;
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                float positionX = (Xspace * i) + startPosition.x;
                float positionY = (Yspace * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
            }
        }
    }

    private MainImageScript firstOpen;
    private MainImageScript secondOpen;

    private int score = 0;
    private int contador = 0;
    private int min = 3, seg;
    private float restante;
    private bool enMarcha;

    private void Awake()
    {
        restante = (min * 60) + seg;
        enMarcha = true;
    }

    private void Update()
    {
        if (enMarcha)
        {
            restante -= Time.deltaTime;
            if (restante < 1)
            {
                enMarcha = false;
                losescript.Setup(score);
            }
            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            timeText.text = string.Format("Tiempo: {0:00}:{1:00}", tempMin, tempSeg);
            if (contador == 6)
            {
                winscript.Setup(score);
                enMarcha = false;
            }
        }
    }

    [SerializeField] private Text scoreText;
    [SerializeField] private Text timeText;

    public bool canOpen
    {
        get { return secondOpen == null; }
    }

    public void imageOpened(MainImageScript startObject)
    {
        if (firstOpen == null)
        {
            firstOpen = startObject;
        }
        else
        {
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }
    }
    private IEnumerator CheckGuessed()
    {
        if (firstOpen.spriteId == secondOpen.spriteId)
        {
            if (restante >= 120 && restante <= 180)
            {
                score = score + 200;
            }
            else
            {
                if (restante >= 60 && restante <= 119)
                {
                    score = score + 100;
                }
                else
                {
                    score = score + 50;
                }
            }
            contador++;
            scoreText.text = "Puntaje: " + score;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            firstOpen.Close();
            secondOpen.Close();
        }

        firstOpen = null;
        secondOpen = null;
    }
    public void Restart()
    {
        SceneManager.LoadScene("MemoryTest");
    }
}
