using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour {

    // making it public you can edit it in unity.
    public float speed = 30;

    private void FixedUpdate()
    {
        //Get input for vertical input
        float vertPress = Input.GetAxisRaw("Vertical");

        // set the velocity
        GetComponent<Rigidbody2D>().velocity =
            new Vector2(0.0f, vertPress) * speed;        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
