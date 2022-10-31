using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    [SerializeField] private Text timeText;
    [Range(0, 600)] public float tiempo;

    private void Update()
    {
        if(tiempo > 0)
        {
            tiempo -= Time.deltaTime;
        }
        else
        {
            tiempo = 0;
        }

        float min = Mathf.FloorToInt(tiempo / 60);
        float seg = Mathf.FloorToInt(tiempo % 60);

        timeText.text = "Tiempo:" + string.Format("{0:00}:{1:00}", min, seg);
    }


}
