using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfoUI : SingletonMonoBehaviour<SkillInfoUI>
{
    Text skillDescription;
    Text skillName;

    new protected void Awake()
    {
        base.Awake();
        skillDescription = transform.Find("Status/Description").GetComponent<Text>();
        skillName = transform.Find("Name").GetComponent<Text>();
    }

    public void OnSkillSelected(SkillData skill)
    {
        skillName.text = skill.Name;
        skillDescription.text = skill.Description;
    }
}
