using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Axe : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private HitCheck hitCheck;

    public void Swing()
    {
        if (animator.GetBool("Can Swing"))
        {
            animator.SetTrigger("Axe Swing");
            animator.enabled = true;
        }
    }

    public void Hit()
    {
        hitCheck.Hit();
    }
}
