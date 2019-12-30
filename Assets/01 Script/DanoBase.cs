using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoBase : MonoBehaviour {
    public CannonBehaviour auxCannon;
    public Spawn auxSpawn;
    // Use this for initialization
    void Start () 
    {
        auxSpawn = GameObject.Find("Spawn").GetComponent<Spawn>();
        auxCannon = GameObject.Find("Buster").GetComponent<CannonBehaviour>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Inimigo")
        {
            auxCannon.vidaCur -= 10;
            auxSpawn.inimigosMorto++;
            Debug.Log("danoBase");
            Destroy(other.gameObject);
        }
    }
}
