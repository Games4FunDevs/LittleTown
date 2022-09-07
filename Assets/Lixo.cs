using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lixo : MonoBehaviour
{
    public Transform[] ponto; // lugares que o lixo deve ficar
    int passou = 0; // status do lixo

    void Update() 
    {
        if (this.passou == 0 && ponto != null) // vai lansar o lixo
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = Vector3.MoveTowards(transform.position, ponto[0].position, 3 * Time.deltaTime); // fica no ponto inicial
        } // vai pro proximo ponto
        if (this.transform.position == ponto[0].position && ponto != null) { passou = 1; } 
        if (passou == 1)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.transform.position = Vector3.MoveTowards(transform.position, ponto[1].position, 3 * Time.deltaTime); // vai pro ponto 2
        }
        if (this.transform.position == ponto[1].position && ponto != null) { Destroy(this.gameObject); } // desintegra ele :)
    }

    // pra saber quando soltou o mouse, só essa gambiarra funfou :|
    public int mouseStatus = 0;
    void OnMouseDown() { mouseStatus = 1; }
    void OnMouseUp() { if (mouseStatus == 1) { mouseStatus = 2; } }

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
        }
    }
}
