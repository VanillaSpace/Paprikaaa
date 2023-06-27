using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    [Category("Character")]
    private Rigidbody2D rigidbody2d;
    [SerializeField] float speed = 2f;
    private Vector2 motionVector;
    public Vector2 lastMotionVector;
    
    [Category("Animators")]
    private Animator characterAnimator;
    [SerializeField] Animator[] skinAnimator;
    public bool moving;
    
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        characterAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        motionVector = new Vector2(
            horizontal,
            vertical
            );
        
        TypeOfAnimation(characterAnimator);
        TypeOfAnimation(skinAnimator[0]); //TODO: Change this into a TMap
        
        // Detection of movement from player is based on their horizontal and vertical values
        // Feeding it back to the animator
        moving = isPlayerMoving(horizontal, vertical);
        characterAnimator.SetBool("moving", moving);

        // Storing position from last movement
        setLastMotionVector(horizontal, vertical);
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
       rigidbody2d.velocity = motionVector * speed;
    }

    private void TypeOfAnimation(Animator animator)
    {
        animator.SetFloat("horizontal", motionVector.x);
        animator.SetFloat("vertical", motionVector.y);
        animator.SetFloat("speed", motionVector.sqrMagnitude);
    }

    public bool isPlayerMoving(float horizontal, float vertical)
    {
        return horizontal != 0 || vertical != 0;
    }

    public void setLastMotionVector(float h, float v)
    {
        if (h != 0 || v != 0)
        {
            lastMotionVector = new Vector2(h, v).normalized;

            characterAnimator.SetFloat("lastHorizontal", h);
            characterAnimator.SetFloat("lastVertical", v);
        }
    }
}



