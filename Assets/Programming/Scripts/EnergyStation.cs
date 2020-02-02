using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyStation : MonoBehaviour
{
    public float chargingSpeed = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerManager playerManager = collision.GetComponent<PlayerManager>();
        if (playerManager != null)
        {
            if (playerManager.energyLevel < playerManager.maxEnergy)
                playerManager.energyLevel += Time.deltaTime * chargingSpeed;
        }
    }
}
