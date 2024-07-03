using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfoManager : MonoBehaviour
{
    public GameObject infoUI;
    private CanvasGroup canvasGroup;
    private int clickCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = infoUI.GetComponent<CanvasGroup>();
        infoUI.SetActive(false);
    }

    public void ShowInfo()
    {
        infoUI.SetActive(true);
        canvasGroup.alpha = 1;
        clickCount++;
        if (clickCount == 2) { 
            // �� �� �� Ŭ���ϸ� �������� ����.
        }
    }

    public void CloseInfo()
    {
        canvasGroup.alpha = 0;
        clickCount = 0;
        infoUI.SetActive(false);
    }
}
