using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginScenario : MonoBehaviour
{
    public GameObject objBackgroundAnimation;
    public GameObject objExistBackground;
    public CanvasGroup LoginUI;

    void Start()
    {
        // �α��� UI Fade Out
        StartCoroutine(FadeUI(1f, 0f, LoginUI));
    }
    IEnumerator FadeUI(float duration, float targetAlpha, CanvasGroup ui)
    {
        float time = 0f;
        float currentAlpha = ui.alpha;
        while (time < duration)
        {
            time += Time.deltaTime;
            ui.alpha = Mathf.Lerp(currentAlpha, targetAlpha, time / duration);
            yield return null;
        }
        ui.alpha = targetAlpha;
        ui.interactable = false;

        // ��׶��� �ִϸ��̼� ����
        objExistBackground.SetActive(false);
        objBackgroundAnimation.SetActive(true);
        StartCoroutine(ToLobby());
    }

    IEnumerator ToLobby()
    {
        yield return new WaitForSecondsRealtime(1f);
        Utils.LoadScene("Loby");
    }
}
