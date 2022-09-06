using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caixa : MonoBehaviour
{
    public int total = 0, preco = 0, next = 0, bNext = 0; // next (proximo lanche) / bnext (lanche anterior)
    public GameObject prefab, spawn, opc; // prefab (lanche) / spawn (ponto de spawn) / opc (botao de escolha)
    public GameObject[] opcoes; // botoes de escolha
    int[] resposta; // numeros que vao nos botoes
    Text texto; // soma na tela
    
    void Awake()
    {
        resposta = new int[3];
        bNext = next;
        texto = GameObject.FindGameObjectWithTag("total").GetComponent<Text>();
        opc = GameObject.Find("opcoes");
        opc.SetActive(false);
    }

    void Update()
    {
        if (bNext != next && next < 2) // se passou um produto
        {
            Instantiate(prefab, spawn.transform.position, Quaternion.identity); // spawna um novo
            bNext = next; 
        }

        if (next == 1) { texto.text = preco.ToString(); } // texto inicial
        else if (next == 2) // acaba a soma
        {
            int num = Random.Range(0, resposta.Length-1);
            resposta[num] = total; // resposta certa
            //opcoes[num].GetComponent<Text>.text = resposta[num].ToString();
            for (int i = 0; i < resposta.Length; i++)
            { 
                if (resposta[i] == 0) 
                {
                    resposta[i] = Random.Range(0, 100); // resposta errada
                    //opcoes[i].GetComponent<Text>.text = resposta[i];
                } 
            } 
            texto.text = (total - preco).ToString() + " + " + preco.ToString(); // atualiza a soma
            opc.SetActive(true); // mostra os botoes
        }
    }
}
