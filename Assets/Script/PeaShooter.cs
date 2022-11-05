using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : Plant
{
    [Header("�������j")]
    public float interval;
    private float timer;
    [Header("�l�u")]
    public GameObject bullet;
    public Transform bulletPos;

    protected override void Start()
    {
        base.Start();
        timer = 0;
    }

    private void Update()
    {
        if (!start) return;

        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0;
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }
    }
}
