using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    private void Awake()
    {
        // 해상도 설정 (16:9, 1920x1080)
        int targetWidth = 1920;
        int targetHeight = 1080;
        Screen.SetResolution(targetWidth, targetHeight, true);

        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        float scaleHeight = ((float)Screen.width / Screen.height) / ((float)16 / 9);
        float scaleWidth = 1f / scaleHeight;
        if (scaleHeight < 1)
        {
            rect.height = scaleHeight;
            rect.y = (1f - scaleHeight) / 2f;
        }
        else
        {
            rect.width = scaleWidth;
            rect.x = (1f - scaleWidth) / 2f;
        }
        camera.rect = rect;
    }
}