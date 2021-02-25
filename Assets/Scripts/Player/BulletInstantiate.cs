using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInstantiate : MonoBehaviour
{
    public GameObject Bullet;
    public bool CanSpawn = true;
    public float Delay = 1.5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && CanSpawn == true)
        {
            BInst();
        }
    }

    public void BInst()
    {
        GameObject TempBullet = Instantiate(Bullet, transform.position, transform.rotation);
        CanSpawn = false;
        StartCoroutine(CooldownSpawnBullet());
    }

    public IEnumerator CooldownSpawnBullet()
    {
        yield return new WaitForSeconds(Delay);
        CanSpawn = true;
    }
}
