using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : SingletonMonoBehaviour<SkillUI>
{
    GameObject attackSkillUI;
    Animator attackSkillUIAnim;
    GameObject defendSkillUI;
    Animator defendSkillUIAnim;
    Text skillPointValue;
    SkillBox attackSkillBox;
    SkillBox defendSkillBox;
    public List<GameObject> attackSkillGos = new List<GameObject>();
    List<UserSkill> showAttackSkill = new List<UserSkill>();
    public List<GameObject> defendSkillGos = new List<GameObject>();
    List<UserSkill> showDefendSkill = new List<UserSkill>();

    new protected void Awake()
    {
        base.Awake();
        attackSkillUI = transform.Find("AttackSkill").gameObject;
        attackSkillUIAnim = transform.Find("AttackSkill").GetComponent<Animator>();
        defendSkillUI = transform.Find("DefendSkill").gameObject;
        defendSkillUIAnim = transform.Find("DefendSkill").GetComponent<Animator>();
        skillPointValue = transform.Find("PlayerInfo/SkillPoint/Value").GetComponent<Text>();
        attackSkillBox = transform.Find("AttackSkill/BG/Skills/Skill").GetComponent<SkillBox>();
        attackSkillBox.LinkComponent();
        defendSkillBox = transform.Find("DefendSkill/BG/Skills/Skill").GetComponent<SkillBox>();
        defendSkillBox.LinkComponent();
    }

    public void ShowAttackSkillUI() //ArrowButton에다가 인스펙터에서 온클릭 이벤트로 연결해놓음
    {
        attackSkillUIAnim.Play("UI_BagSelected");
        defendSkillUIAnim.Play("UI_EquipNotSelected");
        attackSkillUI.transform.SetAsLastSibling();
        defendSkillUI.transform.SetAsFirstSibling();
        InitAttackSkillUI();
    }

    public void ShowDefendSkillUI() //ArrowButton에다가 인스펙터에서 온클릭 이벤트로 연결해놓음
    {
        attackSkillUIAnim.Play("UI_BagNotSelected");
        defendSkillUIAnim.Play("UI_EquipSelected");
        attackSkillUI.transform.SetAsFirstSibling();
        defendSkillUI.transform.SetAsLastSibling();
        InitDefendSkillUI();
    }

    public void OnLevelUp()
    {
        int skillPoint = 1;
        skillPointValue.text = skillPoint.ToString();
    }

    private void OnEnable()
    {
        CameraLayerManager.Instance.OnUIEnable(0);
        UIManager.Instance.ShowUI();
        GameManager.GameState = GameState.Menu;
        ButtonUI.Instance.currentMenu.text = "스킬";
        InitDefendSkillUI();
        InitAttackSkillUI();
    }

    new protected void OnDisable()
    {
        if (ApplicationQuit)
            return;

        CameraLayerManager.Instance.OnUIDisable(6);
    }

    public void InitAttackSkillUI()
    {
        var attackSkillIDs = UserData.Instance.skillData.data.userAttackSkillList;
        var activeAttackSkills = SkillDB.Instance.GetSkillInfo(attackSkillIDs);

        attackSkillGos.ForEach(x => Destroy(x));
        attackSkillGos.Clear();
        showAttackSkill.Clear();

        attackSkillBox.gameObject.SetActive(true);

        foreach(var item in activeAttackSkills)
        {
            var newSkillBox = Instantiate(attackSkillBox, attackSkillBox.transform.parent);
            newSkillBox.Init(item);
            newSkillBox.button.onClick.AddListener(() => OnClick(item));

            attackSkillGos.Add(newSkillBox.gameObject);
        }
        attackSkillBox.gameObject.SetActive(false);
    }

    private void OnClick(SkillData skill)
    {
        SkillInfoUI.Instance.OnSkillSelected(skill);
    }

    public void InitDefendSkillUI()
    {
        var defendSkillIDs = UserData.Instance.skillData.data.userDefendSkillList;
        var activeDefendSkills = SkillDB.Instance.GetSkillInfo(defendSkillIDs);

        defendSkillGos.ForEach(x => Destroy(x));
        defendSkillGos.Clear();
        showDefendSkill.Clear();

        defendSkillBox.gameObject.SetActive(true);

        foreach (var item in activeDefendSkills)
        {
            var newSkillBox = Instantiate(defendSkillBox, defendSkillBox.transform.parent);
            newSkillBox.Init(item);
            newSkillBox.button.onClick.AddListener(() => OnClick(item));

            defendSkillGos.Add(newSkillBox.gameObject);
        }
        defendSkillBox.gameObject.SetActive(false);
    }
}
