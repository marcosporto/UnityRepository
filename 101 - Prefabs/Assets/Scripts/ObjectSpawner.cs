using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    [Header("Alvos")]
    public GameObject prefab;

    [Header("GamePlay")]
    public float interval;
    public float minimumX;
    public float maximumX;
    public float y;

    [Header("Ovos")]
    public Sprite[] sprites;


	// Use this for initialization
	void Start () {
        // Função chama o método Spawn de acordo com o tempo da variável internal
        // e depois repete indefinidamente de acordo com a mesma variável
        InvokeRepeating("Spawn", interval, interval);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spawn() {

        // Instânciar e posicionar os objetos
        GameObject Instance = Instantiate(prefab);
        Instance.transform.position = new Vector2(Random.Range(minimumX, maximumX), y);

        // Set parent
        Instance.transform.SetParent(transform);

        // Set um sprite para ser adicionado na cena
        Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];

        Instance.GetComponent<SpriteRenderer>().sprite = randomSprite;

    }
}
