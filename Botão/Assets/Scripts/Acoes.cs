using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acoes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}	
	// Update is called once per frame
	void Update () {
		
	}
    public void BotaoJogar() {
        Debug.Log("Botão jogar foi clicado!");
    }
    public void BotaoLoja() {
        Debug.Log("Botão loja foi clicado!");
    }
    public void BotaoConquistas() {
        Debug.Log("Botão conquistas foi clicado!");
    }
    public void BotaoConfig() {
        Debug.Log("Botão configuraçoes foi clicado!");
    }
    public void BotaoSair() {
        Debug.Log("Botão sair foi clicado!");
        // Fecha a aplicação
        Application.Quit();
    }
}
