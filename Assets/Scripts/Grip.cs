using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grip : MonoBehaviour{

    [Header("CONFIGURACION")]
    public float fuerza;

    [Header("REFERENCIAS A ESCENA")]
    public Transform transCabina;
    public Transform posManoDerecha;
    public Transform posManoIzquierda;
    
    [Header("CONSULTAS")]
    public bool GatilloDerecho = false;
    public bool GatilloIzquierdo = false;

    public bool ControlDerechoEnColision = false;
    public bool ControlIzquierdoEnColision = false;


    public bool Anclado = false;

    public Transform ManoAAnclar;
    public Vector3 PosicionAnclaje;
    public string NombreManoAnclada;

    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        RecibirInput(); 
    }

    private void LateUpdate(){
        if(Anclado)
            Anclar();
    }

    void RecibirInput(){
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.0f){
            GatilloIzquierdo = true;
            IntentarAnclaje();
        }else{
            GatilloIzquierdo = false;
        }

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.0f){
            GatilloDerecho = true;
            IntentarAnclaje();
        }else{
            GatilloDerecho = false;
        }

    }


    public void DeteccionColision(string C, bool valor){
        if (C == "ControlDerecho")
            ControlDerechoEnColision = valor;
        else if (C == "ControlIzquierdo")
            ControlIzquierdoEnColision = valor;
    }


    
    public void IntentarAnclaje(){

        if (!Anclado){
            if (ControlDerechoEnColision && GatilloDerecho){
                ManoAAnclar = posManoDerecha;
                PosicionAnclaje = posManoDerecha.position;
                NombreManoAnclada = "ManoDerecha";
                Anclado = true;
            }
            if (ControlIzquierdoEnColision && GatilloIzquierdo){
                ManoAAnclar = posManoIzquierda;
                PosicionAnclaje = posManoIzquierda.position;
                NombreManoAnclada = "ManoIzquierda";
                Anclado = true;
            }
        }

        
    }

    [Header("MÁXIMO VECTOR")]
    public Vector3 diferencia;
    public void Anclar(){

        diferencia = ManoAAnclar.position - PosicionAnclaje;

        transCabina.position -= diferencia;

        ManoAAnclar.position = PosicionAnclaje;

        if (NombreManoAnclada == "ManoDerecha" && !GatilloDerecho){
            Anclado = false;
            transCabina.GetComponent<Rigidbody>().AddForce(diferencia*fuerza, ForceMode.VelocityChange);
        }

        if (NombreManoAnclada == "ManoIzquierda" && !GatilloIzquierdo){
            Anclado = false;
            transCabina.GetComponent<Rigidbody>().AddForce(-1*diferencia*fuerza, ForceMode.VelocityChange);
            Debug.Log(diferencia.magnitude);
        }

    }


}
