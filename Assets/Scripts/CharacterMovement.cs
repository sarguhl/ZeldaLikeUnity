using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 40f;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector2.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
    }

    // Update animations for moving the character
    void UpdateAnimatorAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            anim.SetFloat("moveX", change.x);
            anim.SetFloat("moveY", change.y);
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }

    // Move the character in a position
    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }

    // Execute the Movement Animator
    void FixedUpdate()
    {
        UpdateAnimatorAndMove();
    }
}
