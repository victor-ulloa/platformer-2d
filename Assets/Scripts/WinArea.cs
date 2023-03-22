using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinArea : MonoBehaviour
{
    [SerializeField] GameObject WinOverlay; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Player wins
            WinOverlay.SetActive(true);
            GameManager.instance.playerInstance.playerInputs.Disable();
        }
    }
}
