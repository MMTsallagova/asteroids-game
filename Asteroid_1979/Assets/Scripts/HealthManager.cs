using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health = 4;
    public int numberOfLives = 4;

    public Image[] lives;

    private void Start()
    {
        numberOfLives = 4;
    }
    private void Update()
    {
       // Debug.Log(numberOfLives);
        for (int i = 0; i < lives.Length; i++)
        {
            if (i < numberOfLives)
                lives[i].enabled = true;
            else
                lives[i].enabled = false;
        }
    }
    public void UpdateUI()
    {
        numberOfLives = numberOfLives-1;
    }
}
