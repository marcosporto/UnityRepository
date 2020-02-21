using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Zumbi")
        {
            Debug.Log("Clicou no botão de TIRO!!!");
            Destroy(other.gameObject);
        }
    }
}
