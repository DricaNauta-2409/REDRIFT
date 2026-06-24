using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out REviveSistem reviveSystem))
        {
            StartCoroutine(KillPlayerDelay(reviveSystem));
        }
    }

private IEnumerator KillPlayerDelay(REviveSistem reviveSystem)
{
    yield return new WaitForSeconds(0.25f);

    AudioMenager.Instance.PlaySound(AudioMenager.Instance.deathSound);
    reviveSystem.RevivePlayer();
}
}


   