using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int sunNum;

    public GameObject bornParent;
    public GameObject zombiePrefab;
    public float createZombieTime;
    private void Start()
    {
        instance = this;
        //sunNum = 100;
        UIManager.instance.InitUI();
        CreateZombie();
    }
    private void Update()
    {
        
    }
    public void ChangeSunNum(int changeNum)
    {
        sunNum += changeNum;
        if (sunNum <= 0)
        {
            sunNum = 0;
            //todo
        }
        UIManager.instance.UpdateUI();
    }
    public void CreateZombie()
    {
        StartCoroutine(DalayCreateZombie());
    }
    IEnumerator DalayCreateZombie()
    {
        yield return new WaitForSeconds(createZombieTime);
        GameObject obj = Instantiate(zombiePrefab);
        int index = Random.Range(0,5);
        Transform pos = bornParent.transform.GetChild(index);
        //obj.transform.SetParent(pos,false);
        obj.transform.parent = pos.transform;
        obj.transform.position = pos.position;
        StartCoroutine(DalayCreateZombie());
    }
}
