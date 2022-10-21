using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Billboard : MonoBehaviour
{
    private GameObject player;
    public Fade fadecs;
    private bool colideLixo = false;

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
        if (Vector3.Distance(this.transform.position, this.player.transform.position) < 6f)
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
                            fadecs.ChangeScene("loja"); 
                break;
                case "j4":
                    if (player.GetComponent<Play>().lixoColetado >= 4 && this.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true)
                            fadecs.ChangeScene("lixo");
                break;
                case "j2":
                    if (this.gameObject.transform.GetChild(0).gameObject.activeInHierarchy == true)
                            fadecs.ChangeScene("semaforos");
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