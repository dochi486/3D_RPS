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


    internal void LinkComponent() //�η��۷��� ���� ���� ���ؼ� ���� ������Ʈ�� ��������ִ� �Լ�
    {
        //Awake�� ������ �� �Ǿ��� ������ ��� ����Ͽ� Awake��� ���
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

    public void SelectItem() //�ν����Ϳ��� ��ư ��Ŭ�� �̺�Ʈ�� ��������
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
