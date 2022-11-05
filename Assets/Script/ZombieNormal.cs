using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNormal : MonoBehaviour
{
    public Vector3 direction = new Vector3(-1, 0, 0);
    public float speed = 10;
    private bool isWalk;
    private Animator ani;

    public float damage;
    public float damageInterval = 0.5f;
    private float damageTimer;

    public float health = 12;
    public float lostHeadHealth = 4;
    private float currentHealth;
    private GameObject head;
    private bool lostHead;
    private bool isDie;

    private void Start()
    {
        isWalk = true;
        ani = GetComponent<Animator>();
        damageTimer = 0;

        currentHealth = health;
        head = transform.GetChild(0).gameObject;
        lostHead = false;
        isDie = false;
    }
    private void Update()
    {
        if (isDie)
            return;
        Move();
    }

    private void Move()
    {
        if (isWalk)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDie)
            return;
        if (collision.CompareTag("Plant"))
        {
            isWalk = false;
            ani.SetBool("Walk", isWalk);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Plant"))
        {
            if (isDie)
                return;
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                damageTimer = 0;
                //對植物造成傷害
                PeaShooter peaShooter = collision.GetComponent<PeaShooter>();
                float newHealth = peaShooter.ChangeHealth(-damage);
                if (newHealth <= 0)
                {
                    isWalk = true;
                    ani.SetBool("Walk", isWalk);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Plant"))
        {
            isWalk = true;
            ani.SetBool("Walk", isWalk);
        }
    }
    public void ChangeHealth(float num)
    {
        currentHealth = Math.Clamp(currentHealth + num, 0, health);
        if (currentHealth <= lostHeadHealth && !lostHead)
        {
            lostHead = true;
            gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("LostHead");
            ani.SetBool("LostHead", true);
            head.SetActive(true);
        }
        if (currentHealth <= 0 && !isDie)
        {
            ani.SetTrigger("Die");
            isDie = true;
        }
    }
    public void DieAniOver()
    {
        ani.enabled = false;
        Destroy(gameObject);
    }
}
