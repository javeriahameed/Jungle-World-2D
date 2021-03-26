using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerMovement : MonoBehaviour
{  
    public int speed = 7;
    public Animator animator;
    private Rigidbody2D  rigidbody2D;
    //public Text heathText;
    //public int totalHealth = 100;
    public Text coinText;
    private int collected_coins;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("SpeedParam", move * speed);
        rigidbody2D.velocity = new Vector3(move * speed, rigidbody2D.velocity.y, 0);

        if(Input.GetKey(KeyCode.Space))
        {
            rigidbody2D.velocity = new Vector3(rigidbody2D.velocity.x,speed,0);

        }

       

    }

    //Just hit another collider 2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit another collider");
    }

    //Hitting a collider 2D
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("Health");
    }

    //Just stop hitting a collider 2D
    private void OnCollisionExit2D(Collision2D collision)
    {
       // Debug.Log("normal Health");
    }

    //Just overlapped a collider 2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            Debug.Log("coin addedd");
            collected_coins += 1;
            coinText.text = "Coins: " + collected_coins.ToString();
            GameObject.Destroy(collision.gameObject);
        }

       // if (collision.gameObject.tag == "rocket")
        //{
         //   Debug.Log("coin addedd");
           // heathText.text = 
            //totalHealth -= 1;
            //heathText.text = "Health: " + totalHealth.ToString();
            //GameObject.Destroy(collision.gameObject);
       // }
    }

    //Overlapping a collider 2D
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Loss Health fast");
    }

    //Just stop overlapping a collider 2D
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("normal player Health");
    }
}
