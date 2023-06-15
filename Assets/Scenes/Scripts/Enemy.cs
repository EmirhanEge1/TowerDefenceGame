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
    private int pathIndex;

    private bool Dead = false;

    private Transform[] path;
    private int waypointIndex = 0;

    void Start()
    {
        speed = startSpeed;
        enemy = GetComponent<Enemy>();

        if (WayPoints.paths != null && WayPoints.paths.Length > 0)
        {
            pathIndex = Random.Range(0, WayPoints.paths.Length);
            target = WayPoints.paths[pathIndex][0];
        }
       
    }

    void Update()
    {
        if (target == null || enemy == null)
        {
            return;
        }

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

    public void Slow(float slowRate)
    {
        speed = startSpeed * (1f - slowRate);
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= WayPoints.paths[pathIndex].Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        if (WayPoints.paths.Length > pathIndex && WayPoints.paths[pathIndex].Length > wavepointIndex)
        {
            target = WayPoints.paths[pathIndex][wavepointIndex];
        }
       
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
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);

        WaveSpawnner.EnemiesAlive--;
        PlayerStats.Money += moneyGet;

        Destroy(gameObject);
    }
}
