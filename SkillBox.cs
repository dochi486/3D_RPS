using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SkillBox : MonoBehaviour
{
    public Image skillIcon;
    public Button button;
    public GameObject selectedState;
    public UserSkill userSkill;
    public bool isSelected = false;

    internal void LinkComponent()
    {
        if (skillIcon == null)
            skillIcon = transform.Find("Icon").GetComponent<Image>();
        if (button == null)
            button = GetComponent<Button>();
        if (selectedState == null)
            selectedState = transform.Find("SelectedState")?.gameObject;
    }

    internal void Init(SkillData skill)
    {
        if(skill != null)
        {
            userSkill.id = skill.Skillid;
            skillIcon.enabled = true;
            skillIcon.sprite = Resources.Load<Sprite>($"SkillIcon/{skill.Iconname}");
        }
        else
        {
            skillIcon.sprite = null;
            skillIcon.enabled = false;
        }
    }

    public void SelectSkill()
    {
        if (isSelected)
        {
            transform.Find("Frame").gameObject.SetActive(true);
            selectedState.SetActive(false);
            isSelected = false;
        }
        else
        {
            transform.Find("Frame").gameObject.SetActive(false);
            selectedState.SetActive(true);
            isSelected = true;
        }
    }
}
