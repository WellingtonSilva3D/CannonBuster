using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinaTerrestre : MonoBehaviour {

    public GameObject explosionParticula;
    public float areaExplosão=7;
    public float forcadaExplosao=7;
    bool explodiu = false;

    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void explodir(Vector3 centro, float raio)
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
