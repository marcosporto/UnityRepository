using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teclado : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Aciona quando a tecla é pressionada
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Tecla espaço foi pressionada!");
        }
        // Aciona quando a tecla é solta
        if (Input.GetKeyUp(KeyCode.Space)) {
            Debug.Log("Tecla espaço foi liberada!");
        }
    }
}
