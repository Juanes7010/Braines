using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporizadorObjetos : MonoBehaviour
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
        Btn.SetActive(true);
        Canvas.SetActive(true);
        StartCoroutine(DesactivarDespuesDeTiempo(Canvas, 30f));
    }
    IEnumerator DesactivarDespuesDeTiempo(GameObject obj, float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        obj.SetActive(false);
    }
}
