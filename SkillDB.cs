using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum SkillType
{
    Attack,
    Defend,
    Buff,
    Passive
}


[System.Serializable]
public class UserSkill
{
    public int id;
    public SkillData SkillData => SkillDB.GetSkillInfo(id);
}

public class SkillDB : SingletonMonoBehaviour<SkillDB>
{
    public Skill skilldata;
    [SerializeField] List<SkillData> skillList;
    [SerializeField] Dictionary<int, SkillData> skillMap;
    new protected void Awake()
    {
        base.Awake();
        skillList = skilldata.dataArray.ToList();
        skillMap = skillList.ToDictionary(x => x.Skillid);
    }

    internal static SkillData GetSkillInfo(int skillID)
    {
        if (Instance.skillMap.TryGetValue(skillID, out SkillData result) == false)
            Debug.LogError($"{skillID}가 없습니다.");
        return result;
    }

    internal List<SkillData> GetSkillInfo(List<int> skillIDs)
    {
        List<SkillData> result = new List<SkillData>(skillIDs.Count);

        foreach (var item in skillIDs)
        {
            result.Add(GetSkillInfo(item));
        }
        return result;
    }
}
