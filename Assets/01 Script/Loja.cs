using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Loja : MonoBehaviour {
    public int mina;
    public int granada;
    public int KitMedico;
    public int drone;
    public bool Barreira;

    public Text minaText;
    public Text granadaText;
    public Text KitMedicoText;
    public Text DroneText;

    public GameObject minaPrefab;
    public GameObject granadaPrefab;
    public GameObject dronePrefab;

    public CannonBehaviour auxCannon;
	// Use this for initialization
	void Start () 
    {
        auxCannon = GameObject.Find("Buster").GetComponent<CannonBehaviour>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        minaText.text = "" + mina;
        granadaText.text = "" + granada;
        KitMedicoText.text = "" + KitMedico;




    }
    public void ComprarMina()
    {
        if(auxCannon.PontosTotais >= 10)
        {
            mina++;
            auxCannon.PontosTotais -= 10;
        }
    }

    public void ComprarGranada()
    {
        if (auxCannon.PontosTotais >= 15)
        {
            granada++;
            auxCannon.PontosTotais -= 15;
        }
    }

    public void ComprarKitMedico()
    {
        if (auxCannon.PontosTotais >= 100)
        {
            auxCannon.vidaCur += 50;
            auxCannon.PontosTotais -= 100;
        }
    }

    public void ComprarBarreira()
    {
        if (auxCannon.PontosTotais >= 1000)
        {
            Barreira=true;
            auxCannon.PontosTotais -= 1000;
        }
    }
}
