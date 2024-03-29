using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    // Components
    private PlayerData playerData;
    private Rigidbody2D rb;
    private Animator _animator; 
    
    // Movement Vars
    private bool isFirstDrop = true; 
    private bool canMove = false;
    private bool isMoving = false;
    private bool isShooting = false;
    private bool isJumping = false;
    private bool isGrounded = false;
    private SpriteRenderer _spriteRenderer;
    
    // Jump vars
    private float jumpSustain = 0.1f;
    private float jumpCooldown = .25f;
    private int jumpcount = 1;
    private float jumpMixForce = 20f;
    private float jumpMaxForce = 550f;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        canMove = true;
        
        playerData = GetComponent<PlayerCore>().Data;
        rb = GetComponentInParent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * playerData.speed;

        if (moveX < 0) _spriteRenderer.flipX = false;
        else if (moveX > 0) _spriteRenderer.flipX = true;
            
        if (moveX != 0) isMoving = true;
        else isMoving = false;

        rb.velocity = new Vector2( moveX, rb.velocity.y);

        jumpSustain = 0.1f;
        if (Input.GetButton("Jump") && isGrounded)
        {
            jumpSustain += 20f;
            rb.AddForce(Vector2.up * Math.Clamp(playerData.jumpSpeed * jumpSustain, 20f, 200f));
            _animator.SetBool("isJumping", true);
            isGrounded = false;
        }

        if (rb.velocity.y < 0 && !isFirstDrop)
        {
            _animator.SetBool("isFalling", true);
            _animator.SetBool("isJumping", false);
        }

        _animator.SetBool("isMoving", isMoving); 
        _animator.SetBool("isGrounded", isGrounded); 
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject chao = col.gameObject;
        if (chao.CompareTag("floor"))
        {
            if (isFirstDrop) isFirstDrop = false;
            isGrounded = true;
            _animator.SetBool("isFalling", false);
            _animator.SetBool("isJumping", false);
        }
        
    }
}
