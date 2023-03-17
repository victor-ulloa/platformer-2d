using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType
    {
        Coin = 0,
    }

    [SerializeReference] PickupType pickupType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (pickupType)
            {
                case PickupType.Coin:
                    // Do on pick up coin
                    break;
            }

            Destroy(gameObject);
        }

    }
}
