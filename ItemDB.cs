using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum WeaponType
{
    Pistol,
    Rifle,
    SMG,
    Shotgun,
}

public enum ItemType
{
    Weapon,
    Grenade,
    Shield,
    Book
}


[System.Serializable]
public class InventoryItem
{
    public int id;

    public ItemData ItemData => ItemDB.GetItemInfo(id);
}

public class ItemDB : SingletonMonoBehaviour<ItemDB>
{
    public Item itemData;
    [SerializeField] List<ItemData> itemList;
    [SerializeField] Dictionary<int, ItemData> itemMap;
    public ItemSQL itemDBData;
    [SerializeField] List<ItemSQLData> itemDBList;
    [SerializeField] Dictionary<int, ItemSQLData> itemDBMap;

    new protected void Awake()
    {
        base.Awake();
        itemList = itemData.dataArray.ToList();
        itemMap = itemList.ToDictionary(x => x.ID);
        itemDBList = itemDBData.dataArray.ToList();
        itemDBMap = itemDBList.ToDictionary(x => x.Id);
    }

    internal static ItemData GetItemInfo(int itemID)
    {
        if (Instance.itemMap.TryGetValue(itemID, out ItemData result) == false)
            Debug.LogWarning($"{itemID}가 없습니다");
        return result;
    }
}
