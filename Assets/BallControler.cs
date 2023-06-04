using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControler : MonoBehaviour
{
    public float speed = 6f;
    public Rigidbody2D rb2D;
    public Vector3 vel;
    public bool isPlaying;

    // Start is called before the first frame update
    void Start()

    {   rb2D = GetComponent<Rigidbody2D>();
        ResetandSendBallRandomDirection();
        ResetBall();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isPlaying == false)
        {
            ResetandSendBallRandomDirection();
        }
    }

    private void ResetandSendBallRandomDirection()
    {
        ResetBall();
        rb2D.velocity = GenerateRandomVelocity(true) * speed;
        vel = rb2D.velocity;
        isPlaying = true;
    }
    private void ResetBall()
    {
       
        rb2D.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        isPlaying = false;
    }

    private Vector3 GenerateRandomVelocity(bool shouldReturnNarmaLized)
    {
       Vector3 velocity = new Vector3();
        bool shouldGoRight = Random.Range(1, 100) > 50;
        velocity.x = shouldGoRight ? Random.Range(-0.8f, 0.3f) : Random.Range(-0.8f, -0.3f);
        velocity.y = Random.Range(-0.2f, 0.8f);

        return shouldReturnNarmaLized ? velocity.normalized : velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 newvelocity = vel;
        newvelocity += new Vector3(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f));
        rb2D.velocity = Vector3.Reflect(newvelocity.normalized * speed, collision.contacts[0].normal);
      
        vel = rb2D.velocity;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0);
        print("LeftPlayer +1");

        if (transform.position.x < 0);
        print("RightPlayer +1");

        ResetandSendBallRandomDirection();
        ResetBall();

    }


}
