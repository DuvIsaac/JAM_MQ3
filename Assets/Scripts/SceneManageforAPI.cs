using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManageforAPI : MonoBehaviour
{
    public Button ButtonCamera;

    void Start()
    {
        // 버튼 클릭 시 실행할 함수 연결
        ButtonCamera.onClick.AddListener(() => LoadScene("SceneCameraAPI"));
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
