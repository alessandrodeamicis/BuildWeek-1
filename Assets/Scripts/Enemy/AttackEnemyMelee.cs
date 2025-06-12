using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyMelee : MonoBehaviour
{
    public float attackRange = 1.5f;
    public int damage = 1;
    public float attackCooldown = 1f;

    private Transform player;
    private float lastAttackTime;
    private Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange && Time.time > lastAttackTime + attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
        LifeController playerHp = player.GetComponent<LifeController>();
        if ( playerHp != null)
        {
            playerHp.AddHp(-damage);
        }
    }
}
