using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calibracion : MonoBehaviour{

    [Header("CONFIGURACION")]
    public float Altura;

    [Header("REFERENCIAS A ESCENA")]
    public Transform transPiloto;

    [Header("CONSULTA")]
    public float deltaY;

    // Start is called before the first frame update
    void Start(){
        calibrar();        
    }

    // Update is called once per frame
    void Update(){
        
    }


    void calibrar(){
        deltaY = Altura - transform.position.y;
        transPiloto.position += new Vector3(0.0f,deltaY,0.0f);
    }

}
