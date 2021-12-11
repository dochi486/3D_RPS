using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardUI : SingletonMonoBehaviour<RewardUI>
{
    public GameObject moneyBox;
    public GameObject moneyBox1;
    public GameObject moneyBox2;
    public GameObject moneyBox3;
    public Text questType;
    public Text rewardExp;

    new protected void Awake()
    {
        questType = transform.Find("QuestType").GetComponent<Text>();
        rewardExp = transform.Find("EXP/Value").GetComponent<Text>();
        moneyBox = transform.Find("MoneyBG/BG").GetComponent<Transform>().gameObject;
        moneyBox1 = transform.Find("MoneyBG/BG1").GetComponent<Transform>().gameObject;
        moneyBox2 = transform.Find("MoneyBG/BG2").GetComponent<Transform>().gameObject;
        moneyBox3 = transform.Find("MoneyBG/BG3").GetComponent<Transform>().gameObject;
    }

    public void InitRewardMoney(int rewardMoney)
    {
        List<GameObject> moneyBoxes = new List<GameObject>() { moneyBox, moneyBox1, moneyBox2, moneyBox3 };

        string moneyString = rewardMoney.ToString();

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


        //if (rewardMoney >= 1000)
        //{
        //    moneyBox.GetComponentInChildren<Text>().text = rewardMoney.ToString().Substring(0, 1);
        //    moneyBox1.GetComponentInChildren<Text>().text = rewardMoney.ToString().Substring(1, 1);
        //    moneyBox2.GetComponentInChildren<Text>().text = rewardMoney.ToString().Substring(2, 1);
        //    moneyBox3.GetComponentInChildren<Text>().text = rewardMoney.ToString().Substring(3, 1);
        //}
        //else if (rewardMoney >= 100 && rewardMoney < 1000)
        //{
        //    moneyBox.GetComponentInChildren<Text>().text = rewardMoney.ToString().Substring(0, 1);
        //    moneyBox1.GetComponentInChildren<Text>().text = rewardMoney.ToString().Substring(1, 1);
        //    moneyBox2.GetComponentInChildren<Text>().text = rewardMoney.ToString().Substring(2, 1);
        //    moneyBox3.SetActive(false);
        //}
        //else if (rewardMoney >= 10 && rewardMoney < 100)
        //{
        //    moneyBox.GetComponentInChildren<Text>().text = rewardMoney.ToString().Substring(0, 1);
        //    moneyBox1.GetComponentInChildren<Text>().text = rewardMoney.ToString().Substring(1, 1);
        //    moneyBox2.SetActive(false);
        //    moneyBox3.SetActive(false);
        //}
        //else if (rewardMoney >= 0 && rewardMoney < 10)
        //{
        //    moneyBox.GetComponentInChildren<Text>().text = rewardMoney.ToString().Substring(0, 1);
        //    moneyBox1.SetActive(false);
        //    moneyBox2.SetActive(false);
        //    moneyBox3.SetActive(false);
        //}
    }

    public string QuestTypeConvert(QuestType type)
    {
        string result = "";
        switch (type)
        {
            case QuestType.Story:
                result = "스토리";
                break;
            case QuestType.SubQuest:
                result = "서브퀘스트";
                break;
            case QuestType.Tutorial:
                result = "튜토리얼";
                break;
        }
        return result;
    }

}
