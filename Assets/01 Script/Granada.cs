using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour {

    public float tempoExplosao =2;
    public GameObject explosionParticula;
    public float areaExplosão=7;
    public float forcadaExplosao=7;
    bool explodiu = false;

    float cronometro = 0;
    public AudioSource auxAudio;


    // Use this for initialization
    void Start () {
        auxAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        cronometro += Time.deltaTime;
        if(cronometro >= tempoExplosao && !explodiu)
        {
            explodiu = true;
            cronometro = 0;
           // auxAudio.Play();
            explodir(transform.position, areaExplosão);
        }

	}

    public void explodir(Vector3 centro, float raio)
    {
        Collider[] hitcollider = Physics.OverlapSphere(centro, raio); 
        for(int x=0; x<hitcollider.Length; x++)
        {
            
            if(hitcollider[x].gameObject.tag == "Inimigo")
            {
                Rigidbody tempRB = hitcollider[x].GetComponent<Rigidbody>();
                tempRB.AddExplosionForce(forcadaExplosao, transform.position,10,1, ForceMode.Impulse);
                hitcollider[x].GetComponent<InimigoBehaviour>().vidaAtual -= 100;
            }
        }
        if(explosionParticula)
        {
           GameObject particula = Instantiate(explosionParticula, transform.position, transform.rotation) as GameObject;
            Destroy(particula, 2);

        }
        Destroy(this.gameObject);
    }


        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Inimigo")
            {
                explodir(transform.position, areaExplosão);
            }
        }
    }
