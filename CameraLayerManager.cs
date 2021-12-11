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
    //�޴� UI�� �������� �� �ø� ����ũ���� Player, NPC ����
    public void OnUIEnable(int layerIndex)
    {
        mainCamera.cullingMask = 1 << layerIndex;
        //��Ʈ�����ڷ� ���̾� �����ؼ� ����Ʈ ���̾ �������ϱ�
        //mainCamera.cullingMask = ~(1 << layerIndex); //layerIndex�� ���� �� �׸���                                         
    }

    internal void OnUIDisable(int layerIndex)
    {
        mainCamera.cullingMask = ~(1 << layerIndex);
    }
}
