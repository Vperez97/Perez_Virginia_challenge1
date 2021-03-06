﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;


    private Rigidbody rb;
    private int count;
    private int score;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetAllText();
        winText.text = "";
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1; // I added this code to track the score and count separately.
            SetAllText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score - 1; // this removes 1 from the score
            SetAllText();
        }
        if (score== 12) {
    transform.position = new Vector3(76.0f, transform.position.y,0.80f); 
}
    }

    private void SetAllText()
    {
        countText.text = " Count: " + count.ToString();
        scoreText.text = "Score: " + score.ToString();
        if (score >= 12)
        {
            winText.text = "You Win!";
        }
    }
}