using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{

    public void OnMove()
    {
        Debug.LogError(gameObject.name);
    }

    public void OnAttack()
    {
        Debug.LogError(gameObject.name);
    }

}
