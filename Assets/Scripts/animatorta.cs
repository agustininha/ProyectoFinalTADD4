using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class animatorta : MonoBehaviour
{
    private Animator animator;
    private PlayerMov playerMovement;
    private float Horizontal;
    public static animatorta instance;
    private PlayerPushPull playerPushPull;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = PlayerMov.instance;
        playerPushPull = GetComponent<PlayerPushPull>();
    }

    void Update()
    {
        // Animaci�n Correr
        animator.SetBool("isRunning", playerMovement.isRunning);
        Horizontal = Input.GetAxis("Horizontal");

        // Animaci�n Idle
        if (playerMovement.Horizontal == 0 && playerMovement.GroundDetect() && !playerMovement.isCrouched)
        {
            animator.SetFloat("Y blend", 0);
            animator.SetFloat("X blend", 0);
        }

        // Animaci�n caminar
        else if (playerMovement.Horizontal != 0 && !playerMovement.isRunning)
        {
            animator.SetFloat("Y blend", 1);
            animator.SetFloat("X blend", -1);
        }

        // Animaci�n correr
        if (Input.GetKey(KeyCode.LeftShift) && playerMovement.Horizontal != 0)
        {
            animator.SetFloat("Y blend", 1);
            animator.SetFloat("X blend", 0);
        }

        // Animaci�n Jump 
        if (Input.GetKey(KeyCode.Space) && !playerMovement.GroundDetect())
        {
            animator.SetFloat("Y blend", 1);
            animator.SetFloat("X blend", 1);
        }

        // Animaci�n Crouch
        animator.SetBool("isCrouched", playerMovement.Horizontal == 0 && playerMovement.isCrouched);

        // Animaci�n CrawlWalk
        if (playerMovement.Horizontal != 0 && playerMovement.isCrouched)
        {
            animator.SetFloat("Y blend", 0.3f);
            animator.SetFloat("X blend", -1);
        }

        // Animaci�n Roll
        animator.SetBool("isRolling", Input.GetKey(KeyCode.X) && playerMovement.canRoll && playerMovement.Horizontal != 0);

        // Animaci�n PickUp
        animator.SetBool("isPickingUp", playerPushPull.isHoldingBox && playerMovement.Horizontal == 0);

        // Animaci�n PickUpMove
        animator.SetBool("isPickingUpMoving", playerPushPull.isHoldingBox && playerMovement.Horizontal != 0);

        //Animacion Change

        if (Input.GetKey(KeyCode.F))
        {
            animator.SetFloat("Y blend", -1);
            animator.SetFloat("X blend", 0);
        }

    }

    // Animaci�n Death
    public void DeathAnimation()
    {
        animator.SetTrigger("death");
    }
}
