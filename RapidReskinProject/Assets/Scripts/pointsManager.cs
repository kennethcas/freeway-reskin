using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pointsManager : MonoBehaviour
{
    [Header("Points UI")]
    [SerializeField] private TextMeshProUGUI pointsText;

    [Header("Players")]
    public GameObject player;

    [Header("Points Collider")] //if the player collides with this, +1 point
    public BoxCollider2D col;
    public int pts;

    //vector variable 
    private Vector3 bottomOfScreen;

    void Start() 
    {
        //vector variable bottomOfScreen assigned a position (bottom of screen)
        bottomOfScreen = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.05f));
    }

    private void Awake()
    {
        pts = 0;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(pts); 
        pts++;
        pointsText.text = pts.ToString();

        //when colliding with the point area, give player a new y pos using coordinates of bottomOfScreen
        Vector3 position = col.transform.position;
        position.y = bottomOfScreen.y;
        col.transform.position = position;
    }

    
}
