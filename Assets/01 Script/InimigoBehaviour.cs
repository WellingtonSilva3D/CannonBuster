using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class InimigoBehaviour : MonoBehaviour {
    public int pathAtualIndex;
    public GameObject[] path;
    public CannonBehaviour auxCannon;
    public Spawn auxSpawn;
    public GameObject pathAtual;
    public NavMeshAgent agente;
    public Animator anim;
    public int velocidade;
    public int AnimAtual;
    public int indexpath;
    public bool encostou;
    public int vidaAtual;
    public int vidaTotal;
    public Image barraVida;
    public CapsuleCollider col;
    public float tempoMorto;
    public bool estamorto;
    // Use this for initialization
    void Start () 
    {
        vidaAtual = vidaTotal;
        col = GetComponent<CapsuleCollider>();
        barraVida.fillAmount = vidaAtual / vidaTotal;
       // agente = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        auxSpawn  = GameObject.Find("Spawn").GetComponent<Spawn>();
        auxCannon = GameObject.Find("Buster").GetComponent<CannonBehaviour>();
        path[0] = GameObject.Find("Path1");
        path[1] = GameObject.Find("Path2");
        path[2] = GameObject.Find("Path3");
        path[3] = GameObject.Find("Path4");
 
        indexpath = Random.Range(0, 4);
        agente.SetDestination(path[0].transform.GetChild(indexpath).position);

    }
	
	// Update is called once per frame
	void Update () 
    {
        barraVida.fillAmount = (float)vidaAtual / (float)vidaTotal;
        anim.SetFloat("Velocity", velocidade);
        if (vidaAtual <=0)
        {
            if(!estamorto)
            {
             auxCannon.PontosTotais += 10;
             auxSpawn.inimigosMorto++;
             estamorto = true;
            }
            anim.SetBool("die", true);
            agente.speed = 0;
            col.enabled=false;
            tempoMorto += Time.deltaTime; ;
            if(tempoMorto >=5)
            {
                Destroy(gameObject);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(!encostou && other.gameObject.tag=="path" && pathAtualIndex < 3)
        {
            Debug.Log ("encostou");
            indexpath = Random.Range(0, 4);
            pathAtualIndex++;
            agente.SetDestination(path[pathAtualIndex].transform.GetChild(indexpath).position);
            encostou = true;
        }

        if (other.gameObject.tag == "laser")
        {
            vidaAtual--;
            Debug.Log("tiro");
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Barrier")
        {           
            agente.speed = 0;            
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "path")
        { 
            Debug.Log("Nãoencostou");
            encostou = false;
        }

        if (other.gameObject.tag == "Barrier")
        {
            agente.speed = velocidade;
        }

    }
}
