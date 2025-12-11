using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemDoor : MonoBehaviour
{
    [SerializeField] bool doorOpen = false;
    [SerializeField] float doorOpenAngle = 95f;
    [SerializeField] float doorCloseAngle = 0.0f;
    [SerializeField] float smooth = 3.0f;

    [SerializeField] AudioClip openDoor;
    [SerializeField] AudioClip closeDoor;

    void Start()
    {
        
    }

    void Update()
    {
        if (doorOpen)
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        } else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TriggerDoor")
        {
            AudioSource.PlayClipAtPoint(closeDoor,transform.position,1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "TriggerDoor")
        {
            AudioSource.PlayClipAtPoint(openDoor, transform.position, 1);
        }
    }

    public void OnPointerClickXR()
    {
        if (!doorOpen)
        {
            doorOpen = true;
        } else
        {
            doorOpen = false;
        }
    }
}
