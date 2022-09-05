using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointsManager : MonoBehaviour
{
    [Header("Points UI")]
    public BoxCollider2D col;
    public int pts;

    private Vector3 bottomOfScreen;

    void Start() 
    {
        bottomOfScreen = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.05f));
    }

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        pts = 0;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        pts++;
        Vector3 position = transform.position;
        position.y = bottomOfScreen.y;
        transform.position = position;
    }

    private void Update()
    {
        Debug.Log(pts);
    }
}
