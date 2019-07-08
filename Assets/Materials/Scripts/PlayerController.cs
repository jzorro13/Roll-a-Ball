using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;
    public Text loseText;

    private Rigidbody rb;
    private int count;
    private int score;
    
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 3;
        SetAllText ();
        winText.text = "";
        loseText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
    
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 0;
            SetAllText();
        }    
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1; 
            score = score - 1;
            SetAllText();
        }
        if (count == 13)
        {
            transform.position = new Vector3(-43.9f, transform.position.y,3.0f); 
        }
        if (score == 0)
        {
            Destroy(gameObject);
        }
    }      

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    
    void SetAllText()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 26)
        {
            winText.text ="Victory!";
        }
        scoreText.text = "Lives: " + score.ToString ();
        if (score == 0)
        {
            loseText.text ="Game Over!";
        }
    }
}