using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public int speed = 1;
    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the platform
        transform.Translate(Vector3.right * speed * Time.deltaTime * direction);
    }

    public void OnTriggerEnter(Collider other)
    {
        // Change direction
        if (other.gameObject.CompareTag("Reverser"))
        {
            direction *= -1; 
        }
    }
}
