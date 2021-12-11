using DG.Tweening;
using UnityEngine;

public enum MenuType
{
    Inventory,
    Skill,
    Quest,
}

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    internal CanvasGroup canvasGroup;
    Camera canvasCamera;
    GameObject bg;
    GameObject buttonPanel;
    GameObject inventoryPanel;
    GameObject questPanel;
    GameObject skillPanel;
    GameObject challengePanel;
    public MenuType menuType;

    new protected void Awake()
    {
        canvasGroup = GetComponentInChildren<CanvasGroup>(true);
        canvasCamera = GetComponentInChildren<Camera>(true);
        bg = transform.Find("3DCanvas/BG").gameObject;
        buttonPanel = transform.Find("3DCanvas/ButtonPanel").gameObject;
        inventoryPanel = transform.Find("3DCanvas/InventoryPanel").gameObject;
        questPanel = transform.Find("3DCanvas/QuestPanel").gameObject;
        skillPanel = transform.Find("3DCanvas/SkillPanel").gameObject;
        challengePanel = transform.Find("3DCanvas/ChallengePanel").gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            CloseUI();
    }

    internal void CloseUI()
    {
        GameManager.GameState = GameState.InPeace; 
        //SetUpdate(true)해주면 유니티 타임.타임스케일과 관계없이 DoTween진행된다.
        canvasGroup.DOFade(0, 0.5f).SetUpdate(true)
            .OnComplete(() =>
             {
                 canvasGroup.gameObject.SetActive(false);
             });
    }

    public void ShowUI()
    {
        canvasGroup.DOFade(1, 0.5f).SetUpdate(true)
        .OnComplete(() =>
        {
            canvasGroup.gameObject.SetActive(true);
        });
    }

    public void AchivementUIInit()
    {
        canvasGroup.gameObject.SetActive(true);
        canvasCamera.gameObject.SetActive(true);
        bg.SetActive(true);
        buttonPanel.SetActive(true);
        challengePanel.SetActive(true);

        if (inventoryPanel.activeSelf == true)
            inventoryPanel.SetActive(false);
        if (questPanel.activeSelf == true)
            questPanel.SetActive(false);
        if (skillPanel.activeSelf == true)
            skillPanel.SetActive(false);
    }

    public void SkillUIInit()
    {
        canvasGroup.gameObject.SetActive(true);
        canvasCamera.gameObject.SetActive(true);
        bg.SetActive(true);
        buttonPanel.SetActive(true);
        skillPanel.SetActive(true);

        if (inventoryPanel.activeSelf == true)
            inventoryPanel.SetActive(false);
        if (questPanel.activeSelf == true)
            questPanel.SetActive(false);
        if (challengePanel.activeSelf == true)
            challengePanel.SetActive(false);
    }

    public void QuestUIInit()
    {
        canvasGroup.gameObject.SetActive(true);
        canvasCamera.gameObject.SetActive(true);
        bg.SetActive(true);
        buttonPanel.SetActive(true);
        questPanel.SetActive(true);

        if (inventoryPanel.activeSelf == true)
            inventoryPanel.SetActive(false);
        if (skillPanel.activeSelf == true)
            skillPanel.SetActive(false);
        if (challengePanel.activeSelf == true)
            challengePanel.SetActive(false);
    }

    public void InventoryUIInit()
    {
        canvasGroup.gameObject.SetActive(true);
        canvasCamera.gameObject.SetActive(true);
        bg.SetActive(true);
        buttonPanel.SetActive(true);
        inventoryPanel.SetActive(true);

        if (questPanel.activeSelf == true)
            questPanel.SetActive(false);
        if (skillPanel.activeSelf == true)
            skillPanel.SetActive(false);
        if (challengePanel.activeSelf == true)
            challengePanel.SetActive(false);
    }
}
