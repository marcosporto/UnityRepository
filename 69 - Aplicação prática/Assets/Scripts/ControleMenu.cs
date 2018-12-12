using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;

using UnityEngine.SceneManagement; // Usado para controlar às cenas

public class ControleMenu : MonoBehaviour {

    public AudioMixer controleSom;


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

    // Sai da aplicação
    public void sair() {
        Application.Quit();
    }
    // Controle do áudio
    public void SetVolume( float volume) {
        // Seta 
        controleSom.SetFloat("Volume", volume);
        Debug.Log("Volume: " + volume);
    }
}
