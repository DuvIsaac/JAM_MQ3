using UnityEngine;
using UnityEngine.UI; // UI 관련 기능
using TMPro;          // TextMeshPro 사용 시 필요

public class MyUIController : MonoBehaviour
{
    public Button myButton;
    public TMP_Text myText;
    public string sText;

    void Start()
    {
        // 버튼 클릭 시 ChangeText 함수 실행
        myButton.onClick.AddListener(ChangeText);
    }

    void ChangeText()
    {
        myText.text = sText;
    }
}
