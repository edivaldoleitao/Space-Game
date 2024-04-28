using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class bullet : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] public float speed = 10f;

    [Range(1, 10)]
    [SerializeField] public float lifetime = 3f;

    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        rb.MoveRotation(rb.rotation + 180f);
        Destroy(gameObject, lifetime);
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0f, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Score.scoreValue += 1;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            
        }
    }
}
