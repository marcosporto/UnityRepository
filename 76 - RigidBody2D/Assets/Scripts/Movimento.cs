using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movimento : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    private SpriteRenderer personagem;
    private float horizontal;
    private bool facingRight; // Virado para a direita

    [SerializeField]
    private float movimentSpeed;

	// Use this for initialization
	void Start () {

        myRigidBody = GetComponent<Rigidbody2D>();
        //personagem = GetComponent<SpriteRenderer>();
        facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
        // Captura o eixo horizontal e atribui o valor a uma variável
        horizontal = Input.GetAxis("Horizontal");

        HandMoviment(horizontal);
	}

    void HandMoviment(float horizontal) {
        // Atribui uma velocidade linear ao RigidBody2D para à direita
        //myRigidBody.velocity = Vector2.left;

        // Faz que o personagem se movimente para direita e esquerda
        myRigidBody.velocity = new Vector2(horizontal * movimentSpeed, myRigidBody.velocity.y);
        Debug.Log(myRigidBody.velocity);

    }

    void Flip(float horizontal) {
        if(horizontal > 0 && !facingRight) {
            facingRight = !facingRight;
        }

    }
}
