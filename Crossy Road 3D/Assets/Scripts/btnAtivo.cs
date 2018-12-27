using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;   // Name space usado para trabalhar com botões

public class btnAtivo : MonoBehaviour {

	// Use this for initialization
	void Start () {

        // Captura o botão vinculado e seleciona o mesmo
        GetComponent<Button>().Select();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
