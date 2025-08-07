using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoBack2Main : MonoBehaviour
{
    public Button Button;

    void Start()
    {
        // 버튼 클릭 시 실행할 함수 연결
        Button.onClick.AddListener(() => LoadScene("SceneMain"));
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
