using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject muzzle;

    public AudioClip shootSound;

    public Vector2 speed = new Vector2(5,1);
    private Vector3 movement;
    private Vector2 rotation;

    public Rigidbody2D rb;
    float inputX;
    float inputY;
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

}
