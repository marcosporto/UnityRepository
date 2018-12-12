using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;

using UnityEngine.SceneManagement; // Usado para controlar às cenas

public class ControleMenu : MonoBehaviour {

    public AudioMixer AudioMixerSom;
    
    // Método para chamar uma nova cena
    public void ChamaCena( string nome) {
        SceneManager.LoadScene(nome);
    }

    // Sai da aplicação
    public void sair() {
        Application.Quit();
    }

    // Método para controle de áudio
    // No movimento do Slider é passado o volume que é do tipo float
    public void SetVolume( float volume) {
        // No AudioMixer é setado o valor recebido pelo Slider
        AudioMixerSom.SetFloat("Volume", volume);
        Debug.Log("Volume: " + volume);
    }
}
