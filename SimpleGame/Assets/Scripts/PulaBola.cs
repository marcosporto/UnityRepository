using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulaBola : MonoBehaviour
{
    Rigidbody rb;
    float jumpForce = 5; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){

            rb.AddForce(new Vector3(0, 1, 0) * jumpForce, ForceMode.Impulse);
        }

        var fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            // print(">>>>>>>> " + Input.touches);
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
            {
                fingerCount++;
            }
        }
        if (fingerCount == 1)
        {
            print("User has " + fingerCount + " finger(s) touching the screen");
        }
    }
        
}

