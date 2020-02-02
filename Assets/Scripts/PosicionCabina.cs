using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionCabina : MonoBehaviour
{
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
        AcomodarCabina();
    }

    void AcomodarCabina(){
        posCentral = posicionCentral.position;
        posCabina = posicionCabina.position;

        posicionCabina.position = posicionCentral.position;
    }



}