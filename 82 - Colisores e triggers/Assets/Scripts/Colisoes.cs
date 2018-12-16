using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisoes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Métodos de Collision
    private void OnCollisionEnter2D(Collision2D colisao) {
        if(colisao.gameObject.tag == "Objetos")         // testa se a tag do objeto chamado é igual ao elemento testado 
            Debug.Log(colisao.gameObject.name);         // captura e mostra o nome do objeto que colidiu    
            //Debug.Log("Colidiu com um objeto!");
    }
    void OnCollisionExit2D() {
        Debug.Log("Deixou de colidir com o objeto!");
    }
    void OnCollisionStay2D() {
        Debug.Log("Sempre colidindo com o objeto!");
    }

    // Métodos de Trigger
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Objetos") {
            Destroy(collision.gameObject);
        }            
        // Debug.Log("Colidiu com o celular!");
    }
    private void OnTriggerExit2D(Collider2D collision) {
        // Debug.Log("Saiu da colisão com o celular!");
    }
    private void OnTriggerStay2D(Collider2D collision) {
        // Debug.Log("Sempre colidindo com o celular!");
    }
}
