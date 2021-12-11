using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ItemBox))]
public class EquipItemBox : MonoBehaviour
{
    public int index;
    public ItemBox itemBox;

    internal void LinkComponent()
    {
        itemBox = GetComponent<ItemBox>();
        itemBox.LinkComponent();
    }

    internal void Init(InventoryItem inventoryItem)
    {
        itemBox.Init(inventoryItem);
    }
}
