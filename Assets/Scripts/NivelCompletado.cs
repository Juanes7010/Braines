using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NivelCompletado : MonoBehaviour
{
    public string NameScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        // Verifica que sea el jugador por tag
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(NameScene);
        }
    }
}
