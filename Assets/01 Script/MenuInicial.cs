using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInicial : MonoBehaviour {

    public int paginaAtual;

    public GameObject tutorial;
    public Sprite[] paginas;
    public GameObject tela;
    public GameObject voltar;
    public GameObject proximo;
    // Use this for initialization
    void Start () 
    {
        tutorial.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (paginaAtual == 0)
        {
            voltar.transform.GetChild(0).GetComponent<Text>().text = "Sair";
        }
        else
        {
            voltar.transform.GetChild(0).GetComponent<Text>().text = "Voltar";
        }
        if (paginaAtual == 3)
        {
            proximo.transform.GetChild(0).GetComponent<Text>().text = "Sair";
        }
        else
        {
            proximo.transform.GetChild(0).GetComponent<Text>().text = "Proximo";
        }
    }

    public void chamarTutorial()
    {
        tutorial.SetActive(true);
    }
    public void ProximaPagina()
    {
        if (paginaAtual == 3)
        {
            paginaAtual=0;
            tutorial.SetActive(false);
        }
        else
        {
            paginaAtual++;
        }
        tela.GetComponent<Image>().sprite = paginas[paginaAtual];
    }
    public void VoltarPagina()
    {
        if(paginaAtual == 0)
        {
          
            tutorial.SetActive(false);
        }
        else
        {
            paginaAtual--;
        }
        tela.GetComponent<Image>().sprite = paginas[paginaAtual];
    }

    public void IniciarGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Fase1");
    }
}
