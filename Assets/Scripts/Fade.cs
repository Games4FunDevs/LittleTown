using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public string fadeStatus = "", cena_ = "";
    public Image img;
    
    // void Awake()
    // {
    //     this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("s", false);
    // }

    // public void OnEnable()
    // {
    //     SceneManager.sceneLoaded += OnSceneLoaded;
    // }

    // void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    // {
    //     StartCoroutine(FadeImage(true));
    // }

    // void Update()
    // {
        
    // }

    public void ChangeScene(string cena)
    {
        cena_ = cena;
        StartCoroutine(FadeImage());
    }
 
    IEnumerator FadeImage()//bool fadeAway
    {
        // // fade from opaque to transparent
        // if (fadeAway)
        // {
        //     print("abre");
        //     // loop over 1 second backwards
        //     for (float i = 1; i >= 0; i -= Time.deltaTime)
        //     {
        //         // set color with i as alpha
        //         img.color = new Color(0, 0, 0, i);
        //         yield return null;
        //     }
        // }
        // // fade from transparent to opaque
        // else
        // {
        //     print("fecha");
        //     // loop over 1 second
        //     for (float i = 0; i <= 1; i += Time.deltaTime)
        //     {
        //         // set color with i as alpha
        //         img.color = new Color(0, 0, 0, i);
        //         yield return null;
        //     }
            
            this.gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("s", true);
            yield return new WaitForSeconds(0.4f);
            SceneManager.LoadScene(cena_);
        // }
    }
}
