using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator playerAnimator;

    public float    moveDistance;   // Distância a ser movida
    public float    moveSpeed;      // Velocidade do movimento
    public bool     isIdle;         // Indica se o personagem está parado
    public bool     isDead;         // Indica se o personagem está morto
    public bool     isMoving;       // Indica se o personagem está se movendo
    public bool     isCanMove;      // Indica se pode se mover
    public bool     jumpStart;      // Indica o início do pulo
    public bool     isJumping;      // Indica se o personagem está pulando

    public Vector3 target;          // Armazena o destino do movimento          

    void Update () {

        AnimatorController(); 
        canIdle();
        CanMove();
        Moving();
        
	}

    // Método que aguarda pressionar as teclas de movietno enquanto o personagem está parado
    void canIdle() {

        if (isIdle) { // Realiza o teste abaixo somente se o player estiver parado

            // Passa pelo if caso uma das teclas abaixo for clicada
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {

                checkIfCanMove();
            }
        }
    }

    // Método que verifica se o personagem pode se mover
    // Verifica se há obstáculo para permitir o movimento do personagem ou não
    void checkIfCanMove() {

        // Fazer o teste de reyCaste para verificar possíveis obstáculos
        RaycastHit hit;
        Physics.Raycast(new Vector3(
            transform.position.x,       // Posição inicial de partida do raio, definida pelo Vector3
            transform.position.y + 5,
            transform.position.z),
            transform.forward,          // Direção para onde o raio vai apontar (eixo azul)
            out hit,                    // Local onde o rayCast será armazenado, ou seja, variável hit
            moveDistance);              // Tamanho do raio
        // Desenhando o RayCast para ser visível
        Debug.DrawRay(new Vector3(
            transform.position.x, transform.position.y + 5, transform.position.z),
            transform.forward * moveDistance, //Direção do raio e tamanho
            Color.red, // Cor do raio
            2); //Tempo de duração do raio

        // Testa se há obstáculos à frente do pesonagem, se não hover é chamado do método para realizar o movimento
        if (hit.collider == null) { setMove(); }
        else if(hit.collider.tag != "collider") { setMove(); }
        else { print("Há obstáculo"); }


        
    }

    void setMove() {

        isIdle = false;     // Desabilita a entrada de dados via teclas direcionais
        isCanMove = true;   // Habilita método que vai capturar tecla direcional clicada
        jumpStart = true;   // Habilita o pulo
    }

    // Método responsável por atribuir via teclas direcionais o movimento ao player
    void CanMove() {

        if (isCanMove && !isDead) { 

            // Ao soltar a telca de seta para cima
            if (Input.GetKeyUp(KeyCode.UpArrow)) {
                // target recebe um vetor 3, onde a posição do y é aumentada pelo valor da variável moveDistance
                target = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveDistance);                
            }
            // Ao apertar seta para baixo
            else if (Input.GetKeyUp(KeyCode.DownArrow)) {
                // target recebe um vetor 3, onde a posição do y é diminuida pelo valor da variável moveDistance
                target = new Vector3(transform.position.x, transform.position.y, transform.position.z - moveDistance);
            }
            // Ao apertar seta para esquerda
            else if (Input.GetKeyUp(KeyCode.LeftArrow)) {
                // target recebe um vetor 3, onde a posição do x é diminuida pelo valor da variável moveDistance
                target = new Vector3(transform.position.x - moveDistance, transform.position.y, transform.position.z);
            }
            // Ao apertar seta para direita
            else if (Input.GetKeyUp(KeyCode.RightArrow)) {
                // target recebe um vetor 3, onde a posição do x é aumentada pelo valor da variável moveDistance
                target = new Vector3(transform.position.x + moveDistance, transform.position.y, transform.position.z);                
            }
            // Ao soltar uma das teclas direcionais 
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) {

                jumpStart = false;
                isJumping = true;
                isMoving = true; // Define que o movimento do player pode ser executado
                isCanMove = false; // Desabilita método que vai capturar tecla direcional clicada 
            }
        }
    }

    // Método responsável por setar o movimento do player
    void Moving() {
        // Se a variável isMoving for true, execute o movimento
        if (isMoving) {
            // Realiza o movimento do player de um ponto ao outro
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed);

            // Verifica se o player já chegou na posição de destino
            if (transform.position == target) {
                MoveComplete();
            } 
        }
    }

    void MoveComplete() {

        isIdle = true;      // Habilita a entrada de dados via teclas direcionais
        isMoving = false;   // Inabilita o movimento do player
        isJumping = false;
    }

    // Chamada quando o personagem morre
    void gotHit() {
        isDead = true;
    }

    void AnimatorController() {

        if (!isDead) { 
            if (Input.GetKeyDown(KeyCode.UpArrow)) { transform.rotation = Quaternion.Euler(0, 0, 0); }
            else if (Input.GetKeyDown(KeyCode.RightArrow)) { transform.rotation = Quaternion.Euler(0, 90, 0); }
            else if (Input.GetKeyDown(KeyCode.DownArrow)) { transform.rotation = Quaternion.Euler(0, 180, 0); }
            else if (Input.GetKeyDown(KeyCode.LeftArrow)) { transform.rotation = Quaternion.Euler(0, -90, 0); }
        }
        playerAnimator.SetBool("dead", isDead);
        playerAnimator.SetBool("preJump", jumpStart);
        playerAnimator.SetBool("jump", isJumping);

    }

    // Ao entrar em colisão é ativado, capturando o collider do objeto que recebeu à colisão
    private void OnTriggerEnter(Collider coliderDoObjetoCorrente) {

        switch (coliderDoObjetoCorrente.tag) {
            case "moeda":
                print("Peguei uma moeda!");
                Destroy(coliderDoObjetoCorrente.gameObject);
                break;

            case "tomate":
                print("Peguei um tomate!");
                Destroy(coliderDoObjetoCorrente.gameObject);
                break;

            case "hit":
                print("Morreu");
                gotHit();
                break;
        }
    }
}
