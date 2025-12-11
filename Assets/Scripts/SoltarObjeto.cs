using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoltarObjeto : MonoBehaviour
{
    [SerializeField] RegistroEventos registroEventos;
    [SerializeField] float distanciaObjetoY = 0.5f;
    [SerializeField] int posicion = 999;
    public bool completado = false;
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
            registroEventos.pickedObject.GetComponent<Rigidbody>().useGravity = true;
            registroEventos.pickedObject.GetComponent<Rigidbody>().isKinematic = false;

            registroEventos.pickedObject.transform.position = new Vector3(
                this.transform.position.x,
                this.transform.position.y + distanciaObjetoY,
                this.transform.position.z
            );
            registroEventos.pickedObject.gameObject.transform.SetParent(this.gameObject.transform);

            switch (posicion)
            {
                case 0:
                    if (posicion == 0 && registroEventos.pickedObject.gameObject.name == "Carne")
                        registroEventos.objetos[0] = registroEventos.pickedObject;
                    else
                        registroEventos.objetos[0] = null;
                    break;
                case 1:
                    if (posicion == 1 && registroEventos.pickedObject.gameObject.name == "Pluma")
                        registroEventos.objetos[1] = registroEventos.pickedObject;
                    else
                        registroEventos.objetos[1] = null;
                    break;
                case 2:
                    if (posicion == 2 && registroEventos.pickedObject.gameObject.name == "Naranja")
                        registroEventos.objetos[2] = registroEventos.pickedObject;
                    else
                        registroEventos.objetos[2] = null;
                    break;
                case 3:
                    if (posicion == 3 && registroEventos.pickedObject.gameObject.name == "Calabaza")
                        registroEventos.objetos[3] = registroEventos.pickedObject;
                    else
                        registroEventos.objetos[3] = null;
                    break;
                case 4:
                    if (posicion == 4 && registroEventos.pickedObject.gameObject.name == "Queso")
                        registroEventos.objetos[4] = registroEventos.pickedObject;
                    else
                        registroEventos.objetos[4] = null;
                    break;
                case 10:
                    if (posicion == 10 && registroEventos.pickedObject.gameObject.name == "Karim")
                        registroEventos.Personas[0] = registroEventos.pickedObject;
                    else
                        registroEventos.Personas[0] = null;
                    break;
                case 11:
                    if (posicion == 11 && registroEventos.pickedObject.gameObject.name == "Rina")
                        registroEventos.Personas[1] = registroEventos.pickedObject;
                    else
                        registroEventos.Personas[1] = null;
                    break;
                case 12:
                    if (posicion == 12 && registroEventos.pickedObject.gameObject.name == "Xavier")
                        registroEventos.Personas[2] = registroEventos.pickedObject;
                    else
                        registroEventos.objetos[2] = null;
                    break;
                case 13:
                    if (posicion == 13 && registroEventos.pickedObject.gameObject.name == "Ana")
                        registroEventos.Personas[3] = registroEventos.pickedObject;
                    else
                        registroEventos.Personas[3] = null;
                    break;
                case 14:
                    if (posicion == 14 && registroEventos.pickedObject.gameObject.name == "John")
                        registroEventos.Personas[4] = registroEventos.pickedObject;
                    else
                        registroEventos.Personas[4] = null;
                    break;
                case 15:
                    if (posicion == 15 && registroEventos.pickedObject.gameObject.name == "Timmy")
                        registroEventos.Personas[5] = registroEventos.pickedObject;
                    else
                        registroEventos.Personas[5] = null;
                    break;
            }
            //for(int i=0; i <= 5;i++)
            //{
            //    if (registroEventos.Personas[i] != null)
            //        Debug.Log(registroEventos.Personas[i].name);
            //}
            //Solo para el nivel 2
            completado = !registroEventos.Personas.Any(obj => obj == null);

            if ( completado)
                StartCoroutine(VolverMenu(10f));
            registroEventos.pickedObject = null;
        }
    }

    IEnumerator VolverMenu(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        SceneManager.LoadScene("MenuVR");
    }
}
