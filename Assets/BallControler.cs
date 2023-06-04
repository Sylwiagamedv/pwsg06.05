using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControler : MonoBehaviour
{
    public float speed = 6f;
    public Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = GenerateRandomVelocity(true) * speed;
    }

     private Vector3 GenerateRandomVelocity(bool shouldReturnNarmaLized)
    {
       Vector3 velocity = new Vector3();
        velocity.x = Random.Range(-1f, 1f);
        velocity.y = Random.Range(-1f, 1f);
        return shouldReturnNarmaLized ? velocity.normalized : velocity;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
