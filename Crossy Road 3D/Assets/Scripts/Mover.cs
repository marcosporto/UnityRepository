using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Realiza o movimento do objeto, o método Time.deltaTime estabelece que não haja variação nos frames, independente da capacidade do equipamento que estiver rodando o game
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
		
	}
}
