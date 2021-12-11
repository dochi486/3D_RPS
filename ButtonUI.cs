using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : SingletonMonoBehaviour<ButtonUI>
{
    Button questButton;
    Button inventoryButton;
    Button mapButton;
    Button challengeButton;
    Button skillButton;
    internal Text currentMenu;
    Button quitButton;

    new protected void Awake()
    {
        base.Awake();
        questButton = transform.Find("Buttons/QuestButton").GetComponent<Button>();
        questButton.onClick.AddListener(() => LinkQuestUIButton());
        inventoryButton = transform.Find("Buttons/InventoryButton").GetComponent<Button>();
        inventoryButton.onClick.AddListener(() => LinkInvenButton());
        currentMenu = transform.Find("CurrentMenu/Text").GetComponent<Text>();
        quitButton = transform.Find("QuitButton").GetComponent<Button>();
        quitButton.onClick.AddListener(() => QuitUI());
        skillButton = transform.Find("Buttons/SkillButton").GetComponent<Button>();
        skillButton.onClick.AddListener(() => LinkSkillUIButton());
        challengeButton = transform.Find("Buttons/ChallengeButton").GetComponent<Button>();
        challengeButton.onClick.AddListener(() => LinkChallengeUIButton());
    }

    private void LinkChallengeUIButton()
    {
        UIManager.Instance.AchivementUIInit();
        currentMenu.text = "도전 과제";
    }

    //private void OnEnable()
    //{
    //    currentMenu.text = 
    //}

    private void LinkSkillUIButton()
    {
        UIManager.Instance.SkillUIInit();
        currentMenu.text = "스킬";
    }

    private void QuitUI()
    {
        UIManager.Instance.CloseUI();
    }

    private void LinkInvenButton()
    {
        UIManager.Instance.InventoryUIInit();
        currentMenu.text = "인벤토리";
    }

    private void LinkQuestUIButton()
    {
        UIManager.Instance.QuestUIInit();
        currentMenu.text = "퀘스트";
    }

}
