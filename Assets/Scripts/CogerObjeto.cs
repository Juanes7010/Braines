using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerObjeto : MonoBehaviour
{
    [SerializeField] GameObject handPoint;

    [SerializeField] RegistroEventos registroEventos;
    void Update()
    {
        
    }

    public void OnPointerClickXR()
    {
        if (registroEventos.pickedObject == null)
        {
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().isKinematic = true;

            this.transform.position = handPoint.transform.position;
            this.gameObject.transform.SetParent(handPoint.gameObject.transform);
            registroEventos.pickedObject = this.gameObject;
        }
    }
}
