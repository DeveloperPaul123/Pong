using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 30;

    private Rigidbody2D rigidBody;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * speed;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check what we collided with
        //left or right paddle
        if(collision.gameObject.name == "LeftPaddle" || 
            collision.gameObject.name == "RightPaddle")
        {
            HandlePaddleHit(collision);
        }
        // wall bottom or wall top
        if (collision.gameObject.name == "WallBottom" ||
           collision.gameObject.name == "WallTop")
        {
            SoundManager.instance.PlayOneShot(
           SoundManager.instance.wallBloop);
        }
        // left goal or right goal
        if (collision.gameObject.name == "LeftGoal" ||
           collision.gameObject.name == "RightGoal")
        {
            SoundManager.instance.PlayOneShot(
           SoundManager.instance.goalBloop);

            //TODO: Handle scoring

            transform.position = new Vector2(0.0f, 0.0f);
        }
    }

    private void HandlePaddleHit(Collision2D collision)
    {
        float y = BallHitPaddleWhere(transform.position,
            collision.transform.position,
            collision.collider.bounds.size.y);

        Vector2 dir = new Vector2();
        if(collision.gameObject.name == "LeftPaddle")
        {
            dir.x = 1.0f;
            dir.y = y;
        }
        else if(collision.gameObject.name == "RightPaddle")
        {
            dir.x = -1.0f;
            dir.y = y;
        }
        dir = dir.normalized;

        rigidBody.velocity = dir * speed;

        SoundManager.instance.PlayOneShot(
            SoundManager.instance.hitPaddle);
    }

    private float BallHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }
}
