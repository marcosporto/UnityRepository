using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Importação de nameSpace
using UnityEngine.UI;

public class Mensagem : MonoBehaviour {

    public Text txt;
    public InputField inputName; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MostraMesagem() {

        txt.text = "Seja bem vindo(a): " + inputName.text;
    }
}
