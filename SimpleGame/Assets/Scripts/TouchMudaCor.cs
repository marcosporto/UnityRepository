using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMudaCor : MonoBehaviour
{

    private Vector2 posicaoInicial, posicaoFinal, direcao;
    private float touchTempoInical, touchTempoFinal, intervaloTempo;

   


    Rigidbody corpoRigido; // Cria uma referência para acessar o Rigidbody 
    

    MeshRenderer mesh; // Cria uma referência para acessar o MeshRenderer

    Transform escala; // Cria uma referência para acessar o Transform 
    float x, y, z, torque = 1f; // Variáveis para trabalhar com às posições de escala do objeto

    void Start()
    {
        corpoRigido = GetComponent<Rigidbody>(); // Captura o Transform do obejeto 

        mesh = GetComponent<MeshRenderer>(); // Captura o MeshRenderer do objeto 
        
        escala = GetComponent<Transform>(); // Captura o Transform do obejeto 
        x = escala.localScale.x; // Armazena nas variáveis x, y e z à escala inicial do objeto
        y = escala.localScale.y;
        z = escala.localScale.z;
    }

    void Update()
    {
        if (Input.touchCount == 2) // Se clicar com dois dedos na tela a bola muda de cor
            mesh.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)); // Atribui uma cor randômica ao material do objeto corrente

        if (Input.touchCount == 3) // Se clicar com três dedos na tela a bola aumenta
        {
            x += 1.0f * Time.deltaTime;
            y += 1.0f * Time.deltaTime;
            z += 1.0f * Time.deltaTime;

            escala.localScale = new Vector3(x, y, z); // Aumenta à escala do objeto corrente          
        }
        if (Input.touchCount == 4) // Se clicar com quatro dedos na tela a bola diminui
        {
            x -= 1.0f * Time.deltaTime;
            y -= 1.0f * Time.deltaTime;
            z -= 1.0f * Time.deltaTime;

            escala.localScale = new Vector3(x, y, z); // Diminui à escala do objeto corrente
        }
           
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            corpoRigido.AddTorque(transform.up * torque);
            torque += torque;
            //float caoInicial = Input.GetTouch(0).position.x;
        }
            
        //posicaoInicial = Input.GetTouch(0).position; // Pega posição x e y da tela          

        
            }
}

