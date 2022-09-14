using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Axe : MonoBehaviour
{
    public InputAction axe;
    [SerializeField] private Animator animator;
    [SerializeField] private HitCheck hitCheck;

    private void Awake()
    {
        // axe = axeInput.Player.Swing;
        axe.started += context => Swing();
    }
    private void OnEnable()
    {
        axe.Enable();
    }

    private void OnDisable()
    {
        axe.Disable();
    }

    private void Swing()
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
