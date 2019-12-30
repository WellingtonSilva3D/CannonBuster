using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    
    public float speed;
    public Rigidbody rig;
    public float tempocur;
    public float tempodes;
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        rig.velocity = transform.forward * speed;
        tempocur += Time.deltaTime;

        if (tempocur >= tempodes)
        {
            Destroy(gameObject);
        }
	}
}
