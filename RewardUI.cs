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
    }

    public string QuestTypeConvert(QuestType type)
    {
        string result = string.Empty;
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
