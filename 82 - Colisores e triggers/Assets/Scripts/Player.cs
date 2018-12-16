using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Animator playerAnimator;              // Variável de Gerenciamento do Animator
    private Rigidbody2D playerRigidbody2D;        // Objeto váriavel para o Rigidbory2D
    public Transform groundCheck;                 // Objeto para detectar se o personagem está pisando no chão

    public bool isGrounded = false;               // Variável boleana para saber se estamos no Chão
    public bool facingRight = true;               // Variável para informar que o Player esta virado para a direita

    public float speed;                           // Variável de Velocidade do personagem
    public float direcao = 0.0f;                  // Váriavel de direção X (horizontal) na tela

    // Use this for initialization
    void Start () {

        // Pega o componente Animator e coloca dentro da Váriavel
        playerAnimator = GetComponent<Animator>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        playerAnimator.SetBool("isGrounded", isGrounded);

        direcao = Input.GetAxisRaw("Horizontal");

        SetaMovimentos();

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x * speed, playerRigidbody2D.velocity.y);
    }

    void SetaMovimentos()
    {
        playerAnimator.SetBool("Run", playerRigidbody2D.velocity.x != 0f && isGrounded);
    }

    private void FixedUpdate()  // Função de Atualização de frames Fixa 0.02f
    {

        MovePlayer(direcao);

    }

    void MovePlayer(float movimentoH)
    {
        playerRigidbody2D.velocity = new Vector2(movimentoH * speed, playerRigidbody2D.velocity.y);
        if (movimentoH < 0 && facingRight || (movimentoH > 0 && !facingRight))
        {
            Flip();
        }
    }
}
