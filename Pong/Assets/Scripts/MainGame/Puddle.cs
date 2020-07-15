using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    [SerializeField]
    private bool isPlayer1;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Rigidbody2D rb;

    private float movment;
    private Vector3 startPosition;
    private bool isMultiplayer;

    private void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        Debug.Log("" + isMultiplayer);
         
        if (isMultiplayer || isPlayer1)
        {
            PlayerMovment();
        }else if (!isPlayer1)
        {
            EnemyMovment();
        }
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }

    private void PlayerMovment()
    {
        movment = Input.GetAxisRaw(isPlayer1 ? "PongPlayer1" : "PongPlayer2");
        rb.velocity = new Vector2(rb.velocity.x, movment * speed);
    }

    private void EnemyMovment()
    {
        Vector3 move = Vector3.zero;
        Transform ball = GameObject.Find("Ball").GetComponent<Transform>();

        float d = ball.position.y - transform.position.y;
        if (d > 0)
        {
            move.y = speed * Mathf.Min(d, 1.0f);
        }
        if (d < 0)
        {
            move.y = -(speed * Mathf.Min(-d, 1.0f));
        }
        transform.position += move * Time.deltaTime;
    }

    public bool IsMulitplayer
    {
        get { return IsMulitplayer; }
        set { isMultiplayer = value; }
    }
}
