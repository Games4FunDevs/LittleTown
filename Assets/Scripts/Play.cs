using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Play : MonoBehaviour
{
    /*
    * esse scrpit fica no objeto do player, no hub
    * se movimenta pelo cenário e chama outra cena ao interagir com objetos de certa tag
    */

    private float speed = 6f, rotSpeed = 2f, gravidade = 8f;
    private Vector3 v_velocity;
    private CharacterController cc;
    private Fade fadecs;
    private Controles controles;
    private Animator anim;

    public int lixoColetado = 0;
    public TextMeshProUGUI[] textos;
    bool coletou = false;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
        fadecs = GameObject.Find("Fade").GetComponent<Fade>();
        controles = new Controles();
        controles.Enable();
        anim = gameObject.transform.GetChild(0).GetComponentInChildren<Animator>();
        lixoColetado = PlayerPrefs.GetInt("lixos");
    }

    void FixedUpdate()
    {
        Movement();
        Gravidade();
    }

    void Movement()
    {
        Vector2 input = controles.ActionMap.Andar.ReadValue<Vector2>();
        Vector3 move = cc.transform.forward * input.y;
        transform.Rotate(Vector3.up * input.x * rotSpeed);
        cc.Move(move * speed * Time.deltaTime);
        cc.Move(v_velocity);

        if (input.x == 0 && input.y == 0)
        {
            anim.SetInteger("andar", 0);
        }
        else
        {
            anim.SetInteger("andar", 1);
        }
    }

    void Gravidade()
    {
        if (cc.isGrounded) { v_velocity.y = 0; }
        else { v_velocity.y -= gravidade * Time.deltaTime; }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "lixo" && controles.ActionMap.Interagir.ReadValue<float>() > 0 && coletou == false)
        {
            coletou = true;
            lixoColetado++;
            PlayerPrefs.SetInt("lixos", lixoColetado);
            textos[0].text = "Coletar lixos: " + lixoColetado + "/5";
            Destroy(col.gameObject);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "lixo")
        {
            coletou = false;
        }
    }
}