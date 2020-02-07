using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class PlayerInput : MonoBehaviour {
    public float runSpeed = 40f;

    private CharacterController2D controller;
    private Animator animator;

    private float horizontalMove = 0f;
    private bool jumping = false;

    void Start() {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) {
            jumping = true;
        }

        animator.SetFloat("Speed", controller.speed);
        animator.SetBool("Jumping", !controller.isGrounded);
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jumping);
        jumping = false;
    }
}