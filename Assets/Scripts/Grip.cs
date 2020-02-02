using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grip : MonoBehaviour{

    [Header("CONFIGURACION")]
    public float fuerza;
    public float fuerzaJet;

    [Header("REFERENCIAS A ESCENA")]
    public Transform transCabina;
    public Transform posManoDerecha;
    public Transform posManoIzquierda;
    public Animator anim_Brazos;
    public ConstantForce fuerzaConstante;


    [Header("CONSULTAS")]
    public bool GatilloDerecho = false;
    public bool GatilloIzquierdo = false;

    public bool ControlDerechoEnColision = false;
    public bool ControlIzquierdoEnColision = false;


    public bool Anclado = false;

    public Transform ManoAAnclar;
    public Vector3 PosicionAnclaje;
    public string NombreManoAnclada;

    public Vector3 vectorSalida;

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
            anim_Brazos.SetBool("LeftGrab",true);
            IntentarAnclaje();
        }else{
            GatilloIzquierdo = false;
            anim_Brazos.SetBool("LeftGrab", false);
        }

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.0f){
            GatilloDerecho = true;
            anim_Brazos.SetBool("RightGrab", true);
            IntentarAnclaje();
        }else{
            GatilloDerecho = false;
            anim_Brazos.SetBool("RightGrab", false);
        }




        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.0f){
            transCabina.GetComponent<Rigidbody>().AddForce( posManoIzquierda.forward * fuerzaJet, ForceMode.VelocityChange);
        }

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.0f){
            transCabina.GetComponent<Rigidbody>().AddForce(posManoDerecha.forward*fuerzaJet, ForceMode.VelocityChange);
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

        transCabina.GetComponent<Rigidbody>().MovePosition(transCabina.position - diferencia);

        vectorSalida = transCabina.position - PosicionAnclaje;

        Debug.DrawLine(PosicionAnclaje, vectorSalida);

        if (NombreManoAnclada == "ManoDerecha" && !GatilloDerecho){
            Anclado = false;
            //vectorSalida = transCabina.position - PosicionAnclaje;
            //fuerzaConstante.force = vectorSalida*fuerza;
                transCabina.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(vectorSalida)*fuerza, ForceMode.VelocityChange);
                Debug.DrawLine(PosicionAnclaje, vectorSalida);
        }

        if (NombreManoAnclada == "ManoIzquierda" && !GatilloIzquierdo){
            Anclado = false;
            //vectorSalida =  transCabina.position - PosicionAnclaje;
            //fuerzaConstante.force = vectorSalida * fuerza;
                transCabina.GetComponent<Rigidbody>().AddForce( Vector3.Normalize(vectorSalida)* fuerza, ForceMode.VelocityChange);
            //Debug.Log(diferencia.magnitude);
            Debug.DrawLine(PosicionAnclaje, vectorSalida);
        }

        ManoAAnclar.position = PosicionAnclaje;

    }


}
