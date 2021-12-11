using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour
{
    TextMeshProUGUI hpStat;
    Slider hpBar;
    TextMeshProUGUI shieldStat;
    Slider shieldBar;
    Slider expBar;
    TextMeshProUGUI ammoCountText;
    Slider ammoBar;
    Text grenadeCount;
    Text levelText;

    void Awake()
    {
        hpStat = transform.Find("HP/HPText").GetComponent<TextMeshProUGUI>();
        hpBar = transform.Find("HP").GetComponentInChildren<Slider>();
        shieldStat = transform.Find("Shield/ShieldText").GetComponent<TextMeshProUGUI>();
        shieldBar = transform.Find("Shield").GetComponentInChildren<Slider>();
        expBar = transform.Find("Exp").GetComponent<Slider>();
        ammoCountText = transform.Find("Ammo/Text").GetComponent<TextMeshProUGUI>();
        ammoBar = transform.Find("Ammo").GetComponent<Slider>();
        grenadeCount = transform.Find("Grenade/Count").GetComponent<Text>();
        levelText = transform.Find("Level/Text").GetComponent<Text>();
    }
    void Update()
    {
        hpBar.value = UserData.Instance.hp;
        hpStat.text = $"{UserData.Instance.hp}/{hpBar.maxValue}";
        shieldBar.value = UserData.Instance.shield;
        shieldStat.text = $"{UserData.Instance.shield}/{shieldBar.maxValue}";
        expBar.value = UserData.Instance.exp;
        grenadeCount.text = $"{UserData.Instance.accountData.data.grenadeCount} / 3"; //�ִ� ������ ���� �����ο��� ������ �ְ��ϱ�
        EquippedAmmoCheck();
        ammoBar.value = UserData.Instance.accountData.data.currentWeaponAmmoCount;
        levelText.text = $"Lv.{UserData.Instance.accountData.data.level} {UserData.Instance.accountData.data.playerClass}";
    }

    private void EquippedAmmoCheck()
    {
        if(Player.instance.weapon1.ItemData == null)
        {
            ammoCountText.text = $"{UserData.Instance.accountData.data.currentWeaponAmmoCount} / max";
        }
        else if(Player.instance.weapon1.ItemData != null)
            ammoCountText.text = $"{UserData.Instance.accountData.data.currentWeaponAmmoCount} / {Player.instance.weapon1.ItemData.Magazinesize}";
        //���� ������ �������� źâ ����� ���� �ִ밪�� ���ϵ��� �ؾ���

    }
}
