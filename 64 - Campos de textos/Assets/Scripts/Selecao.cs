using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; // Importado

public class Selecao : MonoBehaviour {

    public Toggle selecaoNome;
    public InputField digitacaoNome;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void status() {

        if (selecaoNome.isOn == true) {
            digitacaoNome.readOnly = false;
            Debug.Log("Ativo");
        } else {
            digitacaoNome.readOnly = true;
            Debug.Log("Desativado");
        }


    }
}
