using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftEnemyMovement : MonoBehaviour
{
    //speed variable
    public float speed;

    //direction, default to go to right
    public Vector2 direction = Vector2.right;

    //world bounds
    private Vector3 leftSide;
    private Vector3 rightSide;

    public float knockbackTime;

    // Start is called before the first frame update
    void Start()
    {
        //get Main Camera viewport coordinates and convert them to world points
        //used to compare later for when enemies go off screen/out of viewport
        leftSide = Camera.main.ViewportToWorldPoint(Vector3.zero);
        rightSide = Camera.main.ViewportToWorldPoint(Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        //if the enemy's x position is farther than the right side of world bound
        //note: position x follows origin of obj, need final sprite to know size of obj to make sure
        //that the whole object goes off screen before looping back to beginning
        if (transform.position.x > rightSide.x) {
            //then give the enemy a new position --> that will move
            Vector3 position = transform.position;
            //current x pos will be the left side now (loop to left)
            //note: same note of caution, might spawn already halfway through
            position.x = leftSide.x;
            //the moved position is now the current position
            transform.position = position;
        }
        //if the enemy is not off screen
        else {
            //then it will move
            transform.Translate(direction * speed * Time.deltaTime);
        }
        
    }

    //if the enemy collides with player 1
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "player1") {
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

            // player1.velocity = Vector2.zero;
            // player1.isKinematic = true;
            //StartCoroutine(knockbackCoroutine(player1));
        }
    }

    // private IEnumerator knockbackCoroutine(Rigidbody2D player1) {
    //     yield return new WaitForSeconds(knockbackTime);
    //     player1.velocity = Vector2.zero;
    //     player1.isKinematic = true;
    // }

}
