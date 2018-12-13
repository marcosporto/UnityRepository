using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Cronometro : MonoBehaviour {

    public float _tempoInicial = 0;
    public Text _cronometro;
    public Text _textoBotao;

    bool _cronometroAtivo = false;

	// Use this for initialization
	void Start () {

        _cronometro.text = _tempoInicial.ToString("F2") + "m"; // Formatação para 2 campos
	}
	
	// Update is called once per frame
	void Update () {

        if (_cronometroAtivo) {

            _tempoInicial += Time.deltaTime;
            _cronometro.text = _tempoInicial.ToString("F2") + "m";
        }		
	}
    public void BotaoTempo() {

        _cronometroAtivo = !_cronometroAtivo;
        // Recurso do C#: cria uma condição, se for verdadeira armazena o primeiro texto, e se for falsa, armazena o segundo
        _textoBotao.text = _cronometroAtivo ? "Pausar" : "Iniciar";
    }
}
