using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : AIBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float timeBetweenShots;
    public float startTimeBetweenShots;
    public float followDistance;
    public GameObject projectile;
    public GameObject reload;
    private Transform player;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBetweenShots = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90;
            rb2d.rotation = angle;

            float distance = Vector2.Distance(transform.position, player.position);
            if (distance < followDistance)
            {
                if (distance > stoppingDistance) 
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }

                else if (distance < stoppingDistance && distance > retreatDistance)
                {
                    transform.position = this.transform.position;
                }

                else if (distance < retreatDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, (-speed * Time.deltaTime));
                }
            }

            if (timeBetweenShots <= 0)
            {
                if(distance < followDistance)
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
        Gizmos.DrawWireSphere(transform.position, followDistance);
    }

    public override void PerformAction(TankController tank, AiDetector detector)
    {
        throw new System.NotImplementedException();
    }
}
