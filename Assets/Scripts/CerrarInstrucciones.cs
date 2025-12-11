using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarInstrucciones : MonoBehaviour
{
    [SerializeField] GameObject Btn;
    [SerializeField] GameObject Canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClickXR()
    {
        Btn.SetActive(false);
        Canvas.SetActive(false);
    }
}
