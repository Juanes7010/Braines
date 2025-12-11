using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirBloqueo : MonoBehaviour
{
    [SerializeField] RegistroEventos registroEventos;
    void Start()
    {

    }

    void Update()
    {

    }

    public void OnPointerClickXR()
    {
        if (registroEventos.pickedObject != null)
        {
            if (registroEventos.pickedObject.gameObject.name == "Llave")
            {
                registroEventos.pickedObject.gameObject.SetActive(false);
                this.gameObject.SetActive(false );
            }

            registroEventos.pickedObject = null;
        }
    }
}
