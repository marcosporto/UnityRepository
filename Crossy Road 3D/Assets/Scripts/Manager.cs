using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement; // Necessário para trabalhar com o objeto scene

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


    [Header("Seleção Personagem")]
    public Mesh[] skimPersonagem; // Usado para realizar às mudanças de skins dos personagens
    private MeshFilter meshPersonagem; // Usado para trabalhar com malhas
    private int idPersonagem; // Os ids determinam qual personagem foi escolhido



    // Use this for initialization
    void Start () {

        player = FindObjectOfType(typeof(PlayerController)) as PlayerController;

        meshPersonagem = player.GetComponentInChildren<MeshFilter>(); // Acessando o Mesh Filter do personagem

        // Captura o id que vinculado à skim que foi salva anteriormente, no momento de escolha das skins
        idPersonagem = PlayerPrefs.GetInt("idPersonagemAtual");

        meshPersonagem.mesh = skimPersonagem[idPersonagem]; // Seta uma nova skim para o personagem

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

        if(currentState == GameState.TITULO) { // Se o estado corrente dor TITULO

            if (Input.GetKeyDown(KeyCode.Return)) { // Se o botão ENTRE for clicado

                hudLoading.SetActive(true); // Ativa a tela de loading
                // Carrega a cena principal do game
                SceneManager.LoadSceneAsync("ScenePrincipal");
            }

            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                selecionarPersonagem(1);

            } else if (Input.GetKeyDown(KeyCode.LeftArrow)){
                selecionarPersonagem(-1);
            }
        }
		
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

    public void jogarNovamente() {

        hudLoading.SetActive(true); // Mostra à cena de Loading antes de carregar à cena abaixo
        // Captura o nome da cena ativa
        // A cena é carregada em backgroud, ou seja, a nova cena é exibida somente quando for finalizado o seu carregamento
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        //SceneManager.LoadSceneAsync("ScenePrincipal"); // A cena é carregada em backgroud, ou seja, a nova cena é exibida somente quando for finalizado o carregamento
        //SceneManager.LoadScene("ScenePrincipal");   // Faz a carga da scene passada como parâmetro instantaneamente

    }

    public void voltarTitulo() {

        hudLoading.SetActive(true); // Ativa a tela de loading
        // Carrega a cena chamda TITULO
        SceneManager.LoadSceneAsync("Titulo");
    }

    public void sair() {

        // Fecha a aplicação
        Application.Quit();
    }

    void selecionarPersonagem(int i) {

        idPersonagem += i;

        if (idPersonagem >= skimPersonagem.Length) { idPersonagem = 0;   }
        else if(idPersonagem < 0) { idPersonagem = skimPersonagem.Length - 1; }

        meshPersonagem.mesh = skimPersonagem[idPersonagem];

        // Grava internamente o valor inteiro passado na variável chamada idPersonagemAtual
        PlayerPrefs.SetInt("idPersonagemAtual", idPersonagem);
        
    }


}
