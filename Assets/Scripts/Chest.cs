using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : PhysicsObject
{
    public GameObject player;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("Сундук откройся");
            animator.SetBool("ChestOpen", true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("Сундук закройся");
            animator.SetBool("ChestOpen", false);
        }
    }
}
