using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMap : MonoBehaviour {

    private Manager manager;

    [Header("Configurações dos Blocos no Cenário")]

    public int tamanhoBloco;            // Determina o tamanho do bloco
    public GameObject[] blocoPrefab;    // Armazena os blocos de grama, estrada etc.
    public int[] ocupaBloco;            // Quantidade de blocos necessário para criar uma estrada dupla (2 blocos), um trilho de trem (3 blocos)
    public bool[] temDecoracao;         // Determina em que bloco pode ter uma decoração
    public bool[] temColetavel;         // Determina em que bloco pode ter um objeto coletável
    public int idBlocoAgua;             // Usado para quando for gerado 2 águas na cena uma vem da direita e outra da esquerda
    public bool spawnAguaLado;          // Determina de que lado a água foi spawnada
    public GameObject blocoChegada;     // Determina o final do game
    public GameObject blocoLimitador;   // Determina que esse bloco seja um limitador do cenário
    public GameObject spawnPrefab;      // Determina qual bloco terá spawn
    public int linhaCena;               // Controla quantas linhas de objetos está sendo inserida na cena

    [Header("Configuração do Mapa")]
    public int blocosLinha;             // Determina quantos blocos será inserido em cada linha. Use número par
    public int quantidadeDeLinhas;      // Determina quantas linhas serão inseridas na cena, independente de quantos blocos são necessários para formá-las
    public int quantidadeLinhasInicioFim; // Determina quantas linhas de grama serão geradas no inínio e no final
    public int quantidadeLimitadores;   // Dermina quantos blocos limitadores serão gerados

    [Header("Blocos de Decorações")]
    public GameObject[] decoracaoPrefab;    //Armazena os prefabs de decoração
    public GameObject[] coletavelPrefab;    //Armazena os prefabs coletáveis
    public string[] nomeColetavel;          //Armazena os nomes dos coletáveis

    public int chanceDecoracao;             // Determina qual é a chance em percentual de uma decoração ser inserida
    public int prioridadeColetavel;         // Determina se primeiro será inserido uma decoração ou um coletável
    public int chanceColetavel;             // Determina se vai ter a moeda ou não

    [Header("Objetos Spawn")]               // Armazena os objetos que serão spawnados
    public GameObject[] bloco0;
    public GameObject[] bloco1;
    public GameObject[] bloco2;
    public GameObject[] bloco3;
    public GameObject[] bloco4;
    public GameObject[] bloco5;

    [Header("Hierarquia Mapa")]             // 
    public Transform blocosJogaveis;
    public Transform blocosLimitadores;
    public Transform blocosDecoracao;
    public Transform blocosColetaveis;




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
