using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    //
    // código do caderno
    //

    public bool menu = false, open = true;
    public GameObject caderno, op1, op2, t1, t2, txt1;
    private EventSystem current;
    private Controles controles;
    public TextMeshProUGUI texto;

    void Awake()
    {
        current = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        controles = new Controles();
        controles.Enable();
        texto.text = "Coletar lixos: " + PlayerPrefs.GetInt("lixos").ToString() + "/5";
        if (PlayerPrefs.GetInt("lixos") >= 4)
        {
            txt1.SetActive(true);
        }
    }

    void Update()
    {
        if (controles.ActionMap.Menu.triggered) 
            MenuPanel();

        if (PlayerPrefs.GetString("j1") == "true")
            t1.gameObject.transform.GetChild(4).GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;

        if (PlayerPrefs.GetString("j2") == "true")
            t1.gameObject.transform.GetChild(3).GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;

        if (PlayerPrefs.GetString("j4") == "true")
            t1.gameObject.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
    
        if (PlayerPrefs.GetInt("lixos") >= 5)
            t1.gameObject.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;

        if (t1.gameObject.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().fontStyle == FontStyles.Strikethrough &&
            t1.gameObject.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().fontStyle == FontStyles.Strikethrough &&
            t1.gameObject.transform.GetChild(3).GetComponentInChildren<TextMeshProUGUI>().fontStyle == FontStyles.Strikethrough &&
            t1.gameObject.transform.GetChild(4).GetComponentInChildren<TextMeshProUGUI>().fontStyle == FontStyles.Strikethrough)
        {
            SceneManager.LoadScene("End");
        }
    }

    public void MenuPanel()
    {
        if (menu != !menu) { menu = !menu; } 
        open = true;
        caderno.SetActive(menu);
        Telas();

        // pausa
        if (SceneManager.GetActiveScene().name == "semaforos" && menu == true) Time.timeScale = 0; 
        else Time.timeScale = 1;
    }

    public void Telas()
    {
        if (open == true || current.currentSelectedGameObject.name == "op1") 
        { 
            t1.SetActive(true);
            if (PlayerPrefs.GetInt("lixos") >= 4)
            {
                txt1.SetActive(true);
            }
            t2.SetActive(false); 
            //op1.GetComponent<Image>().color = Color.green;
            //op2.GetComponent<Image>().color = Color.white;
            op1.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            op2.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            op1.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0);
            op2.gameObject.transform.localScale = new Vector3(0.08f, 0.08f, 0);
            open = false;
        } 
        else if (current.currentSelectedGameObject.name == "op2") 
        {
            t1.SetActive(false);
            t2.SetActive(true); 
            //op1.GetComponent<Image>().color = Color.white;
            //op2.GetComponent<Image>().color = Color.green;
            op1.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            op2.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            op1.gameObject.transform.localScale = new Vector3(0.08f, 0.08f, 0);
            op2.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0);
        }
    }
}
