using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animation playerAnimator;

    public float    moveDistance;   // Distância a ser movida
    public float    moveSpeed;      // Velocidade do movimento
    public bool     isIdle;         // Indica se o personagem está parado
    public bool     isDead;         // Indica se o personagem está morto
    public bool     isMoving;       // Indica se o personagem está se movendo
    public bool     jumpStart;      // Indica o início do pulo
    public bool     isJumping;      // Indica se o personagem está pulando

    public Vector3 target;          // Armazena o destino do movimento          

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        canIdle();
        CanMove();
        Moving();
	}

    void canIdle() {

        if (isIdle) { // Realiza o teste abaixo somente se o player estiver parado

            // Passa pelo if caso uma das teclas abaixo for clicada
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {

                checkIfCanMove();
            }
            print("Testou IsIdle");
        }
    }

    // Método que verifica se o personagem pode se mover
    void checkIfCanMove() {

        // Fazer o teste de reyCaste para verificar possíveis obstáculos
        print("Verificou se pode mover");
        setMove();
    }

    void setMove() {

        isIdle = false;
        isMoving = true;

        print("Definiu Movimento");
    }

    // Método responsável por atribuir via teclas direcionais o movimento ao player
    void CanMove() {

        if (isMoving) {

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
            print("Pode Mover");
            //isIdle = true;
            //isMoving = false;
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

        isIdle = true;
        isMoving = false;
    }
}
