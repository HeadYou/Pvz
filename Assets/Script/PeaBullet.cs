using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    [Header("¤è¦V")]
    public Vector3 direction;
    public float speed;
    public float damage=1;
    private void Start()
    {
        Destroy(gameObject, 10f);
    }
    private void Update()
    {
        transform.position += direction * speed*Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            Destroy(gameObject);
            collision.GetComponent<ZombieNormal>().ChangeHealth(-damage);
        }
    }
}
