using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    // Components
    private PlayerData playerData;
    private Rigidbody2D rb;
    
    // Movement Vars
    private bool canMove = false;
    private bool isMoving = false;
    private bool isShooting = false;
    private bool isJumping = false;
    private bool isGrounded = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerData = GetComponent<PlayerCore>().Data;
        rb = GetComponentInParent<Rigidbody2D>();
        
        Debug.Log(playerData.speed);
        Debug.Log(rb);
    }

    // Update is called once per frame
    void Update()
    {
       isGrounded = true if rb.OverlapCollider() 
    }
}
