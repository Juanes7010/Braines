using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemChest : MonoBehaviour
{
    [SerializeField] bool chestOpen;
    [SerializeField] float chestOpenAngleX = -51f;
    [SerializeField] float chestOpenAngleY = -103f;
    [SerializeField] float chestOpenAngleZ = 138f;
    [SerializeField] float chestCloseAngle = 0.0f;
    [SerializeField] float smooth = 3.0f;
    [SerializeField] RegistroEventos registroEventos;

    [SerializeField] AudioClip openchest;
    [SerializeField] AudioClip closechest;

    void Start()
    {
        chestOpen = registroEventos.chestBand;
    }

    void Update()
    {
        chestOpen = registroEventos.chestBand;
        if (chestOpen)
        {
            Quaternion targetRotation = Quaternion.Euler(chestOpenAngleX, chestOpenAngleY, chestOpenAngleZ);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        } else
        {
            Quaternion targetRotation2 = Quaternion.Euler(chestCloseAngle, 0, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Triggerchest")
        {
            AudioSource.PlayClipAtPoint(closechest,transform.position,1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Triggerchest")
        {
            AudioSource.PlayClipAtPoint(openchest, transform.position, 1);
        }
    }
}
