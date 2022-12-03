using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resposta : MonoBehaviour
{
    public int num_;
    private Caixa box;
    public GameObject[] opcs;
    
    void Awake() => box = GameObject.FindGameObjectWithTag("caixa").GetComponent<Caixa>();

    public void Check()
    {
        if (this.num_ == box.total)
        {
            print("certo");

            this.gameObject.transform.GetChild(2).GetComponent<ParticleSystem>().Play();

            GameObject[] lanches = GameObject.FindGameObjectsWithTag("lanche");
            foreach (GameObject item in lanches) { Destroy(item); }

            box.total = 0;
            box.next = 0;
            box.repeticao++;
            StartCoroutine("Wait", .4f);
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
        yield return new WaitForSeconds(.4f);
        for (int i = 0; i < 3; i++)
        {
            opcs[i].gameObject.GetComponent<Button>().interactable = true;
        }
        box.opc.SetActive(false);
    }
}
