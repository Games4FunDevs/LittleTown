using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public bool menu = false, open = true;
    public GameObject caderno, op1, op2, t1, t2;
    EventSystem current;

    void Awake()
    {
        current = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            MenuPanel();
        }
    }

    public void MenuPanel()
    {
        if (menu != !menu) { menu = !menu; } 
        open = true;
        caderno.SetActive(menu);
        Telas();

        // pausa
        if (SceneManager.GetActiveScene().name == "semaforos" && menu == true)
        { Time.timeScale = 0; }
        else { Time.timeScale = 1; }
    }

    public void Telas()
    {
        //if (tela != !tela) { tela = !tela; } 
        if (open == true || current.currentSelectedGameObject.name == "op1") 
        { 
            t1.SetActive(true);
            t2.SetActive(false); 
            op1.GetComponent<Image>().color = Color.green;
            op2.GetComponent<Image>().color = Color.white;
            open = false;
        } 
        else if (current.currentSelectedGameObject.name == "op2") 
        {
            t1.SetActive(false);
            t2.SetActive(true); 
            op1.GetComponent<Image>().color = Color.white;
            op2.GetComponent<Image>().color = Color.green;
        }
    }
}
