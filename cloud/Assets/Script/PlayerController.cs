using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 5;
    public int gravity = 30;
    public int jumpStrenght = 10;
    public KeyCode jumpKey = KeyCode.Space;
    private CharacterController controller;
    private Vector3 movement, finalMovement, rotation, spawnPosition;
    private GameUI uiScript;

    // Start is called before the first frame update
    void Start()
    {
        // Get references
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        spawnPosition = transform.position;
        uiScript = gameObject.GetComponent<GameUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle character movement, rotation, and fall checks
        CharacterTranslation();
        CharacterRotation();
        FallCheck();
    }

    // Get keyboard input and handle movement
    void CharacterTranslation()
    {
        // Check if character is touching ground
        if (controller.isGrounded)
        {
            // Get user input
            var x = Input.GetAxis("Vertical");
            var z = -Input.GetAxis("Horizontal");

            // Map direction in Vector3
            movement = transform.TransformDirection(new Vector3(x, 0, z) * speed);

            // Add jump force
            if (Input.GetKey(jumpKey))
            {
                movement.y += jumpStrenght;
            }
        }

        // Apply gravity
        movement.y -= gravity * Time.deltaTime;

        // Smoth out movement
        finalMovement = Vector3.Lerp(finalMovement, movement, Time.deltaTime * 2);

        // Move character
        controller.Move(movement * Time.deltaTime);
    }

    // Get mouse input and apply rotation
    void CharacterRotation()
    {
        var x = -Input.GetAxis("Mouse X");
        rotation = new Vector3(0, x, 0);
        transform.eulerAngles -= rotation;
    }

    // Check if character falling
    void FallCheck()
    {
        if (transform.position.y <= 0)
        {
            Respawn();
        }
    }

    // Reset character position
    public void Respawn()
    {
        transform.position = spawnPosition;
    }

    // Trigger level completion
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            uiScript.LevelComplete();
        }
    }
}
