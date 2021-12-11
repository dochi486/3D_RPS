using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            DialogueUI.Instance.ShowDialogue("레드훅", "달 기지 채굴 로봇이 이상해. 가서 살펴봐줄래? 만약에 대비해서 무기 장비하는 걸 잊지마! " +
                "\n TAB키를 눌러서 인벤토리를 열고 가지고 있는 무기를 장착해봐.");
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
