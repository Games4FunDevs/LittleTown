using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Caixa : MonoBehaviour
{
    public int total = 0, preco = 0, next = 0, bNext = 0, repeticao = 0; // next (proximo lanche) / bnext (lanche anterior)
    public GameObject[] prefab;
    public GameObject spawn, opc; // prefab (lanche) / spawn (ponto de spawn) / opc (botao de escolha)
    public GameObject[] opcoes; // botoes de escolha
    private int[] resposta; // numeros que vao nos botoes
    private Text texto; // soma na tela
    private GameObject fadecs;
    private Animator anim;
    private AudioSource som;
    
    void Awake()
    {
        resposta = new int[3];
        som = GetComponent<AudioSource>();
        bNext = next;
        texto = GameObject.FindGameObjectWithTag("total").GetComponent<Text>();
        opc = GameObject.Find("opcoes");
        opc.SetActive(false);
        fadecs = GameObject.Find("Fade"); 
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (repeticao >= 3) 
        { 
            PlayerPrefs.SetString("Minigame_Loja", "Finalizado");
            fadecs.GetComponent<Fade>().ChangeScene("Hub"); 
        } 

        if (bNext != next && next < 2) // se passou um produto
        {
            Instantiate(prefab[Random.Range(0, 3)], spawn.transform.position, Quaternion.identity); // spawna um novo
            bNext = next; 
        }

        if (next == 0) { texto.text = "0"; }
        if (next == 1) { texto.text = preco.ToString(); } // texto inicial
        if (next == 2) // acaba a soma
        {
            for (int i = 0; i < resposta.Length; i++)
            { 
                if (resposta[i] == 0)
                {
                    resposta[i] = Random.Range(0, 40); // resposta errada
                    opcoes[i].transform.GetChild(0).GetComponent<Text>().text = resposta[i].ToString(); // passa pro botao
                }
            } 

            int num = Random.Range(0, 3); // escolhe uma das opcoes pra ser a certa
            resposta[num] = total; // resposta certa
            opcoes[num].transform.GetChild(0).GetComponent<Text>().text = resposta[num].ToString(); // passa pro botao
            opcoes[num].GetComponent<Resposta>().num_ = int.Parse(opcoes[num].transform.GetChild(0).GetComponent<Text>().text); // atualiza var da resposta
            
            for (var i = 0; i < resposta.Length; i++)
            {
                if (i != num)
                {
                    while (resposta[num].Equals(resposta[i]))
                    {
                        resposta[i] = Random.Range(0, 40); // resposta errada
                        opcoes[i].transform.GetChild(0).GetComponent<Text>().text = resposta[i].ToString(); // passa pro botao
                    }
                }
            }

            texto.text = (total - preco).ToString() + " + " + preco.ToString() + " = ? "; // atualiza a soma
            opc.SetActive(true); // mostra os botoes
            next = 3; // pra n ficar chamando direto no update
        }

        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "lanche")
        {
            anim.SetInteger("a", 1);
            som.Play();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "lanche")
        {
            anim.SetInteger("a", 0);
        }
    }
}
