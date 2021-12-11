using System.Collections.Generic;
using UnityEngine;

public class EquipUI : SingletonMonoBehaviour<EquipUI>
{
    EquipItemBox baseBox;
    public List<GameObject> equippedGos = new List<GameObject>(4);
    public EquipItemBox newBox;
    public List<InventoryItem> showEquipList = new List<InventoryItem>(4);

    new protected void Awake()
    {
        base.Awake();
        baseBox = GetComponentInChildren<EquipItemBox>(true);
        baseBox.LinkComponent();
    }

    public void OnEnable()
    {
        InitEquipUI();
    }
    
    public void InitEquipUI()
    {
        equippedGos.ForEach(x => Destroy(x));
        equippedGos.Clear();
        showEquipList.Clear();

        for (int i = 1; i < 5; i++)
        {
            if (UserData.Instance.itemData.data.equipMap.ContainsKey(i))
            {
                var equipItem = UserData.Instance.itemData.data.equipMap[i];

                showEquipList.Add(equipItem);
            }
        }

        baseBox.gameObject.SetActive(true);

        foreach (var item in showEquipList)
        {
            newBox = Instantiate(baseBox, baseBox.transform.parent);
            newBox.Init(item);
            equippedGos.Add(newBox.gameObject);

            InventoryItem inventoryItem = UserData.Instance.GetItem(newBox.itemBox.inventoryItem.id);

            newBox.itemBox.button.onClick.AddListener(() => OnClick(inventoryItem));
        }
        baseBox.gameObject.SetActive(false);

        void OnClick(InventoryItem item)
        {
            ShowEquipUI();
            if (item != null)
            {
                ItemInfoUI.Instance.OnShowSelectedWeapon(item);
            }
        }
    }

    public void ShowEquipUI() //ArrowButton에다가 인스펙터에서 이벤트 연결해줌
    {
        InventoryUI.Instance.inventoryUIAnim.Play("UI_BagNotSelected");
        InventoryUI.Instance.equippedUIAnim.Play("UI_EquipSelected");
        transform.SetAsLastSibling();
    }
}
