using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
   [SerializeField] private Transform checkpointSpawn   ;

   private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.TryGetComponent(out REviveSistem reviveSystem))
        {
             AudioMenager.Instance.PlaySound(AudioMenager.Instance.checkpointSound);
            reviveSystem.spawnPosition = checkpointSpawn.position;
        }
    }
}
