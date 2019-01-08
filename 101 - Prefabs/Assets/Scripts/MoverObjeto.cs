using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObjeto : MonoBehaviour {
    // Variáveis de velocidade
    [Header("Variáveis de velocidade")]
    public float minimoVelocidadeX;
    public float maximoVelocidadeX;
    public float minimoVelocidadeY;
    public float maximoVelocidadeY;

    // Variável do GamePlay
    [Header("Variável do GamePlay")]
    public float tempoVida;

    // Use this for initialization
    void Start () {

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
            Random.Range(minimoVelocidadeX, maximoVelocidadeX),
            Random.Range(minimoVelocidadeY, maximoVelocidadeY)
        );
        Debug.Log("Valores de X: "+Random.Range(minimoVelocidadeX, maximoVelocidadeX));
        Debug.Log("Valores de Y: "+ Random.Range(minimoVelocidadeY, maximoVelocidadeY));

        // Esperar e destruir o objeto
        Destroy(gameObject, tempoVida);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
