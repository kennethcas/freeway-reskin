using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1Script : MonoBehaviour
{
//speed
    public float speed;

    
    public float knockbackTime;
    public bool player1Hit;

    // Start is called before the first frame update
    void Start()
    {
        knockbackTime = 10f;
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

        
        if (player1Hit == true) {
            knockbackTime -= Time.deltaTime; 
        }
        else if (player1Hit == false) {
            knockbackTime = 10f;             
        }


        if (knockbackTime <= 0) {
            Rigidbody2D player1 = GetComponent<Rigidbody2D>();
            player1.velocity = Vector2.zero;
            player1Hit = false;
            player1.isKinematic = true;
        }
    }

    //move function
    void Move(Vector3 direction) {
        transform.position += direction * speed;
    }

    //if the enemy collides with player 1
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "enemy") {
            Debug.Log("player 1 hit");

            Rigidbody2D player1 = collision.GetComponent<Rigidbody2D>();
            //make kinematic stay off to make dynamic (apply force)
            player1.isKinematic = false;
            //vector2 "difference" is the player 1's pos subtracted by enemy pos
            //Vector2 difference = player1.transform.position.y - transform.position.y;
            //difference multiplied by knockback distance
            //difference = difference.normalized * 1.5f;
            //player1.AddForce(difference, ForceMode2D.Impulse);
            player1.AddForce(-transform.up, ForceMode2D.Impulse);

            player1.velocity = Vector2.zero;
            player1.isKinematic = true;
            //StartCoroutine(knockbackCoroutine(player1));
        }
    }
}
