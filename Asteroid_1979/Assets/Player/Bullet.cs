using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed = 4;

    void Start()
    {
        transform.position = GameObject.Find("Muzzle").transform.position;
        transform.up = GameObject.Find("Muzzle").transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position + transform.up * speed * Time.deltaTime;
        transform.position = newPos;
    }
}

