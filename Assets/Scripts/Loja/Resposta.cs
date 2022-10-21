using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resposta : MonoBehaviour
{
    public int num_;
    private Caixa box;
    
    void Awake() => box = GameObject.FindGameObjectWithTag("caixa").GetComponent<Caixa>();

    public void Check()
    {
        if (this.num_ == box.total)
        {
            print("certo");

            GameObject[] lanches = GameObject.FindGameObjectsWithTag("lanche");
            foreach (GameObject item in lanches) { Destroy(item); }

            box.total = 0;
            box.next = 0;
            box.repeticao++;
            box.opc.SetActive(false);
        }
        else
        {
            print("errado");
        }
    }
}
