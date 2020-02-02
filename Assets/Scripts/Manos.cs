using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manos : MonoBehaviour{

    [Header("CONFIGURACION")]
    public string Control;

    [Header("REFERENCIA A ESCENA")]
    public Grip code_Grip;

    private void OnTriggerEnter(Collider collision){
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Agarrable")){
            code_Grip.DeteccionColision(Control,true);
        }
    }

    private void OnTriggerExit(Collider collision){
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Agarrable")){
            code_Grip.DeteccionColision(Control, false);
        }
    }

}