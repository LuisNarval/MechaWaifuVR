using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MechaData : MonoBehaviour
{
    public float oxygenLevel;
    public float energyLevel;
    public bool rightArmBroke;
    public bool leftArmBroke;
    public bool headBroke;

    public float maxOxygenLevel;
    public float maxEnergyLevel;

    public float dischargingSpeedOxygen;
    public float dischargingSpeedEnergy;

    public Image imageOxygen2D;
    public Image imageEnergy2D;

    public Image imageOxygen3D;
    public Image imageEnergy3D;

    public SpriteRenderer armLeft;
    public SpriteRenderer armRight;

    public static MechaData instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }


    void Update()
    {
        oxygenLevel -= Time.deltaTime * dischargingSpeedOxygen;
        energyLevel -= Time.deltaTime * dischargingSpeedEnergy;

        imageOxygen2D.fillAmount = oxygenLevel / maxOxygenLevel;
        imageEnergy2D.fillAmount = energyLevel / maxEnergyLevel;

        imageOxygen3D.fillAmount = oxygenLevel / maxOxygenLevel;
        imageEnergy3D.fillAmount = energyLevel / maxEnergyLevel;

        if (rightArmBroke)
            armRight.color = Color.red;
        else
            armRight.color = Color.white;

        if (leftArmBroke)
            armLeft.color = Color.red;
        else
            armLeft.color = Color.white;

    }
}
