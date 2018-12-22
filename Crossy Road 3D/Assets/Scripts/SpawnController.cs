using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    
    public List<GameObject> veiculos; // Criando uma lista de objetos
    public bool esquerda; // Determina de que lado o carro será espaunado

    public int nCarros, nCarrosMax;
    public float delayEntreCarros;
    public float delayEntreSpawns;

    public float minSpeed, maxSpeed, moveSpeed;
    
    // Use this for initialization
    void Start () {

        moveSpeed = Random.Range(minSpeed, maxSpeed) * -1;
        nCarros = Random.Range(1, nCarrosMax + 1);
        StartCoroutine("spawns");
    }

    // Criação de uma co-rotina
    // Função que é chamada, porém pode ser interrompida antes de sua finalização
    // Obrigatório ter um retorno dna função
    IEnumerator spawns() {

        for (int i = 0; i < nCarros; i++) {


            int id = Random.Range(0, veiculos.Count); // Faz o sorteio de qual veículo será lançado
                                                      // Captura da pasta prefab e jona o objeto na cena
            GameObject tempVeiculo = Instantiate(
                veiculos[id], // Posição que será pega
                transform.position, // Posição que está
                transform.rotation); // Rotação que está
            // Faz com que os veículos spawnados sejam filhos do objeto que está spawnando esses objetos
            tempVeiculo.transform.parent = transform;
            // Captura o script Mover e atribui seta um valor para variável moveSpeed
            tempVeiculo.GetComponent<Mover>().moveSpeed = moveSpeed;
            // Rotaciona o objeto em 180, virando assim, ele para o outro lado
            if (esquerda) { tempVeiculo.transform.rotation = Quaternion.Euler(0, 180, 0); }
            // Comando de retorno da corotina, que é executado após passar o tempo da variável delayEntreCarros
            yield return new WaitForSeconds(delayEntreCarros);
        }
        // Define em quanto tempo novos carros serão espaunados novamente
        yield return new WaitForSeconds(delayEntreSpawns);
        // Em todo novo spawn de veículos o números de carros spawnados é alterado
        nCarros = Random.Range(1, nCarrosMax + 1);
        StartCoroutine("spawns");
    }
	
}
