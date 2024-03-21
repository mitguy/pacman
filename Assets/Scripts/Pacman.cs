using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pacman : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int count;
    private int CountLength;
    public Text Count, Win, Remained;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        Win.text = "";

        CountLength = GameObject.FindGameObjectsWithTag("Cubes").Length;
        setCount();
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cubes")
        {
            Destroy(other.gameObject);
            count++;
            setCount();
        }
    }

    private void setCount()
    {
        int remained = CountLength - count;
        Count.text = "Count: " + count.ToString();
        Remained.text = "Remained: " + remained.ToString();
        if (count >= CountLength) Win.text = "WON";
    }
}
