using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour {

    private Animator    playerAnimator;
    private Rigidbody2D playerRigidbody2D;
    public Transform    groundCheck;

    public bool         isGrounded;         // Está tocando o chão?
    public bool         facingRight = true; // Está olhando para direita?

    public float        speed;              // Velocidade do personagem.
    public float        direcao;            // Direção que o personagem está indo.

	// Use this for initialization
	void Start () {
        playerAnimator    = GetComponent<Animator>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }	
	
    // Update is called once per frame
	void Update () {
        // Retorna um valor boleano        
        isGrounded = Physics2D.Linecast(transform.position, // Posição inicial do jogador >> Captura o valor do transform do objeto que está vinculado ao Script.
        groundCheck.position, // Posição final do jogador >> Captura os valores do tranform que é filho do Player, ou seja, que está nos pés do mesmo.
        1 << LayerMask.NameToLayer("Ground")); // Traz a informação se está ou não tocando a Layer passada como parâmetro.
        Debug.Log(isGrounded);

        playerAnimator.SetBool("isGrounded", isGrounded); // Seta o conteudo da variável isGrounded para dentro do parâmetro isGrund no Animator
		
	}
}
