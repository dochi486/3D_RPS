using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLayerManager : SingletonMonoBehaviour<CameraLayerManager>
{
    Camera mainCamera;

    new protected void Awake()
    {
        base.Awake();
        mainCamera = GetComponent<Camera>();
    }
    //메뉴 UI가 켜져있을 때 컬링 마스크에서 Player, NPC 빼기
    public void OnUIEnable(int layerIndex)
    {
        mainCamera.cullingMask = 1 << layerIndex;
        //비트연산자로 레이어 연산해서 디폴트 레이어만 렌더링하기
        //mainCamera.cullingMask = ~(1 << layerIndex); //layerIndex만 빼고 다 그리기                                         
    }

    internal void OnUIDisable(int layerIndex)
    {
        mainCamera.cullingMask = ~(1 << layerIndex);
    }
}
