using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator playerAnimator;
    public float movementSpeed;
	private Transform tr;
    public static bool turnedRight;
    public static bool onWall = false;
    private bool walking = false;
    public static bool canMove = true;
    public float radiusWall;
    public GameObject findItemObject;
    public GameObject ghost;
    float axis;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
		tr = GetComponent<Transform>();
        turnedRight = true;
        canMove = true;
        playerAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            WalkRun();
            Flip();
            Interactions();
        }
        GhostActions();
        
    }

    public void WalkRun()
    {

        onWall = false;

        if(Input.GetButton("Horizontal"))
        {
            walking = true;
        }
        else
        {
            walking = false;
            // rigidBody.velocity = new Vector2(0f, rigidBody.velocity.y);
        }
       if(walking && !onWall)
       {
        playerAnimator.SetBool("Walk", true);
        if(turnedRight)
        {
            rigidBody.velocity = new Vector2(movementSpeed, rigidBody.velocity.y);  
        }
        else
        {
            rigidBody.velocity = new Vector2(-movementSpeed, rigidBody.velocity.y);
        }
           
       }
       else
       {
           rigidBody.velocity = new Vector2(0f, rigidBody.velocity.y);
           playerAnimator.SetBool("Walk", false);
       }
    }
	public void Flip()
    {
        axis = Input.GetAxisRaw("Horizontal");

        if(axis >0f && !turnedRight)
        {
           turnedRight=!turnedRight;
           tr.localScale = new Vector2(-tr.localScale.x, tr.localScale.y);  
        }
        else if(axis <0f && turnedRight)
        {
           turnedRight=!turnedRight;             
           tr.localScale = new Vector2(-tr.localScale.x, tr.localScale.y);
        }       
    }
    public void Interactions()
    {
        // if(ItemBehaviour.item[0] && ItemBehaviour.activeItem[0])
        // {
        //     if(ItemBehaviour.itemNameAux == "Teste" )
        //     {
        //         print("Encontrou o item");
        //     }
            
        // }
        // if(ItemBehaviour.item[1] && ItemBehaviour.activeItem[1])
        // {
        //    if(ItemBehaviour.itemNameAux == "Teste2" )
        //     {
        //         print("Encontrou o item2");
        //     }
        // }
    }
    public void GhostActions()
    {
        if(TimeBehaviour.timeIsUp)
        {
            canMove = false;
            ghost.GetComponent<SpriteRenderer>().enabled = true;
            if(tr.position.x<ghost.transform.position.x)
            {
                rigidBody.velocity = new Vector2(movementSpeed, rigidBody.velocity.y);
                Flip();
            }
            else
            {
                rigidBody.velocity = new Vector2(-movementSpeed, rigidBody.velocity.y);
                Flip();
            }
            
        }
    }
}
