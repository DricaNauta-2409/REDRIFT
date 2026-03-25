using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{   
    [Header("Reference")]
    public Transform player;
    public Transform playerObj;
     public Transform orientation;

      [Header("Settings")]
      public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if(Input.GetKeyDown(0) && Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;

        }

        //Rotacionar o objeto Orientation
        Vector3 viewDirection = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDirection.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
         float verticalInput = Input.GetAxis("Vertical");

         Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
         
         if(inputDirection != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDirection.normalized, Time.deltaTime * rotationSpeed);
        }

    }
}
