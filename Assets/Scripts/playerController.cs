using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    private int count = 0;
    public ThirdPersonController ThirdPersonController;
    [SerializeField] private Image powerupImage;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            count++;
            coinText.text = count.ToString();
            other.gameObject.SetActive(false); 
        }

        if (other.gameObject.CompareTag("powerup"))
        {
            ThirdPersonController.playerSpeed = 10f;
            other.gameObject.SetActive(false);
            powerupImage.gameObject.SetActive(true);
            Invoke("resetPlayerSpeed",5.0f);
        }
    }

    public void resetPlayerSpeed()
    {
        ThirdPersonController.playerSpeed = 5f;
        powerupImage.gameObject.SetActive(false);
    }
}
