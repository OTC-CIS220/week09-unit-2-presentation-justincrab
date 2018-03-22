using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public int score =0;
    public float speed;
    public Text scoreText;
    public Text winText;
    private Rigidbody rb; //variable that holds reference to 'Rigidbody' compononent in unity
    public GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pick Up");
    private void Start()
    {
        winText.text = "";
        // first frame, link rb to rigidbody component in unity
        rb = GetComponent<Rigidbody>();
        SetScoreText();
    }
    private void FixedUpdate()
    {
        //every frame, input is read in, put into vector3, which is passed to add force
        // gets movement input from user/keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        //we collide with 'other', if 'other's tag matches, deactivate it.
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            score += 1;
            SetScoreText();
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 31 )
        {
            winText.text = "You win!";
            //foreach (var obj in pickups)
            //    obj.SetActive(true);            
            score = 0;
            speed = speed * 2;
            SetScoreText();
            winText.text = "";
        }
    }
}
