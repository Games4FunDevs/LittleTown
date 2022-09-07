using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanche : MonoBehaviour
{
    int passou = 0; // status da compra / 0 (ainda no caixa) / 1 (passou na máquina) / 2 (ta na sacola, terminou)
    [SerializeField] int preco = 0;
    public Transform[] ponto; // lugares que a compra deve ficar
    Draggable dragcs;
    GameObject caixacs;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        dragcs = GetComponent<Draggable>();
        caixacs = GameObject.FindGameObjectWithTag("caixa");
        this.preco = Random.Range(1, 10); // vai dar um preco aleatorio pra esse lanche
        for (int i = 0; i < caixacs.transform.childCount-1; i++) { ponto[i] = caixacs.transform.GetChild(i).transform; } 
    } 

    void Update()
    {
        if (this.passou == 0 && dragcs.mouseDown == false) // se ainda nao passou o lanche
        {
            this.transform.position = Vector3.MoveTowards(transform.position, ponto[0].position, 2 * Time.deltaTime); // fica no ponto inicial
        }
        if (this.passou == 1) // se passou na maquina
        {
            this.transform.position = Vector3.MoveTowards(transform.position, ponto[1].position, 2 * Time.deltaTime); // vai pro ponto da maquina
        }
        
        if (this.transform.position == ponto[1].position) // ao terminar de passar na maquina
        {
            this.passou = 2; // vai pra sacola
            anim.enabled = true;
            caixacs.GetComponent<Caixa>().preco = this.preco; // passa o preco pra maquina
            caixacs.GetComponent<Caixa>().total += this.preco;
            caixacs.GetComponent<Caixa>().next++; // passa pro proximo lanche
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("caixa")) // passou na maquina
        {
            this.passou = 1;
        }
    }
}
