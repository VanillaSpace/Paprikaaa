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
    
    [Category("Animators")]
    private Animator characterAnimator;
    [SerializeField] Animator[] skinAnimator;
    
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        characterAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        motionVector = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );
        
        TypeOfAnimation(characterAnimator);
        TypeOfAnimation(skinAnimator[0]); //TODO: Change this into a TMap
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
}

internal class cat
{
}

internal class cow
{
}
