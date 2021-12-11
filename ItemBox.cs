using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ItemBox : MonoBehaviour
{
    public Button button;
    public Image icon;
    public GameObject selectedState;
    public InventoryItem inventoryItem;
    public bool isSelected = false;


    internal void LinkComponent() //널레퍼런스 오류 방지 위해서 하위 오브젝트를 연결시켜주는 함수
    {
        //Awake가 실행이 안 되었을 만약의 경우 대비하여 Awake대신 사용
        if (icon == null)
            icon = transform.Find("Icon").GetComponent<Image>();
        if (button == null)
            button = GetComponent<Button>();
        if (selectedState == null)
            selectedState = transform.Find("SelectedState")?.gameObject;
    }

    internal void Init(InventoryItem item)
    {
        if (item != null)
        {
            inventoryItem = item;
            icon.enabled = true;

            icon.sprite = Resources.Load<Sprite>($"Weapon/{item.ItemData.Name}");
        }
        else
        {
            icon.sprite = null;
            icon.enabled = false;
        }
    }

    public void SelectItem() //인스펙터에서 버튼 온클릭 이벤트로 연결해줌
    {
        if (isSelected)
        {
            transform.Find("BG").gameObject.SetActive(true);
            selectedState.SetActive(false);
            isSelected = false;
        }
        else
        {
            transform.Find("BG").gameObject.SetActive(false);
            selectedState.SetActive(true);
            isSelected = true;
        }
    }
}
