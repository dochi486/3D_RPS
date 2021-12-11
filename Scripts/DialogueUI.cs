using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : SingletonMonoBehaviour<DialogueUI>
{

    CanvasGroup canvasGroup;
    Text dialogueText;
    Text npcName;

    // Start is called before the first frame update
    new private void Awake()
    {
        base.Awake();
        canvasGroup = GetComponent<CanvasGroup>();
        dialogueText = GetComponentInChildren<Text>();
        npcName = transform.Find("Name/Text").GetComponent<Text>();
    }

    public void ShowDialogue(string name, string text)
    {
        gameObject.SetActive(true);
        npcName.text = name;
        dialogueText.text = text;
        canvasGroup.DOFade(1, 1); //�ð� �� ���� �ʿ�
    }

    public void CloseDialogue()
    {
        canvasGroup.DOFade(0, 0.5f); //DoFade.SetDelay ���� �� �ٽ� ���� ����
        gameObject.SetActive(false);
    }
}
