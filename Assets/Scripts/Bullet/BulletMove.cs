using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;            //Muove il proiettile platform
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")                                      //Se collide con il muro
        {
            this.enabled = false;                                                   //Disattiva lo script
        }
    }
}
