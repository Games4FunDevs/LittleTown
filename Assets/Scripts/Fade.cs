using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public string cena_ = "";
    public GameObject sound;
    static Fade instance;

    void Start()
    {
        sound = GameObject.Find("Sound");
        
        if (instance == null)
        {    
            instance = this; // In first scene, make us the singleton.
            DontDestroyOnLoad(sound);
        }
        else if(instance != this)
            Destroy(sound); // On reload, singleton already set, so destroy duplicate.
    }

    public void ChangeScene(string cena)
    {
        cena_ = cena;
        StartCoroutine(FadeImage());
    }

    public void CloseApp() => StartCoroutine(CloseImage());

    IEnumerator FadeImage()
    {
        Time.timeScale = 1;
        this.gameObject.transform.GetChild(5).GetComponent<Animator>().SetBool("s", true);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(cena_);
    }

    IEnumerator CloseImage()
    {
        yield return FadeImage();
        Application.Quit();
    }
}
