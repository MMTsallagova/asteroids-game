using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject muzzle;

    public AudioClip shootSound;
   
    public int numberOfLives;
    public Image[] lives;

    public Vector2 speed = new Vector2(5,1);
    private Vector3 movement;
    private Vector2 rotation;

    public Rigidbody2D rb;
    float inputX;
    float inputY;

    public Text text;
    public int score;

    public void Start()
    {
        numberOfLives = 4;
        UpdateUI();
    }
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        movement = new Vector3(0, inputY * speed.y, 0);

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 newPos = transform.position + transform.up * speed.y;
            transform.position = newPos;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 newPos = transform.position - transform.up * speed.y;
            transform.position = newPos;
        }

        float angle = inputX * speed.x;
        transform.Rotate(0, 0, -angle);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, muzzle.transform.position, Quaternion.identity);
            GetComponent<AudioSource>().PlayOneShot(shootSound);
        }
    }

    public void UpdateUI()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            if (i < numberOfLives)
                lives[i].enabled = true;
            else
                lives[i].enabled = false;
        }
    }
    public void Hit()
    {
        numberOfLives = numberOfLives-1;
        Debug.Log(numberOfLives);
        UpdateUI();

        if (numberOfLives == 0)
        {
            Destroy(gameObject);
        }
    }

}
