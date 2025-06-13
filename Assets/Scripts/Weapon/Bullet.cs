using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 1;

    public int lifetime = 5;
    public AudioClip hitSound;
    //public AudioSource audioSource;

    public int Damage => damage;
    public float Speed
    {
        get => speed;
        set => speed = value;   
    }
    public Vector2 dir
    {
        get;
        set;
    }

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //audioSource = GetComponent<AudioSource>();
        //audioSource.Play();
        Destroy(gameObject, lifetime); // <- si distrugge dopo (lifetime) secondi
    }

    private void FixedUpdate()
    {
        _rb.velocity = dir * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Enemy enemy = collision.collider.GetComponent<Enemy>();
            AudioController.Play(hitSound, transform.position, 1);
            Destroy(gameObject);
        }
    }
}