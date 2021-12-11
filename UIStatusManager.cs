using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStatusManager : SingletonMonoBehaviour<UIStatusManager>
{

    GameObject playerStatusUI;
    new protected void Awake()
    {
        playerStatusUI = transform.Find("PlayerStatusUI").GetComponent<Transform>().gameObject;
    }

    private void Update()
    {
        if (GameManager.GameState == GameState.Menu)
            On3DUIEnable();
        else if (GameManager.GameState != GameState.Menu)
            On3DUIDisable();
    }

    public void On3DUIEnable()
    {
        playerStatusUI.SetActive(false);
    }

    public void On3DUIDisable()
    {
        playerStatusUI.SetActive(true);
    }
}
