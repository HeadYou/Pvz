using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    [Header("卡片對應預置物件")]
    public GameObject objPrefab;
    private GameObject curGameObj;
    //
    private GameObject darkBg;
    private GameObject progressBar;
    public float waitTime;
    public int useSun;
    private float timer;
    private void Start()
    {
        darkBg = transform.Find("dark").gameObject;
        progressBar = transform.Find("progress").gameObject;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        UpdateProgress();
        UpdateDarkBg();
    }
    private void UpdateProgress()
    {
        float per = Mathf.Clamp(1 - (timer / waitTime), 0, 1);
        progressBar.GetComponent<Image>().fillAmount = per;
    }
    private void UpdateDarkBg()
    {
        if (progressBar.GetComponent<Image>().fillAmount == 0 && GameManager.instance.sunNum >= useSun)
        {
            darkBg.SetActive(false);
        }
        else
        {
            darkBg.SetActive(true);
        }
    }
    //
    public void OnBeagion(BaseEventData data)
    {
        if (darkBg.activeSelf)
        {
            return;
        }
        PointerEventData pointerEventDate = data as PointerEventData;
        curGameObj = Instantiate(objPrefab);
        curGameObj.transform.position = TranlateScreenToWord(pointerEventDate.position);
    }
    public void OnDrag(BaseEventData data)
    {
        if (curGameObj == null)
        {
            return;
        }
        PointerEventData pointerEventData = data as PointerEventData;
        curGameObj.transform.position = TranlateScreenToWord(pointerEventData.position);
    }
    public void OnEndDrag(BaseEventData data)
    {
        if (curGameObj == null)
        {
            return;
        }
        PointerEventData pointerEventData = data as PointerEventData;
        Collider2D[] colBox = Physics2D.OverlapPointAll(TranlateScreenToWord(pointerEventData.position));
        foreach (Collider2D i in colBox)
        {
            if (i.tag == "Land" && i.transform.childCount == 0)
            {
                curGameObj.transform.parent = i.transform;
                curGameObj.transform.localPosition = Vector3.zero;
                GameManager.instance.ChangeSunNum(-useSun);
                curGameObj.GetComponent<Plant>().SetPlantStart();
                curGameObj = null;
                //重製計時
                timer = 0;
                break;
            }
        }
        if (curGameObj != null)
        {
            GameObject.Destroy(curGameObj);
            curGameObj = null;
        }
    }
    public static Vector3 TranlateScreenToWord(Vector3 position)
    {
        Vector3 cameraPos = Camera.main.ScreenToWorldPoint(position);
        return new Vector3(cameraPos.x, cameraPos.y, 0);
    }
}
