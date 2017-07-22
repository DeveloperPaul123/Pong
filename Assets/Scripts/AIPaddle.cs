using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIPaddle : MonoBehaviour {

    public Ball ball;

    public float speed = 30f;

    public float lerpTweak = 2f;

    private Rigidbody2D rigidBody;


	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();	
	}

    private void FixedUpdate()
    {
        if(ball.transform.position.y > transform.position.y)
        {
            Vector2 dir = new Vector2(0, 1).normalized;

            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity,
                dir * speed,
                lerpTweak * Time.deltaTime);
        }
        else if (ball.transform.position.y < transform.position.y)
        {
            Vector2 dir = new Vector2(0, -1).normalized;

            rigidBody.velocity = Vector2.Lerp(rigidBody.velocity,
                dir * speed,
                lerpTweak * Time.deltaTime);
        }

    }
}
