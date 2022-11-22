using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Billboard : MonoBehaviour
{
    public GameObject player, t1;
    public Fade fadecs;
    private bool colideLixo = false;
    public float distancia = 9f;

    private Controles controles;

    void Awake()
    {
        player = GameObject.Find("Player");
        fadecs = GameObject.Find("Fade").GetComponent<Fade>();
        controles = new Controles();
        controles.Enable();
    }

    void Update() 
    {
        if (Vector3.Distance(this.transform.position, this.player.transform.position) < distancia)
        {
            transform.LookAt(Camera.main.transform.position, Vector3.up);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Interagiu();
        }
        else { this.gameObject.transform.GetChild(0).gameObject.SetActive(false); }
    }

    void Interagiu()
    {
        if (colideLixo == false && controles.ActionMap.Interagir.ReadValue<float>() > 0)
        {
            switch (this.gameObject.transform.parent.tag) 
            {
                case "j1": // minigame da loja
                    if (this.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true)
                    {
                        PlayerPrefs.SetString("j1", "true");
                        fadecs.ChangeScene("loja"); 
                    }
                break;
                case "j4":
                    if (PlayerPrefs.GetInt("lixos") >= 4 && this.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true)
                    {
                        PlayerPrefs.SetString("j4", "true");
                        fadecs.ChangeScene("lixo"); 
                    }
                break;
                case "j2":
                    if (this.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true)
                    {
                        PlayerPrefs.SetString("j2", "true");
                        fadecs.ChangeScene("semaforos"); 
                    }
                break;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "lixo") colideLixo = false; 
        else colideLixo = true; 
    }
}