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

    [SerializeField] int speed = 5;
    float rotSpeed = 5f;
    Rigidbody rb;
    //CharacterController controller;
    //Vector3 point;
    //bool stop;
    Vector3 targetRotation;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        //controller = GetComponent<CharacterController>();
        // seta a posicao incial do player
        //point.x = this.transform.position.x;
        //point.z = this.transform.position.z;
        //point.y = 1f;
    }

    void FixedUpdate()
    {
        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 moveRaw =new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (move.sqrMagnitude > 1) { move.Normalize(); }
        if (moveRaw.sqrMagnitude > 1) { moveRaw.Normalize(); }
        //rb.MovePosition(transform.position + move * speed * Time.deltaTime);

        if (moveRaw != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(move).eulerAngles;
        }

        rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRotation.x, Mathf.Round(targetRotation.y / 45) * 45, targetRotation.z), Time.deltaTime * rotSpeed);

        rb.velocity = move * speed * Time.deltaTime;


        //transform.Rotate(0.0f, -move.x * speed, 0.0f);

        //controller.Move(move * Time.deltaTime * speed);

        //if (Input.GetMouseButtonDown(0)) 
        //{   // se clicou num lugar
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out hit)) { // pega esse ponto na cena
        //        point.x = hit.point.x;
        //        point.z = hit.point.z;
        //    }
        //}

        // if (stop == false)
        // {
        //transform.position = Vector3.MoveTowards(transform.position, point, speed * Time.deltaTime); // move o objeto ate o ponto
        // }
        // else
        // {
        //     StopPlayer();
        // }
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

    // void OnColliderEnter(Collision col)
    // {
    //     if (col.gameObject.layer != 6) // vai impedir de querer entrar nos objetos
    //     {
    //         stop = true;
    //     }
    //     else
    //     {
    //         stop = false;
    //     }
    // }

    // void StopPlayer()
    // {
    //     speed = 0;
    //     point = transform.position;
    // }
}
