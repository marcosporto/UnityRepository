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

    private PlayerController player; // Objeto criado para acessar o script PlayerControlle

    public GameState currentState;

    public GameObject hudInfoGamePlay, hudTitulo, hudGameOver, hudLoading, hudLoja;
    public Text moedasTxt, faseTxt, moedasMapaTxt, tomatesMapaTxt, tempoTxt, precoPersonagemTxt;
    public int moedas, fase, moedasMapa, tomatesMapa, tempo, moedasColetadas, tomatesColetados, precoPersonagem;


    // Use this for initialization
    void Start () {

        player = FindObjectOfType(typeof(PlayerController)) as PlayerController;

        print("Início do Switch!");
        switch (currentState) {
            
            case GameState.TITULO:
                hudInfoGamePlay .SetActive(false);
                hudTitulo       .SetActive(true);   // Chama a tela principal, ou seja, a tela de título
                hudGameOver     .SetActive(false);
                hudLoading      .SetActive(false);
                hudLoja         .SetActive(false);
                break;

            case GameState.GAMEMPLAY:
                hudInfoGamePlay .SetActive(true);   // Chama a tela de informações do game
                hudTitulo       .SetActive(false);   
                hudGameOver     .SetActive(false);
                hudLoading      .SetActive(false);
                hudLoja         .SetActive(false);

                StartCoroutine("contagemRegressiva");
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
            player.gotHit(); // Chama função do script PlayerController
            gameOver();
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
        tempoTxt.text = tempo.ToString();
        tomatesColetados += 1;
    }

    public void gameOver() {

        currentState = GameState.GAMEOVER;
        hudInfoGamePlay     .SetActive(false);   
        hudGameOver         .SetActive(true);   // Chama a tela de game over
    }


}
