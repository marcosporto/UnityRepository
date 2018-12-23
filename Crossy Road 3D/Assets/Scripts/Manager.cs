using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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



    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
