using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyMechaStation : MonoBehaviour
{
    public float dischargingSpeed = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerManager playerManager = collision.GetComponent<PlayerManager>();
        if (playerManager != null)
        {
            if (playerManager.energyLevel > 0)
            {
                playerManager.energyLevel -= Time.deltaTime * dischargingSpeed;
                if(MechaData.instance.energyLevel<MechaData.instance.maxEnergyLevel)
                    MechaData.instance.energyLevel += Time.deltaTime * dischargingSpeed;
            }

        }
    }
}
