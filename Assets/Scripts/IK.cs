using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))] 

public class IK : MonoBehaviour {

	protected Animator animator;

	public bool ikActive = false;
	public Transform rightHandObj = null;
	public Transform leftHandObj = null;

	public float a;
	public float b;

	public bool left;
	public bool right;


	void Start () 
	{
		animator = GetComponent<Animator>();
	}

	//a callback for calculating IK
	void OnAnimatorIK()
	{
		if(animator) {

			//if the IK is active, set the position and rotation directly to the goal. 
			if(ikActive) {

				// Set the right hand target position and rotation, if one has been assigned
				if(rightHandObj != null) {
					animator.SetIKPositionWeight(AvatarIKGoal.RightHand,1);
					animator.SetIKRotationWeight(AvatarIKGoal.RightHand,1);  
					animator.SetIKPosition(AvatarIKGoal.RightHand,rightHandObj.position);
					animator.SetIKRotation(AvatarIKGoal.RightHand,rightHandObj.rotation);
				}        

				// Set the left hand target position and rotation, if one has been assigned
				if(leftHandObj != null) {
					animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,1);
					animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,1);  
					animator.SetIKPosition(AvatarIKGoal.LeftHand,leftHandObj.position);
					animator.SetIKRotation(AvatarIKGoal.LeftHand,leftHandObj.rotation);
				}    

				/*
				if(right){
					float t=0f;
					if (t <= 1f) {
						animator.SetIKPositionWeight (AvatarIKGoal.RightHand, Mathf.Lerp (a, b, t));
						animator.SetIKRotationWeight (AvatarIKGoal.RightHand, Mathf.Lerp (a, b, t));
						t += Time.deltaTime;
					} else {
						right = false;
					}
				}

				if(left){
					float t=0f;
					if (t <= 1f) {
						animator.SetIKPositionWeight (AvatarIKGoal.LeftHand, Mathf.Lerp (a, b, t));
						animator.SetIKRotationWeight (AvatarIKGoal.LeftHand, Mathf.Lerp (a, b, t));
						t += Time.deltaTime;
					} else {
						left = false;
					}
				}*/
			}
			}

			//if the IK is not active, set the position and rotation of the hand and head back to the original position
			else {          
				animator.SetIKPositionWeight(AvatarIKGoal.RightHand,0);
				animator.SetIKRotationWeight(AvatarIKGoal.RightHand,0);
				animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,0);
				animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,0);
			}



	}


	/*
	public void RightIKLerp(bool active){
		a = active ? 0 : 1;
		b = active ? 1 : 0;
		right = true;
		//StartCoroutine (_RightIKLerp(active));
	}

	 IEnumerator _RightIKLerp(bool active){
		


		for(float t=0f;t <= 1f;t += Time.deltaTime)
		{
			animator.SetIKPositionWeight(AvatarIKGoal.RightHand,Mathf.Lerp(a, b, t));
			animator.SetIKRotationWeight(AvatarIKGoal.RightHand,Mathf.Lerp(a, b, t));
			yield return null;
		}
	}



	public void LeftIKLerp(bool active){
			a = active ? 0 : 1;
			b = active ? 1 : 0;
			left = true;
		//StartCoroutine (_LeftIKLerp(active));
	}

	IEnumerator _LeftIKLerp(bool active){
		float a;
		float b;

		a = active ? 0 : 1;
		b = active ? 1 : 0;

		for(float t=0f;t <= 1f;t += Time.deltaTime)
		{
			animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,Mathf.Lerp(a, b, t));
			animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,Mathf.Lerp(a, b, t));
			yield return null;
		}
	}
	*/
}