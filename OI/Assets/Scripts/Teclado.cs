using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Teclado : MonoBehaviour
{
    private Keyboard teclado;
    private Mouse mouse;

    // Start is called before the first frame update
    void Start()
    {
        // Captura à referência ao teclado
        teclado = Keyboard.current;

        // Captura à referência ao mouse
        mouse = Mouse.current;        
    }

    // Update is called once per frame
    void Update()
    {
        // Acesso ao teclado
        if (teclado.aKey.isPressed) // Aciona várias vezes enquanto estiver pressionada
            Debug.Log("Tecla A foi pressionada.");
        if (teclado.bKey.wasPressedThisFrame) // Aciona uma única vez quando é pressionada
            Debug.Log("Tecla B foi pressionada.");
        if (teclado.bKey.wasReleasedThisFrame) // Aciona uma única vez quando a tecla é solta
            Debug.Log("Tecla B foi solta.");

        // Acesso ao mouse
        if (mouse.leftButton.isPressed) // Aciona várias vezes enquanto estiver pressionada
            Debug.Log("Tecla esquerda do mouse foi clicada.");
        if (mouse.middleButton.wasPressedThisFrame) // Aciona o clique do Scroll
            Debug.Log("O clique do scroll do mouse foi acionado.");
         
    }
}
