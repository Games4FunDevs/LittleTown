using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    /*
    * esse scrpit fica no objeto do player, no hub
    * se movimenta pelo cenário e chama outra cena ao interagir com objetos de certa tag
    */

    float speed = 6f, rotSpeed = 150f, gravidade = 8f;
    Vector3 inputDir, v_velocity;
    CharacterController cc;

    void Awake() => cc = GetComponent<CharacterController>();

    void Update()
    {

    }

    void FixedUpdate()
    {   
        Movement();
        if (cc.isGrounded) { v_velocity.y = 0; }
        else { v_velocity.y -= gravidade * Time.deltaTime; }
    }

    void Movement()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 move = cc.transform.forward * input.y;
        cc.transform.Rotate(Vector3.up * input.x * (rotSpeed * Time.deltaTime));
        cc.Move(move * speed * Time.deltaTime);
        cc.Move(v_velocity);
    }

    void OnTriggerEnter(Collider col)
    {   // se colidir com objeto de certa tag
        switch (col.gameObject.tag) 
        {
            case "j1": // minigame da loja
                SceneManager.LoadScene("loja");
                break;
            case "j4":
                SceneManager.LoadScene("lixo");
                break;
        }
    }
}
