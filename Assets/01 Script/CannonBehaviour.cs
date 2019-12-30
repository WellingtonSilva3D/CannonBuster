using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CannonBehaviour : MonoBehaviour {

    public GameObject[] tiro;
    public int tiroAtual;
    public GameObject pTiro;
    public int vidaCur;
    public int vidaTotal;
    public Text vidaBase;
    public Text Pontos;
    public int PontosTotais;
    public Loja auxLoja;
    public Transform pointSpawnItens;

    public float forcadeLancamento;
    public float tempoPorLançamento;
    public bool lancouGranada;
    float cronometroGranada = 0;

    public GameObject Barreira;
    public float TempoBarreira;
    public float curTempoBarreira;

    public AudioSource auxAudio;
    public AudioClip[] sons; 
    
    // Use this for initialization
    void Start () {
        vidaCur = vidaTotal;
        auxAudio = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () 
    {
        auxLoja = GameObject.Find("Loja").GetComponent<Loja>();
        FaceMouse();
        Atirar();
        Pontos.text = "" + PontosTotais;
        vidaBase.text = " " + vidaCur +"%";
    }

    public void FaceMouse()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            
            if(Input.GetButtonDown("Button1"))
            {
                if(auxLoja.mina >=1)
                {
                   Instantiate(auxLoja.minaPrefab, pointToLook, transform.rotation);
                    auxLoja.mina--;
                }
            }

            if (Input.GetButtonDown("Button2"))
            {
                if (auxLoja.granada >= 1)
                {
                   GameObject NewGranada = Instantiate(auxLoja.granadaPrefab, pTiro.transform.position, transform.rotation);
                    auxLoja.granada--;
                    NewGranada.GetComponent<Rigidbody>().AddForce(pTiro.transform.forward * forcadeLancamento, ForceMode.Impulse);

                }
            }

            if (Input.GetButtonDown("Button3"))
            {
                if (PontosTotais >= 100)
                {
                    auxAudio.clip = sons[0];
                    auxAudio.Play();
                    vidaCur += 50;
                    PontosTotais -= 100;
                }    
            }

            if (Input.GetButtonDown("Button4"))
            {
                
               
                if (PontosTotais >= 1000)
                {
                    auxLoja.ComprarBarreira();
                   
                    if (auxLoja.Barreira)
                    {
                        auxAudio.clip = sons[1];
                        auxAudio.Play();
                        Barreira.GetComponent<Animator>().SetBool("Open/Closset", true);
                    }
                }
            }
            if(auxLoja.Barreira)
            {
                curTempoBarreira += Time.deltaTime;
                if(curTempoBarreira >= TempoBarreira)
                {
                    Barreira.GetComponent<Animator>().SetBool("Open/Closset", false);
                }
            }
        }
    }


    public void Atirar()
    {
        if(Input.GetMouseButtonDown(0))
        {
           
            Instantiate(tiro[tiroAtual], pTiro.transform.position, pTiro.transform.rotation);
        }
    }
}
