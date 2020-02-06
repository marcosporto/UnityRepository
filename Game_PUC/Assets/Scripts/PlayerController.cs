using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadeDoPlayer = 20.0f;
    private Vector3 posicaoDoPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posicaoDoPlayer = transform.position;
        posicaoDoPlayer.x += velocidadeDoPlayer * Input.GetAxis("Horizontal") * Time.deltaTime;
        posicaoDoPlayer.y += velocidadeDoPlayer * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position = posicaoDoPlayer;
    }
}
