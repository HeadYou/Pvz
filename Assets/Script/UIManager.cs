using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text sunNumText;
    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        
    }
    public void InitUI()
    {
        sunNumText.text = GameManager.instance.sunNum.ToString();
    }
    public void UpdateUI()
    {
        sunNumText.text = GameManager.instance.sunNum.ToString();
    }
}
