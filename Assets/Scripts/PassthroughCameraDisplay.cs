using UnityEngine;
using PassthroughCameraSamples;
using System.IO;
using System.Linq;

public class PassthroughCameraDisplay : MonoBehaviour
{
    public WebCamTextureManager WebCamManager;
    public Renderer QuadRenderer;
    private Texture2D picture;

    public OVRHand rightHand; // 오른손 OVRHand 컴포넌트 할당
    private bool isPinching = false; // 중복 저장 방지

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (WebCamManager.WebCamTexture != null)
        {
            QuadRenderer.material.mainTexture = WebCamManager.WebCamTexture;

            // float pinchStrength = rightHand.GetFingerPinchStrength(OVRHand.HandFinger.Index);

            // if (pinchStrength > 0.8f && !isPinching)
            // {
            //     SaveCurrentFrame();
            //     isPinching = true;
            // }
            // else if (pinchStrength < 0.2f)
            // {
            //     // 손가락을 떼면 다시 저장 가능
            //     isPinching = false;
            // }
        }
    }

    void SaveCurrentFrame()
    {
        WebCamTexture camTexture = WebCamManager.WebCamTexture;
        Color32[] pixels = camTexture.GetPixels32();

        Texture2D tex = new Texture2D(camTexture.width, camTexture.height, TextureFormat.RGBA32, false);
        tex.SetPixels32(pixels);
        tex.Apply();

        // 다음 번호 구하기
        // int nextNumber = GetNextCaptureNumber();

        // PNG 저장
        // string pngPath = Path.Combine(Application.persistentDataPath, $"capture{nextNumber}.png");
        // File.WriteAllBytes(pngPath, tex.EncodeToPNG());

        // JPG 저장
        // string jpgPath = Path.Combine(Application.persistentDataPath, $"capture{nextNumber}.jpg");
        // File.WriteAllBytes(jpgPath, tex.EncodeToJPG(90));

        // Debug.Log($"이미지 저장 완료: {pngPath}");
        // Debug.Log($"imgpath: {jpgPath}");
    }

    int GetNextCaptureNumber()
    {
        string path = Application.persistentDataPath;
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        // capture*.png와 capture*.jpg 파일명에서 숫자만 추출
        var files = Directory.GetFiles(path, "capture*.*")
            .Select(f => Path.GetFileNameWithoutExtension(f))
            .Where(name => name.StartsWith("capture"))
            .Select(name =>
            {
                string numPart = name.Substring("capture".Length);
                int num;
                return int.TryParse(numPart, out num) ? num : 0;
            })
            .ToList();

        return (files.Count > 0) ? files.Max() + 1 : 1;
    }
}
