using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public bool RightSpawn;
    public bool LeftSpawn;
    public bool UpSpawn;
    public bool DownSpawn;

    public float LiveTime = 10.0f;
    public float Timer = 0.0f;

    public Vector2 speed = new Vector2(2, 2);
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;

    private Rigidbody2D rb;

    private void Start()
    {
        if (RightSpawn)
        {
            direction = new Vector2(-1.0f, Random.Range(-1.0f, 1.0f));
        }
        if (LeftSpawn)
        {
            direction = new Vector2(1.0f, Random.Range(-1.0f, 1.0f));
        }
        if (UpSpawn)
        {
            direction = new Vector2(Random.Range(-1.0f, 1.0f),-1.0f);
        }
        if (DownSpawn)
        {
            direction = new Vector2(Random.Range(-1.0f, 1.0f), 1.0f);
        }

    }

    void Update()
    {
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = movement;

        Timer += Time.deltaTime;
        if (LiveTime < Timer)
        {
            Destroy(gameObject);
        }

    }

}
