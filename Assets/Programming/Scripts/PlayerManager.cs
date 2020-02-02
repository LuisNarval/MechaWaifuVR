using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool isGrounded = true;
    private bool lookingRight = true;
    private Rigidbody2D rb2D;
    private Animator animator;


    public float jumpForce = 500;
    public float aceleration = 10;
    public float maxSpeed = 10;

    public float maxOxygen = 10;
    public float maxEnergy = 10;
    public float oxygenLevel = 0;
    public float energyLevel = 0;

    public string horizontalString;
    public string jumpString;
    public string interactString;

    public Transform energyTank;
    public Transform oxygenTank;



    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        oxygenLevel = 0;
        energyLevel = 0;
    }


    void Update()
    {

        oxygenTank.localScale = new Vector3(1,oxygenLevel / maxOxygen,1);
        energyTank.localScale = new Vector3(1, energyLevel / maxEnergy, 1);

        if (rb2D.velocity.x < maxSpeed && rb2D.velocity.x > (maxSpeed*(-1)))
            rb2D.AddForce(aceleration*transform.right * Input.GetAxis(horizontalString));


        if (Input.GetButtonDown(jumpString) &&isGrounded)
        {
            Jump();
        }

        if ((rb2D.velocity.x<-0.1 && lookingRight)||(rb2D.velocity.x > 0.1 && !lookingRight))
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            lookingRight = !lookingRight;
        }

        if(lookingRight)
            animator.SetFloat("Velocity", rb2D.velocity.x);
        else
            animator.SetFloat("Velocity", rb2D.velocity.x * -1);

    }

    public void Jump() 
    {
        isGrounded = false;
        animator.SetBool("Grounded",false);
        animator.SetTrigger("Jump");
        rb2D.AddForce(transform.up * jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
            animator.SetBool("Grounded", true);
        }
    }
    

}
