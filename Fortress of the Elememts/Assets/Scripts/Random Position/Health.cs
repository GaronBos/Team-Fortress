    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Animator animator;
    public Slider healthBar;
    public int health;
    public int maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
      
    }
    void Update()
    {
       healthBar.value = health;

        if (health <=0)
        {
            animator.SetTrigger("Death");
            Destroy(gameObject, 3.6f);
        }
    }
}
