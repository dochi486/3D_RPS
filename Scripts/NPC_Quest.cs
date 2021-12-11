using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            DialogueUI.Instance.ShowDialogue("������", "�� ���� ä�� �κ��� �̻���. ���� ������ٷ�? ���࿡ ����ؼ� ���� ����ϴ� �� ������! " +
                "\n TABŰ�� ������ �κ��丮�� ���� ������ �ִ� ���⸦ �����غ�.");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            //UI.Instance.CloseUI();
            DialogueUI.Instance.CloseDialogue();
    }
}

public class NPC_Quest : NPC
{

}
