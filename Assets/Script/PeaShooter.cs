using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : MonoBehaviour
{
    [Header("§ðÀ»¶¡¹j")]
    public float interval;
    private float timer;
    [Header("¤l¼u")]
    public GameObject bullet;
    public Transform bulletPos;

    public float health=6;
    private float currentHealth;
    private void Start()
    {
        currentHealth = health;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0;
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
    }
    public float ChangeHealth(float num)
    {
        currentHealth = Mathf.Clamp(currentHealth + num,0,health);
        if (currentHealth<=0)
        {
            Destroy(gameObject);
        }
        return currentHealth;
    }
}
