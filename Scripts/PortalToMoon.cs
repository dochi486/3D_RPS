using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToMoon : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == false)
            return;

        print(other.name + "포탈 작동");


        var result = SceneManager.LoadSceneAsync(sceneName);
        //Async 비동기 뭔지 아직 잘 모르겠다
        LoadingUI.Instance.LoadUI(result);


    }
}
