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

    // public Color objectColor;
    // public Color fadeColor = Color.red;
    // private Color targetColor = Color.white;
    // public float fadeTime = 1f;
    // public float fadeStart = 0, timePassed;

    void Awake() => dragcs = GetComponent<Draggable>();
    
    void Update() 
    {
        // if (y == 1) 
        // {
        //     if (timePassed > 0) // fade white
        //     {
        //         timePassed -= Time.deltaTime;
        //         colisao.gameObject.transform.Find("Lixeira").gameObject.GetComponent<MeshRenderer>().material.color 
        //             = Color.Lerp(objectColor, objectColor, timePassed / fadeTime);
        //     }
        //     else
        //     {
        //         y = 2; // null
        //     }
        // }

        // if (y == 0)
        // {
        //     if (timePassed < fadeTime) // fade red
        //     {
        //         timePassed += Time.deltaTime;
        //         colisao.gameObject.transform.Find("Lixeira").gameObject.GetComponent<MeshRenderer>().material.color 
        //             = Color.Lerp(objectColor, fadeColor, timePassed / fadeTime);
        //     }
        //     else if (timePassed >= fadeTime)
        //     {
        //         y = 1; // fade white
        //     }
        // }

        if (ponto[0] != null)
        {
            if (this.passou == 0 && this.tipo == this.colisao.name && dragcs.m == 1) // vai lansar o lixo
            { this.canDo = true; } 
            else if (this.passou == 0 && this.tipo != this.colisao.name)
            { this.canDo = false; }

            // if (this.passou == 0 && tipo != colisao.name && y == -1)
            // {
            //     y = 0; // fade red
            // }

            if (this.canDo == true)
            {
                this.transform.position = Vector3.MoveTowards(transform.position, ponto[0].position, 3 * Time.deltaTime); // fica no ponto inicial
                if (this.x == true)
                {
                    this.colisao.gameObject.transform.Find("ringParticle").GetComponent<ParticleSystem>().Play();
                    this.x = false;
                }
            }

            if (this.gameObject.transform.position == ponto[0].position) { this.passou = 1; } // vai pro proximo ponto
            
            if (this.passou == 1)
            {
                //this.gameObject.GetComponent<BoxCollider>().enabled = false;
                this.transform.position = Vector3.MoveTowards(transform.position, ponto[1].position, 10 * Time.deltaTime); // vai pro ponto 2
            }
            
            if (colisao_.name.Contains("destroi")) 
            { 
                this.colisao.gameObject.transform.Find("Lixeira").gameObject.GetComponent<Animator>().SetInteger("s", 0);
                Destroy(this.gameObject); // destroi desintegra oblitera ele :)
            }

            if (this.transform.position.y >= 2)
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
    //

    void OnTriggerEnter(Collider col)
    {
        colisao_ = col;
        if (col.name.Contains("Lixeira"))
        {
            colisao = col;
            // y = -1;
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            col.gameObject.transform.Find("Lixeira").gameObject.GetComponent<Animator>().SetInteger("s", 1);; // chama a animacao
            // objectColor = col.gameObject.transform.Find("Lixeira").gameObject.GetComponent<MeshRenderer>().material.color;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.name.Contains("Lixeira"))
        {
            colisao = col;
            
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
            
            // if (y == 2) { y = 0; }
        }
    }
}
