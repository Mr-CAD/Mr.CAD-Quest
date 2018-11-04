using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text Maze1;
    public Text Maze2;
    public Text Maze3;
    public Text Maze4;
    public Text Maze5;


    private Rigidbody rb;
    private int count;
    private bool Finish = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();           

        }
        if (count >= 1)
        {
            Maze1.text = "Maze 1, Done!";
        }
        if (count >= 2)
        {
            Maze1.text = "Maze 2, Done!";
        }
        if (count >= 3)
        {
            Maze1.text = "Maze 3, Done";
        }
        if (count >= 4)
        {
            Maze1.text = "Maze 4, Done!";
        }
        if (count >= 5)
        {
            Maze1.text = "Maze 5, Done!";
        }

        if ((count >= 5) && (other.gameObject.CompareTag("finish")))
            
        {
            Finish = true;
        }
        if (Finish == true)
        {
            winText.text = "Maze 1, (Complete) Maze 2, (Complete) Maze 3, (Complete) Maze 4, (Complete) Maze 5, (Complete) Great Job!!!";
        }
    }
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
    }

}