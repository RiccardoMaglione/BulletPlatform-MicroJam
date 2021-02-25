using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Player
    public float Speed;
    public GameObject GraphicsPlayer;
    [HideInInspector] public float h;
    #endregion

    #region Bullet
    public GameObject Bullet;
    public bool CanSpawn = true;
    public float Delay = 1.5f;
    #endregion

    #region Slowmotion
    public bool TimeNormal = true;

    public float TimeScale;
    #endregion

    private void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");                                                                                                            //Prendo il valore dell'asse orizzontale per muovere il player
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))                                                                                                                //Se schiaccio A si gira a sinistra
            GraphicsPlayer.transform.rotation = Quaternion.Euler(GraphicsPlayer.transform.rotation.x, 0, GraphicsPlayer.transform.rotation.z);
        if (Input.GetKey(KeyCode.D))                                                                                                                //Se schiaccio D si gira a destra
            GraphicsPlayer.transform.rotation = Quaternion.Euler(GraphicsPlayer.transform.rotation.x, -180, GraphicsPlayer.transform.rotation.z);

        if (transform.position.x > 6)                                                                                                               //Blocca il movimento se la x del player è superiore a 6
        {
            transform.position = new Vector3(6, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -6)                                                                                                              //Blocca il movimento se la x del player è inferiore a 6
        {
            transform.position = new Vector3(-6, transform.position.y, transform.position.z);
        }

        if (Input.GetMouseButtonDown(0) && CanSpawn == true)                                                                                            //Se schiaccio il pulsante sinistro del muose e può spawnaere, spawno il proiettile
        {
            BulletInstantiate();
        }

        Slowmotion();
        TimeScale = Time.timeScale;
    }

    /// <summary>
    /// Metodo che applica uno slowmotion generale
    /// </summary>
    public void Slowmotion()
    {
        if (Input.GetMouseButtonDown(1) && TimeNormal == true)
        {
            Time.timeScale = 0.5f;
            TimeNormal = false;
            StartCoroutine(CooldownSlowmotion());
        }
    }

    /// <summary>
    /// Ienumarator che svolge la funzione di cooldown dello slowmotion
    /// </summary>
    /// <returns></returns>
    public IEnumerator CooldownSlowmotion()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 1f;
        TimeNormal = true;
    }

    /// <summary>
    /// Metodo che istanzia il proiettile piattaforma
    /// </summary>
    public void BulletInstantiate()
    {
        GameObject TempBullet = Instantiate(Bullet, GetComponent<PlayerController>().GraphicsPlayer.transform.position, GetComponent<PlayerController>().GraphicsPlayer.transform.rotation);
        CanSpawn = false;
        StartCoroutine(CooldownSpawnBullet());
    }

    /// <summary>
    /// Ienumarator che svolge la funzione di cooldown dello spawn del proiettile
    /// </summary>
    /// <returns></returns>
    public IEnumerator CooldownSpawnBullet()
    {
        yield return new WaitForSeconds(Delay);
        CanSpawn = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Wall")                     //Se non collido con il muro
        {
            GetComponent<Animator>().SetBool("IsGround", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "Wall")                     //Se non collido con il muro
        {
            GetComponent<Animator>().SetBool("IsGround", false);
        }
    }
}
