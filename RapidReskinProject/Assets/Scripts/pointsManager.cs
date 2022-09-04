using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointsManager : MonoBehaviour
{
    public BoxCollider2D col;
    public int pts;

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        pts = 0;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        pts++;
    }

    private void Update()
    {
        Debug.Log(pts);
    }
}
