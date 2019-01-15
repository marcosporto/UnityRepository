using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Máquina de estado
public enum GameState {

    TITULO,
    GAMEMPLAY,
    GAMEOVER,
    FASECONCLUIDA
}


public class Manager : MonoBehaviour {

    public GameState currentState;

    public GameObject hudInfoGamePlay, hudTitulo, hudGameOver, hudLoading, hudLoja;
    public Text moedasTxt, faseTxt, moedasMapaTxt, tomatesMapaTxt, tempoTxt;
    public int moedas, fase, moedasMapa, tomatesMapa, tempo, moedasColetadas, tomatesColetados;


    // Use this for initialization
    void Start () {

        print("Início do Switch!");
        switch (currentState) {
            
            case GameState.TITULO:
                print("GameState.TITULO!");
                break;

            case GameState.GAMEMPLAY:
                StartCoroutine("contagemRegressiva");
                print("GameState.GAMEMPLAY!!!");
                break;
        }
        //currentState = GameState.FASECONCLUIDA;


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Corrotina é chamada de 1 em 1 segundo
    IEnumerator contagemRegressiva() {

        tempoTxt.text = tempo.ToString();
        yield return new WaitForSeconds(1);
        tempo -= 1;
        if(tempo == 0) {
            currentState = GameState.GAMEOVER;
        }

        if (currentState == GameState.GAMEMPLAY) {

            // Chama a corrotina novamente
            StartCoroutine("contagemRegressiva");
        }
    }

    // Método chamado pelo script vinculado ao personagem
    public void atualizarMoedas(int valor) {

        moedas += valor;
        moedasTxt.text = moedas.ToString();
        moedasColetadas += 1;
    }
    
    // Método chamado pelo script vinculado ao personagem
    public void atualizarTempo(int valor) {

        tempo += valor;
        moedasTxt.text = tempo.ToString();
        tomatesColetados += 1;
    }


}
