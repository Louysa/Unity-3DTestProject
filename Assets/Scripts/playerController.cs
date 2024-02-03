using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    private int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            count++;
            coinText.text = count.ToString();
            other.gameObject.SetActive(false); 
        }
    }
}
