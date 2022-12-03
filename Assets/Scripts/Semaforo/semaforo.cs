using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semaforo : MonoBehaviour
{

    private float timer = 3f;
    public bool status = false, x = false; // false = vermelho
    private Animator anim;

    void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
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
            this.timer = 3f;
        }

        if (this.status == false)
        {
            this.anim.SetBool("cor", true); // green 
        }
        else
        {
            this.anim.SetBool("cor", false); // red
        }

        if (this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.activeSelf == true)
        {
            x = true;
        }
        else
        {
            x = false;
        }
    }
}
