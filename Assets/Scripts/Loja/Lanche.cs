using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanche : MonoBehaviour
{
    int passou = 0;
    [SerializeField] int preco = 0;
    public Transform[] ponto;
    Draggable dragcs;
    GameObject caixacs;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        dragcs = GetComponent<Draggable>();
        caixacs = GameObject.FindGameObjectWithTag("caixa");
        this.preco = Random.Range(1, 10);
        for (int i = 0; i < caixacs.transform.childCount; i++)
        {
            ponto[i] = caixacs.transform.GetChild(i).transform;
        }
    } 

    void Update()
    {
        if (this.passou == 0 && dragcs.mouseDown == false)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, ponto[0].position, 2 * Time.deltaTime);
        }
        if (this.passou == 1)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, ponto[1].position, 2 * Time.deltaTime);
        }
        
        if (this.transform.position == ponto[1].position)
        {
            this.passou = 2;
            anim.enabled = true;
            caixacs.GetComponent<Caixa>().preco = this.preco;
            caixacs.GetComponent<Caixa>().total += this.preco;
            caixacs.GetComponent<Caixa>().next++;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("caixa"))
        {
            this.passou = 1;
        }
    }
}
