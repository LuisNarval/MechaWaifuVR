using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionCabina : MonoBehaviour
{
    [Header("RERENCIAS A ESCENAS")]
    public bool EsWifu = false;
    public float offsetY;

    [Header("RERENCIAS A ESCENAS")]
    public Transform posicionCentral;
    public Transform posicionCabina;


    [Header("CONSULTAS")]
    public Vector3 posCentral;
    public Vector3 posCabina;

    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
    }
    private void FixedUpdate(){
        AcomodarCabina();
    }

    void AcomodarCabina(){
        posCentral = posicionCentral.position;
        posCabina = posicionCabina.position;

        posicionCabina.position = posicionCentral.position;

        posicionCabina.rotation = Quaternion.Euler(new Vector3(posicionCabina.rotation.eulerAngles.x, posicionCentral.rotation.eulerAngles.y ,posicionCabina.rotation.eulerAngles.z) );

        if(EsWifu)
            posicionCabina.rotation = Quaternion.Euler(new Vector3(posicionCabina.rotation.eulerAngles.x, posicionCentral.rotation.eulerAngles.y + offsetY, posicionCabina.rotation.eulerAngles.z));


    }



}