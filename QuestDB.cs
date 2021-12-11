using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum QuestType
{
    Story,
    SubQuest,
    Tutorial
}

[System.Serializable]
public class UserQuest
{
    public int id;
}

public class QuestDB : SingletonMonoBehaviour<QuestDB>
{
    public Quest questData;
    [SerializeField] List<QuestData> questList;
    [SerializeField] Dictionary<int, QuestData> questMap;
    new protected void Awake()
    {
        base.Awake();
        questList = questData.dataArray.ToList();
        questMap = questList.ToDictionary(x => x.ID);
    }
    internal static QuestData GetQuestInfo(int questID)
    {
        if (Instance.questMap.TryGetValue(questID, out QuestData result) == false)
            Debug.LogError($"{questID}가 없습니다");
        return result;
    }

    internal List<QuestData> GetQuestInfo(List<int> questIDs)
    {
        List<QuestData> result = new List<QuestData>(questIDs.Count);

        foreach (var item in questIDs)
        {
            result.Add(GetQuestInfo(item));
        }
        return result;
    }
}
