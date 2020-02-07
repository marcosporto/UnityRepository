using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeguir : MonoBehaviour
{
    // Câmera deve seguir o player

    public GameObject objetoRecebido;
    public float velocidadeDaCamera;

    void Update()
    {
        if(objetoRecebido != null) {

            transform.position = Vector3.Lerp( transform.position,
                                               objetoRecebido.transform.position,
                                               Time.deltaTime * velocidadeDaCamera);
        }

        
    }
}
