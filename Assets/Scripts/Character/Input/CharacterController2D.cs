using System;
using QFramework;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 10f;                          // Amount of force added when the player jumps.
    [SerializeField] private float m_MoveSpeed = 5f;
    [SerializeField] private float fallFactor = 1f;

	[Range(0, 1f)] [SerializeField] private float m_MovementSmoothing = .6f;  // How much to smooth out the movement

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
    //private Vector3 m_Velocity = Vector3.zero;
    public bool m_canChangeGravity = true;
    private Vector2 m_Velocity = Vector2.zero;
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

    private Vector2 tmp;
    Vector2 targetVelocity;
    private void Update()
    {
	    // 调整跳跃手感
	    
	    if (m_canChangeGravity && m_Rigidbody2D.velocity.y < Physics2D.gravity.y * fallFactor * Time.deltaTime)
	    {
		    var velocity = m_Rigidbody2D.velocity;
		    tmp.x = velocity.x;
		    tmp.y = velocity.y + Physics2D.gravity.y * fallFactor * Time.deltaTime;
		    velocity = tmp;
		    m_Rigidbody2D.velocity = velocity;
	    }
    }

    private void FixedUpdate()
    {
		#region Ground Check
		
        wasGrounded = m_Grounded;
        m_Grounded = false;
        
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        
        if (Physics2D.OverlapBox(m_GroundCheck.position, GroundCheckSize, 0, m_WhatIsGround))
        {
	        m_Grounded = true;
	        //(m_Rigidbody2D.velocity.y).LogInfo();
	        if (!wasGrounded && m_Rigidbody2D.velocity.y < m_MoveSpeed-0.1f) //
	        {
		        
		        (m_Rigidbody2D.velocity.y).LogInfo();
		        //&& m_Rigidbody2D.velocity.y <= 1e-5}
		        OnLandEvent.Invoke(true);
	        }
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(m_GroundCheck.position, GroundCheckSize);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(m_CeilingCheck.position, CeilCheckSize);
    }

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
            
            // And then smoothing it out and applying it to the character
            targetVelocity.x = move * m_MoveSpeed;
            targetVelocity.y = m_Rigidbody2D.velocity.y;
            
            // m_Rigidbody2D.velocity = Mathf.Abs(move)< 1e-5
	           //  ? Vector2.Lerp(m_Rigidbody2D.velocity, targetVelocity, m_MovementSmoothing) 
	           //  : Vector2.Lerp(m_Rigidbody2D.velocity, targetVelocity, m_MovementSmoothing/5);
        
           if (Mathf.Abs(move)< 1e-5)
           {
	           m_Rigidbody2D.velocity = Vector2.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
           }
           else
           {
	           m_Rigidbody2D.velocity = Vector2.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing/5);
           }
	           
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
            targetVelocity.x = m_Rigidbody2D.velocity.x;
            targetVelocity.y = m_JumpForce;
            m_Rigidbody2D.velocity = targetVelocity;
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