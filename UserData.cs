using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[System.Serializable]
public class AccountData : ISerializationCallbackReceiver //계정의 정보
{
    public int gold;
    public int gem;
    public string userName;
    public int level;
    public int exp;
    public int hp;
    public int shield;
    public int grenadeCount;
    public int currentWeaponAmmoCount;
    public string playerClass;

    public void OnAfterDeserialize()
    {
        level = Math.Max(1, level);
    }

    public void OnBeforeSerialize() { }
}

[System.Serializable]
public class UserSkillData
{
    public List<int> userAttackSkillList = new List<int>();
    public List<int> userDefendSkillList = new List<int>();
    public int skillPoint;
}

[System.Serializable]
public class UserItemData : ISerializationCallbackReceiver
{
    public List<InventoryItem> item = new List<InventoryItem>();
    public Dictionary<int, InventoryItem> equipMap = new Dictionary<int, InventoryItem>(4);
    //현재 장착 중인 아이템의 아이디도 가지고 있게해서 그 아이템의 탄창크기, 공격력을 실제로 반영하도록 해야함

    public void OnAfterDeserialize() //데이터를 불러올 때 호출하는 함수
    {
        if (equipMap.Count == 0)
            equipMap.DefaultIfEmpty();
    }

    public void OnBeforeSerialize() //데이터를 저장할 때
    { }
}


[System.Serializable]
public class UserQuestData
{
    public List<int> acceptedQuestIds = new List<int>();
    public int selectedQuestID;
}

[System.Serializable]
public class UserChallenge
{
    public int id;
    public List<int> userChallengeIDs = new List<int>();
    
}

public class UserData : SingletonMonoBehaviour<UserData>
{
    public PlayerPrefsData<AccountData> accountData;
    public PlayerPrefsData<UserItemData> itemData;
    public PlayerPrefsData<UserQuestData> questData;
    public PlayerPrefsData<UserSkillData> skillData;
    public PlayerPrefsData<UserChallenge> challengeData;
    public float hp = 200;
    public float shield = 100;
    [SerializeField] internal int exp = 30;

    new protected void Awake()
    {
        base.Awake();
        accountData = new PlayerPrefsData<AccountData>("AccountData");
        itemData = new PlayerPrefsData<UserItemData>("UserItemData");
        questData = new PlayerPrefsData<UserQuestData>("UserQuestData");
        skillData = new PlayerPrefsData<UserSkillData>("UserSkillData");
        challengeData = new PlayerPrefsData<UserChallenge>("UserChallengeData");
    }

    internal List<InventoryItem> GetItemsByType(ItemType itemType)
    {
        return Instance.itemData.data.item.Where(x => x.ItemData.ITEMTYPE == itemType).ToList();
    }

    internal List<InventoryItem> GetItems(int itemID)
    {
        return Instance.itemData.data.item.Where(x => x.ItemData.ID == itemID).ToList();
    }

    internal InventoryItem GetItem(int itemID)
    {
        return itemData.data.item.Where(x => x.id == itemID).FirstOrDefault();
    }

    new protected void OnDestroy()
    {
        base.OnDestroy();
        itemData.SaveData();
        accountData.SaveData();
        questData.SaveData();
        skillData.SaveData();
        challengeData.SaveData();
    }
}
