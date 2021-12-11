using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestListUI : SingletonMonoBehaviour<QuestListUI>
{
    public TextBox baseBox;
    public List<GameObject> questBoxes = new List<GameObject>();

    new protected void Awake()
    {
        baseBox = transform.Find("BG/Scroll View/Viewport/Content/Item").GetComponent<TextBox>();
        baseBox.LinkComponent();
    }

    private void OnEnable()
    {
        CameraLayerManager.Instance.OnUIEnable(0);
        UIManager.Instance.ShowUI();
        GameManager.GameState = GameState.Menu;
        ButtonUI.Instance.currentMenu.text = "Äù½ºÆ®";
        RefreshQuestList();
    }

    new protected void OnDisable()
    {
        if (ApplicationQuit)
            return;

        CameraLayerManager.Instance.OnUIDisable(6);
    }

    private void RefreshQuestList()
    {
        var activeIDs = UserData.Instance.questData.data.acceptedQuestIds;
        var activeQuests = QuestDB.Instance.GetQuestInfo(activeIDs);
        questBoxes.ForEach(x => Destroy(x));
        questBoxes.Clear();
        baseBox.gameObject.SetActive(true);

        int activeID = UserData.Instance.questData.data.selectedQuestID;

        foreach (var item in activeQuests)
        {
            var newItem = Instantiate(baseBox, baseBox.transform.parent);
            newItem.text.text = item.Title;
            newItem.icon.sprite = Resources.Load<Sprite>($"QuestIcon/{item.QUESTTYPE}");
            newItem.selectedGo.SetActive(activeID == item.ID);
            newItem.button.onClick.AddListener(() => OnClick(item));

            questBoxes.Add(newItem.gameObject);
        }
        baseBox.gameObject.SetActive(false);
    }

    private void OnClick(QuestData item)
    {
        UserData.Instance.questData.data.selectedQuestID = item.ID;
        RefreshQuestList();
        QuestInfoUI.Instance.OnSelectedQuest(item);
        CurrentQuestUI.Instance.ShowSelectedQuest(item);
    }
}
