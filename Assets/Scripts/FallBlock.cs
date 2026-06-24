using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBlock : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 initialPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
        initialPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            Invoke(nameof(AddGravity), 3f);
            Invoke(nameof(ResetPositionAndGravity), 10f);
        }
    }

    private void AddGravity()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    private void ResetPositionAndGravity()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        transform.position = initialPosition;
    }

}
