using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nivel2Completado : MonoBehaviour
{
    [SerializeField] RegistroEventos registroEventos;
    [SerializeField] GameObject Canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(registroEventos.Level2Completed)
            StartCoroutine(VolverMenu(10f));
    }

    IEnumerator VolverMenu(float tiempo)
    {
        Canvas.SetActive(true);
        yield return new WaitForSeconds(tiempo);
    }
}
