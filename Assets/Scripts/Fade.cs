using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public string cena_ = "";
    public Image img;

    public void ChangeScene(string cena)
    {
        cena_ = cena;
        StartCoroutine(FadeImage());
    }
 
    IEnumerator FadeImage()
    {
        this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("s", true);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(cena_);
    }
}
