using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : SingletonMonoBehaviour<InventoryUI>
{
    public Animator inventoryUIAnim;
    public Animator equippedUIAnim;
    public GameObject inventoryUI;
    public GameObject equipUI;
    ItemBox itemBox;
    public List<GameObject> inventoryGos = new List<GameObject>();


    new protected void Awake()
    {
        base.Awake();
        inventoryUIAnim = transform.Find("Bag").GetComponent<Animator>();
        inventoryUI = transform.Find("Bag").gameObject;
        equippedUIAnim = transform.Find("Equipped").GetComponent<Animator>();
        equipUI = transform.Find("Equipped").gameObject;
        itemBox = transform.Find("Bag/BagBG/Scroll View/Viewport/Content/Item").GetComponent<ItemBox>();
        itemBox.LinkComponent();
    }

    public void ShowInventoryUI() //ArrowButton에다가 인스펙터에서 온클릭 이벤트로 연결해놓음
    {
        inventoryUIAnim.Play("UI_BagSelected");
        equippedUIAnim.Play("UI_EquipNotSelected");
        inventoryUI.transform.SetAsLastSibling();
        equipUI.transform.SetAsFirstSibling();
    }


    public void InitInventoryUI(ItemType itemType)
    {
        gameObject.SetActive(true);

        List<InventoryItem> showItemList = UserData.Instance.GetItemsByType(itemType);

        inventoryGos.ForEach(x => Destroy(x));
        inventoryGos.Clear();

        itemBox.gameObject.SetActive(true);

        foreach (var item in showItemList)
        {
            ItemBox newBox = Instantiate(itemBox, itemBox.transform.parent);
            newBox.Init(item);
            inventoryGos.Add(newBox.gameObject);

            newBox.button.onClick.AddListener(() => OnClick(item));
        }
        itemBox.gameObject.SetActive(false);

        void OnClick(InventoryItem item)
        {
            ShowInventoryUI();
            ItemInfoUI.Instance.OnShowSelectedWeapon(item);
            EquipItem(item);
        }
    }

    private void OnEnable()
    {
        CameraLayerManager.Instance.OnUIEnable(0); //Default 레이어만 컬링마스크로 체크되도록 변경
        UIManager.Instance.ShowUI();
        GameManager.GameState = GameState.Menu;
        ButtonUI.Instance.currentMenu.text = "인벤토리";
        InitInventoryUI(ItemType.Weapon);
        MoneyUI.Instance.InitMoney(UserData.Instance.accountData.data.gold);
    }

    new protected void OnDisable()
    {
        if (ApplicationQuit)
            return;

        CameraLayerManager.Instance.OnUIDisable(6);
    }

    public void EquipItem(InventoryItem item)
    {
        var equippedKey = UserData.Instance.itemData.data.equipMap.FirstOrDefault(x => x.Value == item).Key;
        if (UserData.Instance.itemData.data.equipMap.ContainsKey(equippedKey))
        {
            UnequipItem(equippedKey);
            EquipUI.Instance.InitEquipUI();
        }
        else
        {
            int equipIndex = UserData.Instance.itemData.data.equipMap.Count;
            UserData.Instance.itemData.data.equipMap.Add(equipIndex + 1, item);
            EquipUI.Instance.InitEquipUI();
            //EquipUI.Instance.ShowEquipUI();
        }
    }

    public void UnequipItem(int unequipKey)
    {
        UserData.Instance.itemData.data.equipMap.Remove(unequipKey);
    }
}

