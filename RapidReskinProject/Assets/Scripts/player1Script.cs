using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1Script : MonoBehaviour
{
    //speed variable
    public float speed;

    //rigidbody variable called player1Body
    Rigidbody2D player1Body;

    public float knockbackTime;
    public bool player1Hit;

    // Start is called before the first frame update
    void Start()
    {
        //setting player 1's rigidbody into the variable
        player1Body = gameObject.GetComponent<Rigidbody2D>();
        knockbackTime = 0.5f;
        player1Hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if player 1 presses W
        if (Input.GetKey(KeyCode.W)) {
            //then player 1 will move up
            Move(Vector3.up);
        }
        //else if player 1 presses S
        else if (Input.GetKey(KeyCode.S)) {
            //then player 1 will move down
            Move(Vector3.down);
        }

        //if player is hit, then the timer will countdown
        if (player1Hit == true) {
            knockbackTime -= Time.deltaTime; 
        }
        //if the countdown finishes, player is not hit. reset the timer
        else if (player1Hit == false) {
            knockbackTime = 0.5f;             
        }

        //if the countdown hits zero
        if (knockbackTime <= 0) {
            //stop player from moving
            player1Body.velocity = Vector2.zero;
            //set bool to false; player is no longer hit. bool triggers timer reset
            player1Hit = false;
            //set back to kinematic; player is no longer affected by gravity
            player1Body.isKinematic = true;
        }
    }

    //move function
    void Move(Vector3 direction) {
        transform.position += direction * speed;
    }

    //if the player collides with an enemy
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "enemy") {
            Debug.Log("player 1 hit");
            //set kinematic to dynamic so force is applied (gravity on)
            player1Body.isKinematic = false;
            //force applied downwards to the player to create knock back effect
            player1Body.AddForce(-transform.up, ForceMode2D.Impulse);
            //set bool to true; player has been hit
            player1Hit = true;
        }
    }
}
