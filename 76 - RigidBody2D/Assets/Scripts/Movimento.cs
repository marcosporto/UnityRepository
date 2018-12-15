using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;



public class Movimento : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    //private SpriteRenderer personagem;
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
        Debug.Log("Executa a função Update" + Time.deltaTime);
    }

    void HandMoviment(float horizontal) {
        // Atribui uma velocidade linear ao RigidBody2D para à direita
        //myRigidBody.velocity = Vector2.left;

        // Faz que o personagem se movimente para direita e esquerda
        myRigidBody.velocity = new Vector2(horizontal * movimentSpeed, myRigidBody.velocity.y);
        //Debug.Log(myRigidBody.velocity);
        //Debug.Log(myRigidBody.velocity);

    }

    // Método para alterar a posição que o obejto olha
    void Flip(float horizontal) {
        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {

            facingRight = !facingRight;
            Vector2 theScale = transform.localScale; // A variável theScale recebe os valores de escala do objeto.
            theScale.x *= -1; // O valor x é multiplicado por -1 e atribuido.
            transform.localScale = theScale; // A escala do objeto recebe sua nova posição, onde só o valor de x foi alterado.
        }
    }


    void FixedUpdate() {

        HandMoviment(horizontal);
        Flip(horizontal);
        Debug.Log("Executa a função fixdUpdate" + Time.deltaTime);
    }

    
}

