using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // Adiciona um RigidbodY2D via código

public class MoveObject2D : MonoBehaviour { // Funciona apenas com câmera ortográfica

    private Vector3 posicaoInicial;
    private Vector3 posicaoDestino;
    private Vector3 vetorDirecao;

    private Rigidbody2D _rigidbody2D;

    private bool estaArrastando; // Ativada quando o obejto está sendo arrastado pelo clique do mouse
    private float distancia;

    [HideInInspector] // Faz uma variável ou objeto público desaparecer do Inspector
    public bool estaConectado;

    [Range(1, 15)] // Cria um range limitado a um valor mínimo e outro máximo
    public float velocidadeDeMovimento = 10;

    [Space(10)] // Cria espaçamento de 10 pixels no Inspector
    public Transform conector; // Posição onde a peça deve ser conectada

    [Range(0.1f, 2.0f)]
    public float distanciaMinimaConector = 0.5f; // Distância mínima para que à peça seja conectada

    void Start () {

        _rigidbody2D = transform.root.GetComponent<Rigidbody2D>(); // Captura o componente Rigidbody2D do objeto pai ao qual o script está vinculado
        _rigidbody2D.gravityScale = 1; // Ativa à gravidade do objeto em questão // 1 = ativa gravidade e 0 = desativa gravidade
    }

    private void OnMouseDown() { // Ativa quando clica no mouse

        // Pega a posição do objeto e subtrai da posição do mouse
        posicaoInicial = transform.root.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _rigidbody2D.gravityScale = 0; // Dasativa a gravidade do objeto
        estaArrastando = true; // Obejto está sendo arrastado
        estaConectado = false; // Obejto não está conectado
    }

    private void OnMouseDrag() { // Ativa quando o mouse é clicado e o obejto é arrastado

        posicaoDestino



    }
}
