using System;
using System.Collections;
using System.Collections.Generic;
using IndieMarc.EnemyVision;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public static CharacterMovement instance;
    public Animator playerAnimator;
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float playerSpeed;
    public GameObject moveSound;
    
    private VisionTarget vision_target;
    
    [Header("Hide")]
    public bool can_hide = true;
    public KeyCode hide_key = KeyCode.LeftShift;
    
    private Collider collide;
    
    private bool groundedPlayer;
    private float gravityValue = -29.81f;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerAnimator = gameObject.GetComponentInChildren<Animator>();
        vision_target = GetComponent<VisionTarget>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);
        
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            playerAnimator.SetBool("Push", true);
            moveSound.SetActive(true);
        }
        else
        {
            playerAnimator.SetBool("Push", false);
            moveSound.SetActive(false);
        }
        bool invisible = can_hide && Input.GetKey(hide_key);
        if (vision_target)
            vision_target.visible = !invisible;
        if (collide)
            collide.enabled = !invisible;

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
