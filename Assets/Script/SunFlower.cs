using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : MonoBehaviour
{
    private Animator ani;
    public float readyTime;
    private float timer;
    public GameObject sunPrefab;
    private int sunNum;
    private void Start()
    {
        ani = GetComponent<Animator>();
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= readyTime)
        {
            ani.SetBool("Ready", true);
        }
    }
    //�o����n������
    private void BornSunOver()
    {
        BornSun();
        ani.SetBool("Ready", false);
        timer = 0;
    }
    private void BornSun()
    {
        GameObject newSun = Instantiate(sunPrefab);
        sunNum += 1;
        float randomX;
        if (sunNum % 2 == 0)
        {
            sunNum = 0;
            randomX = Random.Range(transform.position.x - 30, transform.position.x - 20);
        }
        else
        {
            randomX = Random.Range(transform.position.x + 20, transform.position.x + 30);
        }
        float randomY = Random.Range(transform.position.y - 20, transform.position.y + 20);
        newSun.transform.position = new Vector2(randomX, randomY);
    }
}