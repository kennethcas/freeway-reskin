using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pointsManager : MonoBehaviour
{
    [Header("Points UI")]
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Players")]
    public GameObject player1;
    public GameObject player2;

    [Header("Points")]

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
