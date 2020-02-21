using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDeTiro : MonoBehaviour
{
    public bool mouseDentroDoObjeto;
    public bool deuTiro;
    GameObject zumbi;
    
    void Start()
    {
        mouseDentroDoObjeto = false;
        deuTiro = false;
        zumbi = GameObject.FindWithTag("AreaDeClique");
    }

    void Update()
    {
        if(deuTiro == true)
        {
            Destroy(zumbi);
            deuTiro = false;
        }

    }

    private void OnMouseEnter()
    {
        mouseDentroDoObjeto = true;
        GetComponent<Light>().enabled = false;
       // Destroy(gameObject);
    }

    private void OnMouseExit()
    {
        mouseDentroDoObjeto = false;
        GetComponent<Light>().enabled = true;
    }

    private void OnMouseDown()
    {
        if (mouseDentroDoObjeto == true)
        {
            deuTiro = true;
        }
            
        
    }
}
