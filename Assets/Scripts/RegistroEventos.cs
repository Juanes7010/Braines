using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using UnityEngine;

public class RegistroEventos : MonoBehaviour
{
    public GameObject pickedObject = null;
    public GameObject[] objetos = new GameObject[5];
    public GameObject[] Personas = new GameObject[6];
    public bool chestBand = true;
    bool band = false;
    public bool Level2Completed = false;
    void Start()
    {
        
    }

    void Update()
    {
        //Verifica si en el nivel 1 está completo el array de objetos para darlo por completado y abrir el cofre
        if (objetos.Any(obj => obj == null))
        {
            band = true;
        } else
        {
            band = true;
            chestBand = false;
        }

        //Verifica si el nivel 2 está completado, el array de personas debe estar lleno, eso significa que están ubicadas correctamente
        Level2Completed = !Personas.Any(obj => obj == null);
        //Debug.Log(Level2Completed);
    }
}
