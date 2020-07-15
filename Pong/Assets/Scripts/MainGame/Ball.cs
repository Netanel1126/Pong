using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Rigidbody2D rb;

    void Start()
    {
        Launch();
    }

    private void Launch()
    {
        int x = Random.Range(0, 2) == 0 ? -1 : 1;
        int y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, y * speed);
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector3.zero;
        Launch();
    }
}
