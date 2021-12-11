using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : SingletonMonoBehaviour<LoadingUI>
{
    Slider loadingProgress;
    Text randomTip;
    public StringTest test;

    new private void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(transform.root);
        loadingProgress = GetComponentInChildren<Slider>();
        loadingProgress.maxValue = 100;
        randomTip = GetComponentInChildren<Text>();
    }

    public int minFrame = 40;
    internal void LoadUI(AsyncOperation result)
    {
        gameObject.SetActive(true);
        randomTip.text = test.dataArray[Random.Range(1, test.dataArray.Length)].Text;
        print(randomTip.text);
        StartCoroutine(LoadUICo(result));
    }

    private IEnumerator LoadUICo(AsyncOperation result)
    {
        for (int i = 0; i < minFrame || result.isDone == false; i++)
        {
            float percentFloat = (float)i / minFrame;

            if (percentFloat > result.progress)
                percentFloat = result.progress;

            loadingProgress.value = percentFloat * 100;

            yield return null;
        }
        loadingProgress.value = 100;
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.DOFade(0, 0.5f).OnComplete(() => gameObject.SetActive(false));
    }
}
