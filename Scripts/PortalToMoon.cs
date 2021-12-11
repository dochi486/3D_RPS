using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToMoon : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == false)
            return;

        print(other.name + "��Ż �۵�");


        var result = SceneManager.LoadSceneAsync(sceneName);
        //Async �񵿱� ���� ���� �� �𸣰ڴ�
        LoadingUI.Instance.LoadUI(result);


    }
}
