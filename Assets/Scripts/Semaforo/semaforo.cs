using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semaforo : MonoBehaviour
{

    public float timer = 2f;
    public bool status = false; // false = vermelho

    void Start()
    {
        
    }

    void Update()
    {
        this.timer -= Time.deltaTime;

        if (this.timer <= 0)
        {
            if (this.status != !this.status)
            {
                this.status = !this.status;
            }
            this.timer = 2f;
        }

        if (this.status == false)
        {
            this.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            this.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.green;
        }
    }
}
