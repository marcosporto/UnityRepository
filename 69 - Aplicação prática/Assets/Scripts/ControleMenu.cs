using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; // Usado para controlar às cenas

public class ControleMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // Método para chamar uma nova cena
    public void ChamaCena( string nome) {

        SceneManager.LoadScene(nome);

    }
}
