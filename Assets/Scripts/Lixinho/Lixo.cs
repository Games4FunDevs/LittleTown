using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lixo : MonoBehaviour
{
    public Transform[] ponto; // lugares que o lixo deve ficar
    Vector3 escalaInicialLixeira = new Vector3(0.054586f, 0.34852f, 0.30219f);
    public int passou = 0, y = -1; // status do lixo
    public string tipo; // 0 = lixeira 1 (papel) // 1 = lixeira 2 (metal) // 2 = lixeira 3 (plástico) // 3 = lixeira 4 (orgânico)
    Collider colisao;
    Draggable dragcs;
    bool x = true;

    public Color objectColor;
    public Color fadeColor = Color.red;
    private Color targetColor = Color.white;
    public float fadeTime = 1f;
    public float fadeStart = 0, timePassed;

    void Start() => dragcs = GetComponent<Draggable>();
    
    void Update() 
    {
        print(y);
        if (y == 1) 
        {
            if (timePassed > 0) // fade white
            {
                timePassed -= Time.deltaTime;
                colisao.GetComponent<MeshRenderer>().material.color = Color.Lerp(objectColor, objectColor, timePassed / fadeTime);
            }
            else
            {
                y = -1; // null
            }
        }

        if (y == 0)
        {
            if (timePassed < fadeTime) // fade red
            {
                timePassed += Time.deltaTime;
                colisao.GetComponent<MeshRenderer>().material.color = Color.Lerp(objectColor, fadeColor, timePassed / fadeTime);
            }
            else if (timePassed >= fadeTime)
            {
                y = 1; // fade white
            }
        }

        if (ponto[0] != null)
        {
            if (this.passou == 0 && this.tipo == this.colisao.name) // vai lansar o lixo
            {
                this.gameObject.GetComponent<Rigidbody>().useGravity = false;
                this.transform.position = Vector3.MoveTowards(transform.position, ponto[0].position, 3 * Time.deltaTime); // fica no ponto inicial
                if (this.x == true)
                {
                    this.colisao.gameObject.transform.Find("ringParticle").GetComponent<ParticleSystem>().Play();
                    this.x = false;
                }
            } 
            if (this.passou == 0 && tipo != colisao.name && y == -1)
            {
                y = 0; // fade red
                //colisao.gameObject.GetComponent<Animator>().SetInteger("s", 2);
            }

            if (this.transform.position == ponto[0].position) { passou = 1; x = true; } // vai pro proximo ponto
            if (passou == 1)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                transform.position = Vector3.MoveTowards(transform.position, ponto[1].position, 3 * Time.deltaTime); // vai pro ponto 2
            }
            if (this.transform.position == ponto[1].position) 
            { 
                colisao.gameObject.GetComponent<Transform>().localScale = escalaInicialLixeira; 
                colisao.gameObject.GetComponent<Animator>().SetInteger("s", 0);
                Destroy(this.gameObject); // destroi desintegra oblitera ele :)
            } 
        }
    }

    // IEnumerator fadered()
    // {
    //     if (timePassed < fadeTime) 
    //     {
    //         timePassed += Time.deltaTime;
    //         colisao.GetComponent<MeshRenderer>().material.color = Color.Lerp(objectColor, fadeColor, timePassed / fadeTime);
    //     }
    //     yield return new WaitForSeconds(1f);
    //     if (timePassed < fadeTime) 
    //     {
    //         timePassed += Time.deltaTime;
    //         colisao.GetComponent<MeshRenderer>().material.color = Color.Lerp(objectColor, objectColor, timePassed / fadeTime);
    //     }
    // }

    // pra saber quando soltou o mouse, só essa gambiarra funfou :|
    public int mouseStatus = 0;
    void OnMouseDrag() { mouseStatus = 1; }
    void OnMouseUp() { if (mouseStatus == 1) { mouseStatus = 2; } }
    //

    void OnTriggerEnter(Collider col)
    {
        if (col.name.Contains("Lixeira"))
        {
            colisao = col;
            col.gameObject.GetComponent<Animator>().SetInteger("s", 1);; // chama a animacao
            objectColor = col.gameObject.GetComponent<MeshRenderer>().material.color;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.name.Contains("Lixeira"))
        {
            colisao = col;
            
            if (mouseStatus == 2) // se soltou o mouse
            {
                for (int j = 0; j < col.gameObject.transform.childCount - 1; j++) // pega os pontos
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
            col.gameObject.GetComponent<Animator>().SetInteger("s", 0);
            col.gameObject.GetComponent<Transform>().localScale = escalaInicialLixeira; 
            
            if (y == 2) { y = 0; }
        }
    }
}
