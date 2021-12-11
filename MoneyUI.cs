using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : SingletonMonoBehaviour<MoneyUI>
{
    public GameObject moneyBox;
    public GameObject moneyBox1;
    public GameObject moneyBox2;
    public GameObject moneyBox3;

    new protected void Awake()
    {
        base.Awake();
        moneyBox = transform.Find("MoneyBG/BG").GetComponent<Transform>().gameObject;
        moneyBox1 = transform.Find("MoneyBG/BG1").GetComponent<Transform>().gameObject;
        moneyBox2 = transform.Find("MoneyBG/BG2").GetComponent<Transform>().gameObject;
        moneyBox3 = transform.Find("MoneyBG/BG3").GetComponent<Transform>().gameObject;
    }

    public void InitMoney(int userMoney)
    {
        List<GameObject> moneyBoxes = new List<GameObject>() { moneyBox, moneyBox1, moneyBox2, moneyBox3 };

        string moneyString = userMoney.ToString();

        for (int i = 0; i < moneyBoxes.Count; i++)
        {
            if (i < moneyString.Length)
            {
                moneyBoxes[i].SetActive(true);
                moneyBoxes[i].GetComponentInChildren<Text>().text = moneyString[i].ToString();
            }
            else
            {
                moneyBoxes[i].SetActive(false);
            }
        }
    }

}
