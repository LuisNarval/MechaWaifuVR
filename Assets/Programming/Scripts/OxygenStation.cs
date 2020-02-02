using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenStation : MonoBehaviour
{

    public float chargingSpeed = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerManager playerManager = collision.GetComponent<PlayerManager>();
        if (playerManager != null)
        {
            if(playerManager.oxygenLevel < playerManager.maxOxygen)
                playerManager.oxygenLevel += Time.deltaTime * chargingSpeed;
        }
    }


}
