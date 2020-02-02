using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenMechaStation : MonoBehaviour
{
    public float dischargingSpeed = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerManager playerManager = collision.GetComponent<PlayerManager>();
        if (playerManager != null)
        {
            if (playerManager.oxygenLevel > 0) 
            {
                playerManager.oxygenLevel -= Time.deltaTime * dischargingSpeed;
                if(MechaData.instance.oxygenLevel<MechaData.instance.maxOxygenLevel)
                    MechaData.instance.oxygenLevel += Time.deltaTime * dischargingSpeed;
            }

        }
    }
}
