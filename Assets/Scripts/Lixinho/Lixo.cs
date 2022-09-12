using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lixo : MonoBehaviour
{
    public Transform[] ponto; // lugares que o lixo deve ficar
    Vector3 escalaInicialLixeira = new Vector3(1.5392f, 1.5392f, 1.5392f);
    int passou = 0; // status do lixo
    public int tipo = 0; // 0 = lixeira 1 (papel) // 1 = lixeira 2 (metal) // 2 = lixeira 3 (plástico) // 3 = lixeira 4 (orgânico)
    //LixoMinigame lixocs;

    void Awake() 
    {
        // lixocs = GameObject.Find("GameManager").GetComponent<LixoMinigame>();
    }

    void Update() 
    {
        if (ponto[0] != null)
        {
            if (this.passou == 0) // vai lansar o lixo
            {
                this.gameObject.GetComponent<Rigidbody>().useGravity = false;
                this.transform.position = Vector3.MoveTowards(transform.position, ponto[0].position, 3 * Time.deltaTime); // fica no ponto inicial
            } 
            if (this.transform.position == ponto[0].position) { passou = 1; } // vai pro proximo ponto
            if (passou == 1)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                this.transform.position = Vector3.MoveTowards(transform.position, ponto[1].position, 3 * Time.deltaTime); // vai pro ponto 2
            }
            if (this.transform.position == ponto[1].position) 
            { 
                //lixocs.qtdLixo--;
                Destroy(this.gameObject); // destroi desintegra oblitera ele :)
            } 
        }
    }

    // pra saber quando soltou o mouse, só essa gambiarra funfou :|
    public int mouseStatus = 0;
    void OnMouseDown() { mouseStatus = 1; }
    void OnMouseUp() { if (mouseStatus == 1) { mouseStatus = 2; } }
    //

    void OnTriggerStay(Collider col)
    {
        if (col.name == "Lixeira2" || col.name == "Lixeira1" || col.name == "Lixeira3")
        {
            col.gameObject.GetComponent<Animator>().enabled = true; // chama a animacao
            if (mouseStatus == 2) // se soltou o mouse
            {
                for (int j = 0; j < col.gameObject.transform.childCount; j++) // pega os pontos
                { 
                    ponto[j] = col.transform.GetChild(j).transform; 
                } 
            }
        }
    }
    void OnTriggerExit(Collider col)
    {   // para a animacao
        if (col.name == "Lixeira2" || col.name == "Lixeira1" || col.name == "Lixeira3")
        {
            col.gameObject.GetComponent<Animator>().enabled = false;
            col.gameObject.GetComponent<Transform>().localScale = escalaInicialLixeira;
        }
    }
}
