using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private int chopsReq;
    [SerializeField] private Animator animator;
    [SerializeField] private float radius;
    private int chopCount = 0;

    public bool Chopped()
    {
        bool hit = false;
        if (animator.GetBool("Can Hit"))
        {
            chopCount++;
            hit = true;
            if (chopCount >= chopsReq)
            {
                Destroy(gameObject);
            }
            else
            {
                animator.SetTrigger("Tree Hit");
            }
        }
        return hit;
    }

    private void OnDrawGizmosSelected()
    {
        Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
        Gizmos.color = transparentGreen;
        Gizmos.DrawSphere(GetComponent<Renderer>().bounds.center, GetComponent<Renderer>().bounds.extents.y);
    }
}
