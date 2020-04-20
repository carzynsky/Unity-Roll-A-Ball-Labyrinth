using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text timerText;

    private Rigidbody rb;
    private int count;
    private float countTime;

    void Start()
    {
        count = 0;
        countTime = 0;
        SetCountText();
        winText.text = "";
        countText.text = $"Points: {count}";
        timerText.text = "";
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speed);
    }
    void Update()
    {
        if (count < 3)
        {
            countTime += Time.deltaTime;
            timerText.text = $"Time: {countTime} seconds";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
            if(count == 3)
            {
                winText.text = $"Level completed!";
            }
        }
    }
    void SetCountText()
    {
        countText.text = $"Count: {count}";
    }
}
