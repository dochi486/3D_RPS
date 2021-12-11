using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeUI : SingletonMonoBehaviour<ChallengeUI>
{
    ChallengeBox challengeBoxBase;
    public List<GameObject> challengeGOs = new List<GameObject>();
    public ChallengeBox newChallengeBox;

    new protected void Awake()
    {
        base.Awake();
        challengeBoxBase = transform.Find("ChallengeList/BG/Scroll View/Viewport/Content").GetComponentInChildren<ChallengeBox>(true);
        challengeBoxBase.LinkComponent();
    }

    private void OnEnable()
    {
        CameraLayerManager.Instance.OnUIEnable(0);
        UIManager.Instance.ShowUI();
        GameManager.GameState = GameState.Menu;
        ButtonUI.Instance.currentMenu.text = "도전 과제";
        InitChallengeList();
    }

    new protected void OnDisable()
    {
        if (ApplicationQuit)
            return;

        CameraLayerManager.Instance.OnUIDisable(6);
    }

    public void InitChallengeList()
    {
        var userChallengeIDs = UserData.Instance.challengeData.data.userChallengeIDs;
        var userChallenges = ChallengeDB.Instance.GetChallengeDatas(userChallengeIDs);
        challengeGOs.ForEach(x => Destroy(x));
        challengeGOs.Clear();

        challengeBoxBase.gameObject.SetActive(true);
        foreach (var item in userChallenges)
        {
            newChallengeBox = Instantiate(challengeBoxBase, challengeBoxBase.transform.parent);
            newChallengeBox.LinkComponent();
            newChallengeBox.title.text = item.Title;
            newChallengeBox.slider.maxValue = item.Goalcount;

            challengeGOs.Add(newChallengeBox.gameObject);
        }
        challengeBoxBase.gameObject.SetActive(false);
    }
}
