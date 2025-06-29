﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator anim;
    private PlayerController player;
    private bool isTurning;
    private bool isMoving;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerController>();       
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Animate();
        }
    }

    private void Animate()
    {
        if (player.Direction.magnitude != 0)
        {
            isTurning = true;
        }
        else
        {
            isTurning = false;
        }

        if (isTurning)
        {
            anim.SetFloat("x", player.Direction.x);
            anim.SetFloat("y", player.Direction.y);
        }

        if (player.Direction.magnitude > 0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            anim.SetFloat("x", player.Direction.x);
            anim.SetFloat("y", player.Direction.y);
        }

        anim.SetBool("isMoving",isMoving);
    }
}
