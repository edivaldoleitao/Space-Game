using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float moveDuration = 2f;
    public float initialMoveSpeed = 5f;
    public float moveSpeedIncreaseRate = 0.1f; // Taxa de aumento da velocidade de movimento
    [SerializeField] private Rigidbody2D rb;
    private bool movingRight = true;
    public float currentMoveSpeed;

    private float timeElapsed = 0f;

    void Start()
    {
        InvokeRepeating("ChangeDirection", 0f, moveDuration);
        Destroy(gameObject, 20);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        // Aumenta a velocidade de movimento com base no tempo decorrido
       currentMoveSpeed = initialMoveSpeed + moveSpeedIncreaseRate * timeElapsed;

        if (movingRight)
        {
            rb.velocity = new Vector2(currentMoveSpeed, rb.velocity.y); // Move para a direita
        }
        else
        {
            rb.velocity = new Vector2(-currentMoveSpeed, rb.velocity.y); // Move para a esquerda
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && spaceship.shield == false)
        {
            Destroy(collision.gameObject);
        }
    }

    void ChangeDirection()
    {
        movingRight = !movingRight; // Inverte a direção
        // Inverte a escala do inimigo para refletir a mudança na direção
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
