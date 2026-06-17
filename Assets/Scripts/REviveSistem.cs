using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REviveSistem : MonoBehaviour
{
    public Vector3 spawnPosition;
    // Start is called before the first frame update
    private void Start()
    {
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    public void RevivePlayer()
    {
        transform.position = spawnPosition;
    }
}
