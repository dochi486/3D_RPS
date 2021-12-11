using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestInfoUI : SingletonMonoBehaviour<QuestInfoUI>
{
    Text questTitle;
    Text questDetail;
    Image questIcon;
    Text questDescription;
    Text questLevel;
    Text questDifficulty;

    new protected void Awake()
    {
        base.Awake();
        questTitle = transform.Find("BG/QuestTitle").GetComponent<Text>();
        questDetail = transform.Find("BG/QuestDetail/Text").GetComponent<Text>();
        questIcon = transform.Find("BG/QuestIcon").GetComponent<Image>();
        questDescription = transform.Find("BG/QuestDescription").GetComponent<Text>();
        questLevel = transform.Find("BG/QuestLevel").GetComponent<Text>();
        questDifficulty = transform.Find("BG/QuestDifficulty").GetComponent<Text>();

    }

    public void OnSelectedQuest(QuestData quest)
    {
        questTitle.text = quest.Title;
        questDescription.text = quest.Description;
        questDetail.text = quest.Requirement;
        questIcon.sprite = Resources.Load<Sprite>($"QuestIcon/{quest.QUESTTYPE}");
        questLevel.text = $"����: {quest.Level}";
        //questDifficulty.text = $"���̵�: {quest.Level / UserData.Instance.accountData.data.level}";
        //���̵� ����

        QuestDifficultyCheck(quest.Level, UserData.Instance.accountData.data.level);
        RewardUI.Instance.questType.text = RewardUI.Instance.QuestTypeConvert(quest.QUESTTYPE);
        RewardUI.Instance.rewardExp.text = quest.Rewardexp.ToString();
        RewardUI.Instance.InitRewardMoney(quest.Rewardgold);
    }

    private void QuestDifficultyCheck(int questLevel, int userLevel)
    {
        if (questLevel / userLevel >= 4)
            questDifficulty.text = "���̵� : �����";
        else if (questLevel / userLevel >= 0)
            questDifficulty.text = "���̵� : ����";
        else
            questDifficulty.text = "���̵� : ����";
    }
}
