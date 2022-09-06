using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resposta : MonoBehaviour
{
    int num;
    Caixa box;
    
    void Start()
    {
        box = GameObject.FindGameObjectWithTag("caixa").GetComponent<Caixa>();
        num = int.Parse(this.transform.GetChild(0).GetComponent<Text>().text);
    }

    void Check()
    {
        if (num == box.total)
        {
            print("certo");
        }
        else
        {
            print("errado");
        }
    }
}
