using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    [SerializeField] private int maxHealth;
    [SerializeField] private int health;
    [SerializeField] private Animator animator;
    [SerializeField] private TMP_Text tMP_Text;


    private void Start()
    {
        health = maxHealth;
        UpdateText("Health: " + health.ToString());

    }

    public void Hit()
    {
        health--;
        if (health <= 0)
        {
            kill();
            UpdateText("Dead :(");
        }
        else
        {
            UpdateText("Health: " + health.ToString());
        }
    }

    private void kill()
    {
        Debug.Log(transform.parent.name + " Died");
        animator.SetTrigger("Die");
        animator.enabled = true;
    }

    private void UpdateText(string text)
    {
        tMP_Text.text = text;
    }

}
