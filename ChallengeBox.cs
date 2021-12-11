using UnityEngine;
using UnityEngine.UI;

public class ChallengeBox : MonoBehaviour
{
    public Slider slider;
    public Text title;

    public void LinkComponent()
    {
        if (slider == null)
            slider = GetComponentInChildren<Slider>(true);
        if (title == null)
            title = GetComponentInChildren<Text>(true);
    }
}
