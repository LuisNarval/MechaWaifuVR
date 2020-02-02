using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmDamage : MonoBehaviour {

	public bool LR; // true = Left / false = Right

	public int numberOfHits;
	private int damageCounter;
	private bool leftRepairFlag;
	private bool rightRepairFlag;
	private IK inverseKinematics;
	// Use this for initialization
	void Start () {
		damageCounter = 0;
		inverseKinematics = GetComponentInParent<IK> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*
		//if(!MechaData.instance.leftArmDamage && !leftRepairFlag){
		if(!leftRepairFlag){
			leftRepairFlag = true;
			//(ReasignarIK)
			inverseKinematics.ikActive=true;
		}

		//if(!MechaData.instance.rightArmDamage && !rightRepairFlag){
		if(!rightRepairFlag){
			rightRepairFlag = true;
			//(ReasignarIK)
			inverseKinematics.ikActive=true;
		}
		*/
	}

	public void Damage(){
		damageCounter++;
		if(damageCounter >= numberOfHits){
			damageCounter = 0;
			//(retirar IK)

			if (LR) {
				//MechaData.instance.leftArmDamage = true;
				inverseKinematics.ikActive = false;
				leftRepairFlag = false;
			} else {
				//MechaData.instance.rightArmDamage = true;
				inverseKinematics.ikActive=false;
				rightRepairFlag = false;
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Hazard"){
			Damage ();
		}
	}
}
