using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1Script : MonoBehaviour
{
//speed
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    //move function
    void Move(Vector3 direction) {
        transform.position += direction * speed;
    }
}
