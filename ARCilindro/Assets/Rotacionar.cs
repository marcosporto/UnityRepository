using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacionar : MonoBehaviour
{
    Rigidbody terra;
    public float velocidade;

    void Start()
    {
        terra = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        terra.angularDrag = 1.0f;
        terra.AddTorque(transform.up);
        
    }
}
