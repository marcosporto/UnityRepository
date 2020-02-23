using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    public Touch touch;
    public float velocidadeDaMira;
    public float velocidadeMunicao = 10f;
    public GameObject zumbi;
    public Transform posicaoA;
    public Transform posicaoB;


    private void Start()
    {
        velocidadeDaMira = 100f;
    }

    private void Update()
    {
      /*  if (Input.GetMouseButtonDown(0))
        { 
       
            Debug.Log("Instanciou!!!!");
            GameObject municaoTemporaria = Instantiate(zumbi) as GameObject;
            municaoTemporaria.transform.position = posicaoA.position;
            municaoTemporaria.GetComponent<Rigidbody>().velocity = transform.parent.forward * velocidadeMunicao;
        }

        if (Input.GetMouseButtonDown(1))
        {

            Debug.Log("Instanciou!!!!");
            GameObject municaoTemporaria = Instantiate(zumbi) as GameObject;
            municaoTemporaria.transform.position = posicaoB.position;
            municaoTemporaria.GetComponent<Rigidbody>().velocity = transform.parent.forward * velocidadeMunicao;
        }*/


        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x + touch.deltaPosition.x * velocidadeDaMira * Time.deltaTime, -5.81f, 6.57f),
                    transform.position.y,
                    transform.position.z);

                
            }
        }
        

       // for (int i = 0; i < Input.touchCount; i++)
       // {
         //   print("A posição dos dedos é " + Input.touches[i].position);
       // }



       // Touch touch = Input.GetTouch(0);
       //Vector3 touchPosition = Input.GetTouch(0).deltaPosition;
        //Camera.main.ScreenToWorldPoint(touch.position);
        //touchPosition.y = -7.5f;

       // transform.position = touchPosition;
        //Debug.Log("Clique na posição: " + touchPosition)//
    }
            
        //Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        //{
         //   Vector2 posicaoToqueNaTela = Input.GetTouch(0).deltaPosition;
            
         //   Debug.Log("Clique na posição: " + posicaoToqueNaTela.y);

       // }
    
    public AudioSource audioDeTiro;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Zumbi")
        {
            Debug.Log("Clicou no botão de TIRO!!!");
            audioDeTiro.Play();
            Destroy(other.gameObject);
        }
    }
}
