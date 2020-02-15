﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicouNoZumbi : MonoBehaviour
{
    GameObject zumbi;

    // Start is called before the first frame update
    void Start()
    {
        zumbi = GameObject.FindWithTag("AreaDeClique");
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime,Space.World);
        //multiplicar por Time.deltatime
        
    }
    private void OnMouseDown()
    {
        if (transform.position.z < -15 && transform.position.z > -25)
        {
            Debug.Log("Clicou no mouse!!!");
            Destroy(gameObject);
        }
       //
        
    }
}
