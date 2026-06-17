using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iten : MonoBehaviour
{
    [SerializeField] private GameObject itemHistoryCanvas;
    private bool isCanvaOpen;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            itemHistoryCanvas.SetActive(true);
            isCanvaOpen = true;
            
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            itemHistoryCanvas.SetActive(false);
            isCanvaOpen = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isCanvaOpen == true)
        {
            CollectItem();
        }
    }

    private void CollectItem()
    {
         AudioMenager.Instance.PlaySound(AudioMenager.Instance.collectItem);
        Destroy(gameObject);
    }
}
