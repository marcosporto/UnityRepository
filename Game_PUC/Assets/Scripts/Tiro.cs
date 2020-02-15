using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public GameObject municaoPrefab;
    public Transform posicaoDaArma;
    public float velocidadeMunicao;

    // Update is called once per frame
    void Update()
    {
        //Touch touch = Input.GetTouch(0);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (!IsInvoking("InstantiateMunicao")) {

                InvokeRepeating("InstantiateMunicao", 0f, 1f);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space)) {

            CancelInvoke("InstantiateMunicao");
        }
    }

    void InstantiateMunicao() {

        if(municaoPrefab != null) {

            GameObject municaoTemporaria = Instantiate(municaoPrefab) as GameObject;
            municaoTemporaria.transform.position = posicaoDaArma.position;
            municaoTemporaria.GetComponent<Rigidbody>().velocity = transform.parent.forward * velocidadeMunicao;
        }
    }
}
