
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float health = 100;

    public int worth = 50;

    public GameObject DeathEffect;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount){
        health -= amount;

        if (health <=0 )
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }    

    void Die()
    {
        GameObject Effect = Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(Effect,5f);
        PlayerStates.Money += worth;
        Destroy(gameObject);
    }

    

}
