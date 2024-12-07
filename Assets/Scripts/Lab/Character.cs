using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private int health;
    public int Health
    {
        get 
        { 
            return health;
        }
        set 
        { 
            health = value;
        } 
    }

    public HealthBar healthBar;
    public Animator anim;
    public Rigidbody2D rb;

    public void Destroy()
    {
        if (IsDead())
        {
            Destroy(this.gameObject);
        }
    }
    public bool IsDead()
    {
        return Health <= 0;
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        healthBar.UpdateHealthBar(Health);
    }
    public void Init(int newHp)
    {
        Health = newHp;
        healthBar.SetMaxHealth(newHp);
    }
}
