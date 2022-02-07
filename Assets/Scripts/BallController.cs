using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float speed;
    public float randomUp;

    Rigidbody2D ballRigidbody;
    GameController cont;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        cont = FindObjectOfType<GameController>();
    }

    private void OnEnable()
    {
        Invoke("PushBall", 1f);
    }

    void PushBall()
    {
        int dir = Random.Range(0, 2);   //random 0, 1
        float x, y;

        if(dir == 0) //ball will move right
        {
            x = speed;
        }else //ball will move left
        {
            x = -speed;
        }

        y = Random.Range(-randomUp, randomUp);
        ballRigidbody.AddForce(new Vector2(x, y));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = ballRigidbody.velocity.x;
            vel.y = ballRigidbody.velocity.y / 2 + collision.collider.attachedRigidbody.velocity.y / 2;
            ballRigidbody.velocity = vel;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {

            if (ballRigidbody.velocity.x > 0) // collider right wall
            {
                cont.Score(true);
            }
            else if(ballRigidbody.velocity.x < 0) //left wall
            {
                cont.Score(false);
            }
            else
            {

            }

            ballRigidbody.velocity = Vector2.zero; // new Vector2(0,0)
            transform.position = Vector3.zero;

            Invoke("PushBall", 2f);
        }
    }
}
