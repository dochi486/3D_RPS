using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentQuestUI : SingletonMonoBehaviour<CurrentQuestUI>
{
    public Text questTitle;
    public Text questObject;
    GameObject completedState;

    new protected void Awake()
    {
        questObject = transform.Find("QuestObject/ObjectText").GetComponent<Text>();
        questTitle = transform.Find("QuestTitle").GetComponent<Text>();
        completedState = transform.Find("QuestObject/CheckBox/Check")?.gameObject;
    }

    internal void QuestStatusCheck()
    {
        //����Ʈ �����Ȳ üũ�ؼ� üũ�ڽ��� üũ, �ؽ�Ʈ ǥ�÷� ���� ī��Ʈ �����ֱ�
        //����Ʈ �Ŵ������� Ȯ���ϰ� �����ϰ� �ϱ�
    }

    internal void ShowSelectedQuest(QuestData quest)
    {
        questTitle.text = string.Empty;
        questTitle.text = quest.Title;
        questObject.text = string.Empty;
        questObject.text = quest.Requirement;
    }

}
