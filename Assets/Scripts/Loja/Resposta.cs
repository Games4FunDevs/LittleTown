using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resposta : MonoBehaviour
{
    public int num_;
    private Caixa box;
    public GameObject[] opcs;
    private AudioSource som;
    
    void Awake() 
    {
        box = GameObject.FindGameObjectWithTag("caixa").GetComponent<Caixa>();
        som = GetComponent<AudioSource>();
    }

    public void Check()
    {
        if (this.num_ == box.total)
        {
            print("certo");

            som.Play();

            this.gameObject.transform.GetChild(2).GetComponent<ParticleSystem>().Play();

            GameObject[] lanches = GameObject.FindGameObjectsWithTag("lanche");
            foreach (GameObject item in lanches) { Destroy(item); }

            box.total = 0;
            box.next = 0;
            box.repeticao++;
            StartCoroutine("Wait", .6f);
        }
        else
        {
            print("errado");
        }
    }

    IEnumerator Wait()
    {
        for (int i = 0; i < 3; i++)
        {
            opcs[i].gameObject.GetComponent<Button>().interactable = false;
        }
        yield return new WaitForSeconds(.6f);
        for (int i = 0; i < 3; i++)
        {
            opcs[i].gameObject.GetComponent<Button>().interactable = true;
        }
        box.opc.SetActive(false);
    }
}
