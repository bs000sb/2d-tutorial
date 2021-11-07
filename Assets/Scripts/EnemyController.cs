using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;

   


    public bool broken = true;
    public ParticleSystem smokeEffect;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    

    Animator animator;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
        
        
    }

    void Update()
    {
        if(!broken)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        if(!broken)
        {
            return;
        }

        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
            animator.SetFloat("X", 0);
            animator.SetFloat("Y", direction);
        }
        else 
        { 
            position.x = position.x + Time.deltaTime * speed * direction;
            animator.SetFloat("X", direction);
            animator.SetFloat("Y", 0);
        }

        rigidbody2D.MovePosition(position);
    }

    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;
        animator.SetFloat("X", 0);
        animator.SetFloat("Y", 0);

        smokeEffect.Stop();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
            
        }
    }
}
