using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lixo : MonoBehaviour
{
    public Transform[] ponto; // lugares que o lixo deve ficar
    public int passou = 0; // y = -1; // status do lixo
    public string tipo; // 0 = lixeira 1 (papel) // 1 = lixeira 2 (metal) // 2 = lixeira 3 (plástico) // 3 = lixeira 4 (orgânico)
    
    public Collider colisao, colisao_;
    private Draggable dragcs;
    public bool x = true, canDo = false;

    void Awake() => dragcs = GetComponent<Draggable>();
    
    void Update() 
    {
        if (ponto[0] != null) // se não saiu do ponto de spawn / não lançou lixo
        {
            if (this.passou == 0 && this.tipo == this.colisao.name && dragcs.m == 1) // vai lançar o lixo
            { this.canDo = true; } // pode enviar lixo
            else if (this.passou == 0 && this.tipo != this.colisao.name)
            { this.canDo = false; } // não pode enviar lixo

            if (this.canDo == true)
            {   // move para cima da lixeira
                this.transform.position = Vector3.MoveTowards(transform.position, ponto[0].position, 3 * Time.deltaTime); // fica no ponto inicial
                if (this.x == true) // acertou
                {   // efeito de partícula
                    this.colisao.gameObject.transform.Find("ringParticle").GetComponent<ParticleSystem>().Play();
                    this.x = false; 
                }
            }
            // vai pro proximo ponto 
            if (this.gameObject.transform.position == ponto[0].position) { this.passou = 1; } 
            
            if (this.passou == 1)
            {   // vai pra dentro da lixeira
                //this.gameObject.GetComponent<BoxCollider>().enabled = false;
                this.transform.position = Vector3.MoveTowards(transform.position, ponto[1].position, 10 * Time.deltaTime); // vai pro ponto 2
            }
            
            if (colisao_.name.Contains("destroi")) // destroi o lixo
            { 
                this.colisao.gameObject.transform.Find("Lixeira").gameObject.GetComponent<Animator>().SetInteger("s", 0);
                Destroy(this.gameObject); // destroi desintegra oblitera ele :)
            }

            if (this.transform.position.y >= 2) // bug fix lixo voando para cima
            {
                this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    // pra saber quando soltou o mouse, só essa gambiarra funfou :|
    public int mouseStatus = 0;
    void OnMouseDrag() 
    { 
        mouseStatus = 1; 
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;  
    }
    void OnMouseUp() 
    {
        if (this.tipo != this.colisao.name && dragcs.m == 1)
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
        mouseStatus = 2; 
    }

    void OnTriggerEnter(Collider col)
    {
        colisao_ = col;
        if (col.name.Contains("Lixeira"))
        {
            colisao = col;
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.name.Contains("Lixeira"))
        {
            colisao = col;

            if (dragcs.beingDrag == true)
            {
                col.gameObject.transform.Find("Lixeira").gameObject.GetComponent<Animator>().SetInteger("s", 1);; // chama a animacao
            }
            
            if (mouseStatus == 2) // se soltou o mouse
            {
                for (int j = 0; j < col.gameObject.transform.childCount - 2; j++) // pega os pontos
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
            col.gameObject.transform.Find("Lixeira").gameObject.GetComponent<Animator>().SetInteger("s", 0);
        }
    }
}
