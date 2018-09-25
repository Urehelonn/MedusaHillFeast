using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    public float moveSpeed;
    public bool playerMovingEnable;

    private Animator anim;
    private Rigidbody2D rb2d;
    private bool playerStop;
    private Vector2 facing;

	// Use this for initialization
	void Start () {
        playerMovingEnable = true;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {

        playerStop = true;

        if (playerMovingEnable && (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f))
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb2d.velocity.y);
            facing = new Vector2(Input.GetAxisRaw("Horizontal"),0f);
            playerStop = false;
        }
        if (playerMovingEnable && (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f))
        {
            //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            rb2d.velocity = new Vector2(rb2d.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            facing = new Vector2(0f,Input.GetAxisRaw("Vertical"));
            playerStop = false;
        }

        //when stop (v=0) horizontally 
        if(Input.GetAxisRaw("Horizontal")<0.5f && Input.GetAxisRaw("Horizontal")> -0.5f)
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
        }
        //when stop (v=0) Vertically
        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("Stop", playerStop);
        anim.SetFloat("LastMoveX", facing.x);
        anim.SetFloat("LastMoveY", facing.y);
    }
}
