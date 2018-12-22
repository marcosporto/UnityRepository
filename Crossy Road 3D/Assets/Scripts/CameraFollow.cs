using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public float moveSpeedCamera; // Velocidade que a câmera vai atualizar o movimento

    public Vector3 posicaoInicialDaCamera; // Posição inicial da câmera
    public float rotacaoX, rotacaoY; // Posição da rotação da câmera

    public bool follow; // A câmera está seguindo

    public float tamanhoDaCamera;

    private Vector3 posicaoDaCamera;
    private Quaternion rotacaoDaCamera;
    private float novoTamanhoDaCamera;
    

	// Use this for initialization
	void Start () {

        // Seta um posição inicial para a câmera
        transform.position = posicaoInicialDaCamera;
        transform.rotation = Quaternion.Euler(rotacaoX, rotacaoY, 0);
    }
	
	// Update is called once per frame
	void Update () {

        // Função para seguir o personagem
        if (follow) {
            // Nova posição para a câmera, o Lerp reliza uma interpolação que inicia rápido e finaliza de forma lenta
            // Trabalha na nova posição da câmera
            posicaoDaCamera = Vector3.Lerp(
                transform.position, // Posição inicial da câmera
                player.position + posicaoInicialDaCamera, // Posição que a câmera deve ir
                moveSpeedCamera * Time.deltaTime); // Velocidade que o moveimento da cãmera será executado
            // Trabalha na nova rotação da câmera
            rotacaoDaCamera = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotacaoX, rotacaoY, 0), moveSpeedCamera * Time.deltaTime);
            // Trabalha no novo size da câmera
            novoTamanhoDaCamera = Mathf.Lerp(Camera.main.orthographicSize, tamanhoDaCamera, moveSpeedCamera * Time.deltaTime);

            // Atibuindo valores à câmera
            transform.position = posicaoDaCamera;
            transform.rotation = rotacaoDaCamera;
            Camera.main.orthographicSize = novoTamanhoDaCamera;


        }
		
	}
}
