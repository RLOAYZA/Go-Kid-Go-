using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChallMemoryController : MonoBehaviour
{
    public const int columns = 6;
    public const int rows = 2;

    public const float Xspace = 2.5f;
    public const float Yspace = -3.5f;

    [SerializeField] private ChallMainImage startObject;
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
                ChallMainImage gameImage;
                if (i == 0 && j == 0)
                {
                    gameImage = startObject;
                }
                else
                {
                    gameImage = Instantiate(startObject) as ChallMainImage;
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

    private ChallMainImage firstOpen;
    private ChallMainImage secondOpen;

    private int score = 0;
    private int contador = 0;
    private int min = 2, seg;
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
                losescript.SetupChall();
            }
            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            timeText.text = string.Format("Tiempo: {0:00}:{1:00}", tempMin, tempSeg);
            if (contador == 6)
            {
                AdminMySQL _adminMYSQL = GameObject.Find("AdminDatabase").GetComponent<AdminMySQL>();
                string _log = $"Historial_Juego (usuario_id, Juego_ID, Juego_Date, Juego_Score, Juego_Time) VALUES('{Login.userToken}', '{1}', '{System.DateTime.Now.ToString("dd-MM-yyyy")}', '{score}', '{tempMin+":"+tempSeg}');";
                MySqlDataReader Resultado = _adminMYSQL.Insert(_log);
                Resultado.Close();
                Debug.Log("Ganó");
                SceneManager.LoadScene("ChallAlphabet");
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

    public void imageOpened(ChallMainImage startObject)
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
            if (restante >= 61 && restante <= 120)
            {
                score = score + 200;
            }
            else
            {
                if (restante >= 1 && restante <= 60)
                {
                    score = score + 100;
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
        SceneManager.LoadScene("ChallMemory");
    }
}
