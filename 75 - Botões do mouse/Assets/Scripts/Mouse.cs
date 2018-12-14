using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {

    public Texture2D mousePonteiro;

	// Use this for initialization
	void Start () {
        // Função executa à troca do ponteiro do mouse
        Cursor.SetCursor(mousePonteiro, Vector2.zero, CursorMode.Auto);
    }
	
	// Update is called once per frame
	void Update () {

        // 0 esquerda
        // 1 direita
        // 2 meio
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Botão do mouse esquedo foi pressionado");
        }
        if (Input.GetMouseButtonDown(1)) {
            Debug.Log("Botão do mouse direito foi pressionado");
        }
        if (Input.GetMouseButtonDown(2)) {
            Debug.Log("Botão do mouse do meio foi pressionado");
        }
    }
}
