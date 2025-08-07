using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public Button ButtonNew;
    public Button ButtonMy;
    public Button ButtonRecord;
    
    public Button ButtonSetting;
    public GameObject panelToShow;

    void Start()
    {
        // 버튼 클릭 시 실행할 함수 연결
        ButtonNew.onClick.AddListener(() => LoadScene("SceneNew"));
        ButtonMy.onClick.AddListener(() => LoadScene("SceneMy"));
        ButtonRecord.onClick.AddListener(() => LoadScene("SceneRecord"));

        ButtonSetting.onClick.AddListener(TogglePanel);
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void TogglePanel()
    {
        panelToShow.SetActive(!panelToShow.activeSelf);
    }
}
