using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBlock : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 intalPosition;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        intalPosition = transform.position;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            rb.useGravity = true;
            Invoke(nameof(RestPositionAndGravity), 5f);
        }
    }

    private void RestPositionAndGravity()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        transform.position = intalPosition;
    }
}

