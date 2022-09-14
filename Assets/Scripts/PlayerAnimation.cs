using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Axe axe;

    public void Die()
    {
        playerInput.enabled = false;
        axe.enabled = false;
    }

}
