using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour {
    public CannonBehaviour auxCannon;
    public GameObject[] Points;
    public GameObject[] inimigos;
    public int ondaAtual=1;
    public int totalInimigos=5;
    public int qntInimigos=0;
    public int inimigosMorto=0;
    public Text ondaText;
    public int inimigotual;
    // Use this for initialization
    void Start () {
        auxCannon = GameObject.Find("Buster").GetComponent<CannonBehaviour>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        ondaText.text = " " + ondaAtual;

        if (inimigosMorto >= (ondaAtual * totalInimigos))
        {
            NovaOnda();
        }
  

        if (qntInimigos < (ondaAtual * totalInimigos))
        {
            inimigotual = Random.Range(0, 2);
            Debug.Log(inimigotual);
            int PointAtual = Random.Range(0, 4);
            int velocidade = Random.Range(1, 4);

            GameObject newEnemy =Instantiate(inimigos[inimigotual], Points[PointAtual].transform.position, Points[PointAtual].transform.rotation);
            newEnemy.GetComponent<InimigoBehaviour>().velocidade = velocidade;
            newEnemy.GetComponent<InimigoBehaviour>().agente.speed = velocidade;

            //Debug.Log("speed = " + speed);
     

         
            qntInimigos++;
        }
	}

    public void NovaOnda()
    {
        auxCannon.vidaCur += 10;
        inimigosMorto = 0;
        qntInimigos = 0;
        ondaAtual++;
    }
}
