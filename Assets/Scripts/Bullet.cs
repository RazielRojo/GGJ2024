
using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target { get; set; }

    public float speed = 40f;

    public int damage = 50;

    public float explosionRaduis = 0;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            //to prevent async code problems
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        //rotate transmition to the right dimention
        transform.LookAt(target);

    }

    private void HitTarget()
    {
        GameObject effectsIns = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectsIns, 5f);

        if (explosionRaduis > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRaduis);
        foreach(Collider collider in colliders)
        {

            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRaduis);
    }

}
