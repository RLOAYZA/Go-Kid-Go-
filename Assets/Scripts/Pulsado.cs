using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pulsado : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject pantalla;
    [SerializeField] private RectTransform auxpantalla;
    [SerializeField] private RectTransform posicionInicial;
    [SerializeField] private Sprite encontrado;
    [HideInInspector] public bool pulsado;
    [SerializeField] private RawImage imagen;

    private void Awake()
    {
        imagen = GetComponent<RawImage>();
        pantalla = GameObject.FindGameObjectWithTag("UI");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pulsado = true;
        transform.SetParent(pantalla.transform);
        imagen.texture = encontrado.texture;
        imagen.color = new Color(255, 255, 255, 255);
        //auxpantalla.localScale = new Vector3(0.2f, 0.2f, 1f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pulsado = false;

    }


}
