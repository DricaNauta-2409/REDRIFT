using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OxigenBar : MonoBehaviour
{
    [SerializeField] private Image oxygenImage;
    [SerializeField] private float maxOxygen = 100f;
    [SerializeField] private float oxygenDecreaseSpeed = 5f;
    [SerializeField] private float oxygenRecoveryAmount = 25f;

    private float currentOxygen;

    private void Start()
    {
        currentOxygen = maxOxygen;
        UpdateBar();
    }

    private void Update()
    {
        currentOxygen -= oxygenDecreaseSpeed * Time.deltaTime;
        currentOxygen = Mathf.Clamp(currentOxygen, 0f, maxOxygen);

        UpdateBar();

        if (currentOxygen <= 0f)
        {
            // SceneManager.LoadScene("LoseScene");
            Debug.Log("Perdeu");
        }
    }

    private void UpdateBar()
    {
        oxygenImage.fillAmount = currentOxygen / maxOxygen;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Oxigen"))
        {
            RecoverOxygen(oxygenRecoveryAmount);
            Destroy(other.gameObject);
        }
    }

    private void RecoverOxygen(float amount)
    {
        currentOxygen += amount;
        currentOxygen = Mathf.Clamp(currentOxygen, 0f, maxOxygen);
        UpdateBar();
    }
    

}
