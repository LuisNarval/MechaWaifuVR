using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairArmRight : MonoBehaviour
{

    public int repairingLevel = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerManager playerManager = collision.GetComponent<PlayerManager>();
        if (playerManager != null)
        {
            string interactButton = playerManager.interactString;
            if (Input.GetButtonDown(interactButton)&& MechaData.instance.rightArmBroke)
            {
                repairingLevel += 1;
                if (repairingLevel >= 10)
                {
                    MechaData.instance.rightArmBroke = false;
                    repairingLevel = 0;
                }
            }
        }
    }
}
