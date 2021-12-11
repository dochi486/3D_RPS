using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoUI : SingletonMonoBehaviour<ItemInfoUI>
{
    //FireRate 발사 속도
    Text weaponName;
    Text weaponDamage;
    Text weaponAccuracy;
    Text weaponFireRate;
    Text weaponReloadSpeed;
    Text weaponMagazineSize;
    CanvasGroup canvasGroup;

    new protected void Awake()
    {
        base.Awake();
        weaponName = transform.Find("Name").GetComponent<Text>();
        weaponDamage = transform.Find("StatusInfo/Damage").GetComponent<Text>();
        weaponAccuracy = transform.Find("StatusInfo/Accuracy").GetComponent<Text>();
        weaponFireRate = transform.Find("StatusInfo/FireRate").GetComponent<Text>();
        weaponReloadSpeed = transform.Find("StatusInfo/ReloadSpeed").GetComponent<Text>();
        weaponMagazineSize = transform.Find("StatusInfo/MagazineSize").GetComponent<Text>();
    }

    public void OnShowSelectedWeapon(InventoryItem item)
    {
        weaponName.text = item.ItemData.Name;
        weaponDamage.text = item.ItemData.Damage.ToString();
        weaponAccuracy.text = item.ItemData.Accuracy.ToString();
        weaponFireRate.text = item.ItemData.Firerate.ToString();
        weaponReloadSpeed.text = item.ItemData.Reloadspeed.ToString();
        weaponMagazineSize.text = item.ItemData.Magazinesize.ToString();
        transform.SetAsLastSibling();
    }

    public void ShowItemInfoUI() //아이템박스 오브젝트의 인스펙터에서 event trigger pointerUp이벤트로 연결해줌
    {
        canvasGroup.DOFade(1, 0.5f).SetUpdate(true)
         .OnComplete(() =>
         {
             canvasGroup.gameObject.SetActive(true);
         });
    }
}
