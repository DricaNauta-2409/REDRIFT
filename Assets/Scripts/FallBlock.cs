using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBlock : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 initalposition;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        initalposition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            rb.useGravity = true;
            Invoke(nameof(ResetPositionAndGravity), 5f);
        }
    }

    private void ResetPositionAndGravity()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        transform.position = initalposition;
    }

}
