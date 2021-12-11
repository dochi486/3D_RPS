using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TextBox : MonoBehaviour
{
    public Button button;
    public Text text;
    public GameObject selectedGo;
    public Image icon;

    public void LinkComponent()
    {
        if (button == null)
            button = GetComponent<Button>();

        if (text == null)
            text = GetComponentInChildren<Text>();

        if (icon == null)
            icon = GetComponentInChildren<Image>();

        if (selectedGo == null)
            selectedGo = transform.Find("SelectedState")?.gameObject;
    }
}
