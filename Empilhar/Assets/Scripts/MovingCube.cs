using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCube : MonoBehaviour {
    [SerializeField]
    private float moveSpeed = 1f;

    private void Update () {

        transform.position += transform.forward * Time.deltaTime * moveSpeed;
        Debug.Log("transform.position: " + transform.position);
        Debug.Log("transform.forward: " + transform.forward);
        Debug.Log("Time.deltaTime: " + Time.deltaTime);
    }
}
