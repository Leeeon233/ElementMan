﻿using System;
using QFramework;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 10f;                          // Amount of force added when the player jumps.
    [SerializeField] private float m_MoveSpeed = 5f;

	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement

    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] public Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] public Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    
    [SerializeField] private Vector2 GroundCheckSize;
    [SerializeField] private Vector2 CeilCheckSize;
    public bool m_Grounded=true;            // Whether or not the player is grounded.
    public bool m_Crouched=false;            // Whether or not the player is crouched.
    private bool wasGrounded;
    private bool wasCrouched;
    
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    public bool m_canChangeGravity = true;

    [Header("Events")]
    [Space]
    public BoolEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    //private bool m_wasCrouching = false;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new BoolEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();

    }


    private void FixedUpdate()
    {
	    // 调整跳跃手感
	    if (m_canChangeGravity)
	    {
		    if (m_Rigidbody2D.velocity.y <= 0)
		    {
			    
		    }
	    }
        // bool wasGrounded = m_Grounded;
        // m_Grounded = false;
        //
        // // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        // Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        // Debug.DrawRay(m_GroundCheck.position, new Vector3(0, -k_GroundedRadius, 0), Color.blue);
        // for (int i = 0; i < colliders.Length; i++)
        // {
        //     if (colliders[i].gameObject != gameObject)
        //     {
        //         m_Grounded = true;
        //         if (!wasGrounded && m_Rigidbody2D.velocity.y <= 0)
        //             OnLandEvent.Invoke(true);
        //     }
        // }
        // if (colliders.Length == 0)
        // {
        //     OnLandEvent.Invoke(false);
        // }
        // //Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround)
        // if (Physics2D.Raycast(m_CeilingCheck.position-Vector3.up*0.3f, Vector2.up, 
        //     0.3f,m_WhatIsGround))
        // {
        //     OnCrouchEvent.Invoke(true);
        // }
        // else
        // {
        //     OnCrouchEvent.Invoke(false);
        // }
        // if (Physics2D.OverlapBox(m_GroundCheck.position, CheckSize, 0, m_WhatIsGround))
        // {
	       //  if (m_Grounded && m_Rigidbody2D.velocity.y > 0) return;
	       //  m_Grounded = true;
	       //  OnLandEvent.Invoke(true);
        // }else
        // {
	       //  if (!m_Grounded) return;
	       //  m_Grounded = false;
	       //  OnLandEvent.Invoke(false);
        // }

        #region Ground Check
	        wasGrounded = m_Grounded;
	        m_Grounded = false;
	        
	        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
	        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
	        
	        if (Physics2D.OverlapBox(m_GroundCheck.position, GroundCheckSize, 0, m_WhatIsGround))
	        {
		        m_Grounded = true;
		        if (!wasGrounded && m_Rigidbody2D.velocity.y <= 1e-5)
			        OnLandEvent.Invoke(true);
	        }
	        else if(wasGrounded)
	        {
		        OnLandEvent.Invoke(false);
        }
        #endregion
        #region Ceil Check
	        wasCrouched = m_Crouched;
	        m_Crouched = false;
		        
	        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
	        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
		        
	        if (Physics2D.OverlapBox(m_CeilingCheck.position, CeilCheckSize, 0, m_WhatIsGround))
	        {
		        m_Crouched = true;
		        if (!wasCrouched)
			        OnCrouchEvent.Invoke(true);
	        }
	        else if(wasCrouched)
	        {
		        OnCrouchEvent.Invoke(false);
	        }
        #endregion
        
        
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawCube(m_GroundCheck.position, GroundCheckSize);
    //     Gizmos.color = Color.green;
    //     Gizmos.DrawCube(m_CeilingCheck.position, CeilCheckSize);
    // }

    public void Move(float move, bool jump)
    {
        // If crouching, check to see if the character can stand up
        // If the character has a ceiling preventing them from standing up, keep them crouching

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {
            /*// If crouching
			if (crouch)
			{
				if (!m_wasCrouching)
				{
					m_wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				// Reduce the speed by the crouchSpeed multiplier
				move *= m_CrouchSpeed;

				// Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			}
			else
			{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;

				if (m_wasCrouching)
				{
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}*/

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * m_MoveSpeed, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
        // If the player should jump...
        if (jump)
        {
            // Add a vertical force to the player.
            //m_Rigidbody2D.AddForce(m_Grounded?new Vector2(0f, m_JumpForce): new Vector2(0f, m_JumpForce));
            m_Grounded = false;
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, m_JumpForce);
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}