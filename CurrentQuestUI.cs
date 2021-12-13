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
        //퀘스트 진행상황 체크해서 체크박스에 체크, 텍스트 표시로 남은 카운트 보여주기
        //퀘스트 매니저에서 확인하고 관리하게 하기
    }

    internal void ShowSelectedQuest(QuestData quest)
    {
        questTitle.text = string.Empty;
        questTitle.text = quest.Title;
        questObject.text = string.Empty;
        questObject.text = quest.Requirement;
    }

}
