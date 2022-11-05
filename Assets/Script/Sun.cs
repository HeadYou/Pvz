using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [Header("存在期間")]
    public float duration;
    private float timer;
    private void Start()
    {
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > duration)
        {
            Destroy(gameObject);
        }
    }
    private void OnMouseDown()
    {
        GameManager.instance.ChangeSunNum(25);
        //todo 飛行到陽光位置
        GameObject.Destroy(gameObject);
    }
}
