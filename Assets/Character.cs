using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float health = 100;
    public float damage = 10;
    public Team team;
    public float moveSpeed = 10;
    public float attackedSpeed = 0.5f;
    public float attackedSpeedAura = 0.5f;

    public float attackDelay;
    public float attackDelayAura;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            if (player.team != team)
            {
                player.TakeDamage(damage);
                Destroy(gameObject);
                //TakeDamage(character.damage);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.transform.TryGetComponent(out Character character))
        {
            if (character.team != team)
            {
                attackDelay += Time.deltaTime;
                if (attackDelay > attackedSpeed)
                {
                    character.TakeDamage(damage);
                    //TakeDamage(character.damage);

                    attackDelay = 0;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.TryGetComponent(out Character character))
        {
            if (character.team != team)
            {
                attackDelayAura += Time.deltaTime;
                if (attackDelayAura > attackedSpeedAura)
                {
                    character.TakeDamage(damage);
                    //TakeDamage(character.damage);

                    attackDelayAura = 0;
                }
            }
        }
    }
   

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        rb.AddForce(transform.forward * moveSpeed);
    }
}



public enum Team
{
    Blue,
    Red,
    Green
}

[System.Serializable]
public class CharacterData
{
    public float health = 100;
    public float damage = 10;
    //public Team team;
}
