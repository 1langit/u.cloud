using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveSwitcher : MonoBehaviour
{
    public GameObject player;
    public KeyCode switchKey = KeyCode.Tab;
    private Vector3 firstPersonOffset = new Vector3(0, 0.9f, 0);
    private Vector3 thirdPersonOffset = new Vector3(-5, 4, 0);
    private Vector3 currentOffset = new Vector3();
    private float rotation = 30;

    // Start is called before the first frame update
    void Start()
    {
        // Set initial camera state
        currentOffset = thirdPersonOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            // Change perspective to third person
            if (currentOffset == firstPersonOffset)
            {
                currentOffset = thirdPersonOffset;
                transform.Rotate(rotation, 0, 0);
            }
            // Change perspective to first person
            else if (currentOffset == thirdPersonOffset)
            {
                currentOffset = firstPersonOffset;
                transform.Rotate(-rotation, 0, 0);
            }
            transform.localPosition = currentOffset;
        }
    }
}
