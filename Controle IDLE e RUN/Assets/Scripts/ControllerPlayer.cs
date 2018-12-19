using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour {

    private Animator    playerAnimator;
    private Rigidbody2D playerRigidbody2D;
    public  Transform   groundCheck;

    public  bool        isGrounded;         // Está tocando o chão?
    public  bool        facingRight = true; // Está olhando para direita?

    public  float       speed;              // Velocidade do personagem.
    public  float       direcao;            // Direção que o personagem está indo.

    // Variáveis usadas para controle do pulo
    public  bool         jump = false;
    public  float        jumpForce;
    public  int          numberJumps = 0;
    public  int          maxJumps = 2;


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
        Debug.Log("Valor retornado pela variável isGrounded: " + isGrounded);

        playerAnimator.SetBool("isGrounded", isGrounded); // Seta o conteudo da variável isGrounded para dentro do parâmetro isGrund no Animator
        direcao = Input.GetAxisRaw("Horizontal");         // Retorna o seguintes valores para o eixo x: 0 = personagem parado, 1 = personagem andando para direita e -1 = personagem andando para esquerda

        // Mostra em que estado o personagem está
        if (direcao == 0)
            Debug.Log("Personagem parado: " + direcao);
        else if(direcao == 1)
            Debug.Log("Personagem andando para direita: " + direcao);
        else if(direcao == -1)
            Debug.Log("Personagem andando para esquerda: " + direcao);

        ExecutaMovimentos();
        // Captura o pressionemento da barra de espaço e pula
        // && isGrounded
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
    }

    // Função específica que é chamada de forma à manter os frames estabilizados, independente da capacidade de processamento da máquina.
    private void FixedUpdate() {

        MovePlayer(direcao);
        if (jump)
            JumpPlayer();
    }

    private void JumpPlayer() {

        // Se o personagem estiver no chão o número de pulos é zerado
        if (isGrounded) {
            numberJumps = 0;
        }

        if(isGrounded || numberJumps < maxJumps) {

            // Adiciona uma força para realizar o pulo
            playerRigidbody2D.AddForce(new Vector2(0f, jumpForce));
            isGrounded = false; // O personagem não está no chão, ou seja, está pulando
            numberJumps++;
        }
        jump = false; 
    }

    void Flip() {
        facingRight = !facingRight;                 // Altera o lado que o personagem está olhando                 
        Vector3 theScale = transform.localScale;    // Armazena o localScale do objeto que recebeu o vínculo com o script
        theScale.x *= -1;                           // Multiplica os pontos da escala por -1 para mudar o lado
        transform.localScale = theScale;            // O localScale do Transform recebe o novo local
    }

    void ExecutaMovimentos() {
        // 
        playerAnimator.SetFloat("velocidadeY", playerRigidbody2D.velocity.y);
        // Seta dentro do parâmetro do Animator o valor true ou false,
        // dependendo das transições das animações executadas
        playerAnimator.SetBool("jump", !isGrounded);
        // Seta dentro do parâmetro do Animator o valor true ou false, onde a variável playerRigidbody2D verifica se o personagem está parado e no chão
        playerAnimator.SetBool("run", playerRigidbody2D.velocity.x != 0 && isGrounded);
    }

    void MovePlayer(float movimentoHorizontal) {
        // Atribui uma velocidade ao personagem através do componente Rigidbody2D
        playerRigidbody2D.velocity = new Vector2(movimentoHorizontal * speed, playerRigidbody2D.velocity.y); // playerRigidbody2D.velocity.y = velocidade inserida no Inspector
        // Chama o método de flip para viarar o personagem
        if(movimentoHorizontal < 0 && facingRight || (movimentoHorizontal > 0 && !facingRight)) {

            Flip();
        }
    }
}
