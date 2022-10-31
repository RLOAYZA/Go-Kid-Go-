using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour
{
    public Transform target;
    private float velocidadX = 100;
    void Update()
    {
        target.Translate(velocidadX * Time.deltaTime, 0, 0);
        if (target.localPosition.x > 1200)
            target.Translate(-3750, 0, 0);
    }
}
