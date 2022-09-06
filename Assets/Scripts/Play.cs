using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    //GameObject player;
    [SerializeField] int speed = 5;
    Vector3 point;

    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        point = this.transform.position;
    }

    // 1 - mover player ao ponto
    // 2 - se encostou no minigame muda de cena

    void Update()
    {
        //Check for the mouse being pressed (also works as a touch input)
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                point = hit.point;
                print(point);
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, point, speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        
    }

    void PlayGame()
    {
        
    }
}
