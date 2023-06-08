
using UnityEngine;

public class Bullet : MonoBehaviour

{
    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
    public float explosion = 0f;
    public int damage = 50;
    public void Seek(Transform _target)
    {
        target = _target;

    }
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceFrame = speed * Time.deltaTime;
        if(dir.magnitude <= distanceFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);

        if (explosion > 0f) {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);


    }
    void Explode() {
       Collider[] colliders= Physics.OverlapSphere(transform.position, explosion);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy"){
                Damage(collider.transform);
            }
        }
    } 
    void Damage(Transform enemy) {
        Enemy e = enemy.GetComponent<Enemy>();
        if(e!=null)
        {
            e.TakeDamage(damage);
        }
            
            }
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosion);
    }
}
