using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 
   
    public GameObject deathEffect;
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float health = 100;
    public int moneyGet = 40;

    private Transform target;
    private int wavepointIndex = 0;
    private Enemy enemy;

    private bool Dead = false;

    void Start() {
        speed = startSpeed;
        enemy = GetComponent<Enemy>();
        if (WayPoints.points != null && WayPoints.points.Length > 0)
        {
            target = WayPoints.points[0];
        }
        else
        {
            Debug.LogError("WayPoints.points is null or empty.");
        }
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
        enemy.speed = enemy.startSpeed;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0 && !Dead)
        {
            Die();
        }
    }
    public void Slow (float slowRate)
    {
        speed = startSpeed * (1f-slowRate);

    }


    void GetNextWaypoint()
    {
        if (wavepointIndex >= WayPoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = WayPoints.points[wavepointIndex];
    }
    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawnner.EnemiesAlive--;
        Destroy(gameObject);
    }

    void Die()
    {
        Dead = true;
       GameObject effect =(GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
       
        WaveSpawnner.EnemiesAlive--;
        PlayerStats.Money += moneyGet;

        Destroy(gameObject);


    }
   
}
