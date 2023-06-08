using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
 



   [SerializeField]
    private Transform target;
    private Enemy targetEnemy;
    [Header("Attributes")]
    public float fireRate = 1f;
    private float fireCountDown = 0f;
    public float range = 15f;

    public AudioSource src;
    public AudioClip sfx1;


    [Header("Unity setup")]
    public string enemyTag = "Enemy";

    public Transform RotatePart;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    [Header("Laser")]
    public int laserDamage = 50;
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem laserEffect;
    public float slow = .5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance) {

                shortestDistance = distanceToEnemy;

                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range) {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();

        }
        else
        {
            target = null;
        }
        // Update is called once per frame

    }
    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    laserEffect.Stop();
                }
                    
            }
            return;

        }

        LockTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountDown <= 0f)
            {
                Shoot();
                fireCountDown = 1f / fireRate;
            }
            fireCountDown -= Time.deltaTime;
        }
    }
    void LockTarget ()
    {
        //lock target
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(RotatePart.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        RotatePart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    void Laser() {

        targetEnemy.TakeDamage(laserDamage * Time.deltaTime);
        targetEnemy.Slow(slow);

        if (!lineRenderer.enabled) { 

        lineRenderer.enabled = true;
            laserEffect.Play();
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
        laserEffect.transform.position = target.position;

    }
    void Shoot()
    {

       
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target);


    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
