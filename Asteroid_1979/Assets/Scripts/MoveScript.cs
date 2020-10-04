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

    public GameObject Player;
    public PlayerScript playerScript;


    public int EnemyLives = 5;

    private void Start()
    {
        EnemyLives = 5;
        Player = GameObject.Find("Player_1");

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
        playerScript = Player.GetComponent<PlayerScript>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Bullet(Clone)")
        {
            EnemyLives--;
            ScoreSystem.scoreValue += 20;

            CheckLives();
            Destroy(collision.gameObject);
        }

        if (collision.name == "Player_1")
        {
            playerScript.Hit();
            Destroy(gameObject);
        }
    }
    private void CheckLives()
    {
        if (EnemyLives == 0)
        {
            ScoreSystem.scoreValue += 50;
            Destroy(gameObject);
        }
    }

}
