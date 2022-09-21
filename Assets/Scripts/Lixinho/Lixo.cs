using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lixo : MonoBehaviour
{
    public Transform[] ponto; // lugares que o lixo deve ficar
    Vector3 escalaInicialLixeira = new Vector3(0.054586f, 0.34852f, 0.30219f);
    int passou = 0; // status do lixo
    public string tipo; // 0 = lixeira 1 (papel) // 1 = lixeira 2 (metal) // 2 = lixeira 3 (plástico) // 3 = lixeira 4 (orgânico)
    Collider colisao;
    Draggable dragcs;

    void Start() => dragcs = GetComponent<Draggable>();
    
    void Update() 
    {
        if (ponto[0] != null)
        {
            if (this.passou == 0 && tipo == colisao.name) // vai lansar o lixo
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
                colisao.gameObject.GetComponent<Animator>().enabled = false;
                colisao.gameObject.GetComponent<Transform>().localScale = escalaInicialLixeira; 
                Destroy(this.gameObject); // destroi desintegra oblitera ele :)
            } 
        }
    }

    // pra saber quando soltou o mouse, só essa gambiarra funfou :|
    public int mouseStatus = 0;
    void OnMouseDrag() { mouseStatus = 1; }
    void OnMouseUp() { if (mouseStatus == 1) { mouseStatus = 2; } }
    //

    void OnTriggerStay(Collider col)
    {
        if (col.name.Contains("Lixeira"))
        {
            colisao = col;
            gameObject.GetComponent<Animator>().enabled = true; // chama a animacao
            
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
        if (col.name.Contains("Lixeira"))
        {
            col.gameObject.GetComponent<Animator>().enabled = false;
            col.gameObject.GetComponent<Transform>().localScale = escalaInicialLixeira; 
        }
    }
}
