using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public GameObject GraphicsPlayer;
    [HideInInspector] public float h;

    private void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            GraphicsPlayer.transform.rotation = Quaternion.Euler(GraphicsPlayer.transform.rotation.x, 0, GraphicsPlayer.transform.rotation.z);
        if (Input.GetKey(KeyCode.D))
            GraphicsPlayer.transform.rotation = Quaternion.Euler(GraphicsPlayer.transform.rotation.x, -180, GraphicsPlayer.transform.rotation.z);

        if (transform.position.x > 6)
        {
            transform.position = new Vector3(6, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -6)
        {
            transform.position = new Vector3(-6, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Wall")
        {
            GetComponent<Animator>().SetBool("IsGround", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "Wall")
        {
            GetComponent<Animator>().SetBool("IsGround", false);
        }
    }
}
