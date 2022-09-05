using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftEnemyMovement : MonoBehaviour
{
    /*Below are the links and sources used to help code this project!
    
    “How to make Frogger in Unity (Complete Tutorial)” by Zigurous
    Section Environment Loop
    https://www.youtube.com/watch?v=GxlxZ5q__Tc&list=PL3J5ZZINwCjTcqqOzdKPbZkA1KfnLsp8w&index=8&t=19s 

    “Enemy Knockback in Unity” by BliskenX
    https://www.youtube.com/watch?v=nHPXiRNaNoM */
    
    //speed variable
    public float speed;

    //direction, default to go to right
    public Vector2 direction = Vector2.right;

    //world bounds
    private Vector3 leftSide;
    private Vector3 rightSide;

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

}
