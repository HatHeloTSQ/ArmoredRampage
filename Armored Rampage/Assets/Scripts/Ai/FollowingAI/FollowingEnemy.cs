using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public GameObject projectile;
    public GameObject reload;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBetweenShots = startTimeBetweenShots;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }

            else if ((Vector2.Distance(transform.position, player.position) < stoppingDistance) && (Vector2.Distance(transform.position, player.position) > retreatDistance))
            {
                transform.position = this.transform.position;
            }

            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, (-speed * Time.deltaTime));
            }

            if (timeBetweenShots <= 0)
            {
                if (projectile == null)
                {
                    projectile = reload;
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    timeBetweenShots = startTimeBetweenShots;
                }
                else
                {
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    timeBetweenShots = startTimeBetweenShots;
                }
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
        Gizmos.DrawWireSphere(transform.position, retreatDistance);
    }
}
