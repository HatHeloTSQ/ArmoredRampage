using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public List<Transform> turretBarels;
    public GameObject bulletPrefab;
    public float reloadDelay = 1;

    bool canShoot = true;
    Collider2D[] tankcolliders;
    public float currentDelay = 0;

    private void Awake()
    {
        tankcolliders = GetComponentsInParent<Collider2D>();
    }

    private void Update()
    {
        if(canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if(currentDelay <= 0)
            {
                canShoot = true;
            }
        }
    }



    public void Shoot()
    {
        Debug.Log("Shooting"); 

       if (canShoot)
       {
            canShoot = false;
            currentDelay = reloadDelay;

            foreach (var barrel in turretBarels)
            {
                GameObject bullet = Instantiate(bulletPrefab);

                bullet.transform.position = barrel.position;
                bullet.transform.localRotation = barrel.rotation;
                bullet.GetComponent<Bullet>().Initialize();

                foreach (var collider in tankcolliders)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                }
            }
       }
    }
   
}
