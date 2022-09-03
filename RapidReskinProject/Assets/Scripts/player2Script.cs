using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Script : MonoBehaviour
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
        //if player 2 presses up arrow key
        if (Input.GetKey(KeyCode.UpArrow)) {
            //then player 2 will move up
            Move(Vector3.up);
        }
        //else if player 2 presses down arrow key
        else if (Input.GetKey(KeyCode.DownArrow)) {
            //then player 2 will move down
            Move(Vector3.down);
        }
    }

    //move function
    void Move(Vector3 direction) {
        transform.position += direction * speed;
    }
}