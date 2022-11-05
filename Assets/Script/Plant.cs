using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public float health=6;
    protected float currentHealth;
    protected bool start;
    protected Animator ani;
    protected BoxCollider2D box;
    protected virtual void Start()
    {
        currentHealth = health;
        ani = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        ani.speed = 0;
        box.enabled = false;
    }
    public void SetPlantStart()
    {
        start = true;
        box.enabled = true;
        ani.speed = 1;
    }
    public virtual float ChangeHealth(float num)
    {
        currentHealth = Mathf.Clamp(currentHealth + num, 0, health);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        return currentHealth;
    }
}
