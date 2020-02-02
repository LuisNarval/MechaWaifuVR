using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour {

	public int maxPopulation;

	public int spawnRateTime;

	public GameObject[] meteorTypes;
	public GameObject[] areaCoords;

	//private List<GameObject> meteors;
	// Use this for initialization
	void Start () {
		StartCoroutine (RandomTimeGenerate());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Generacion aleatoria de meteoritos en un area determinada, upgradear a object pooling
	public void Generate(){
		if(transform.childCount < maxPopulation){
			Instantiate<GameObject>(meteorTypes[Random.Range(0,meteorTypes.Length)],new Vector3(Random.Range(areaCoords[0].transform.position.x,areaCoords[1].transform.position.x),Random.Range(areaCoords[0].transform.position.y,areaCoords[1].transform.position.y), Random.Range(areaCoords[0].transform.position.z, areaCoords[1].transform.position.z)),Quaternion.identity,transform);
		}
	}

	IEnumerator RandomTimeGenerate(){
		while (true) {
			yield return new WaitForSeconds (Random.Range(0,spawnRateTime));
			Generate ();
		}
	
	}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireCube(transform.position, new Vector3(50,50,50));
    //}

}
