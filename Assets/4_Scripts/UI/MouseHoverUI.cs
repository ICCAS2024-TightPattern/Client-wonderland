using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Scale Settings")]
    public float minScale = 1.0f;      // �⺻ ������
    public float maxScale = 1.2f;      // ȣ�� �� �ִ� ������
    public float duration = 0.2f;        // �ִϸ��̼� ���� �ð�

    private Coroutine hoverCoroutine;   // ���� ���� ���� �ڷ�ƾ
    private bool isHovered = false;    // ���� ȣ�� ����

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isHovered)
        {
            if (hoverCoroutine != null)
                StopCoroutine(hoverCoroutine);

            hoverCoroutine = StartCoroutine(PointerHoverAnimation(true));
        }
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isHovered)
        {
            if (hoverCoroutine != null)
                StopCoroutine(hoverCoroutine);

            hoverCoroutine = StartCoroutine(PointerHoverAnimation(false));
        }
        isHovered = false;
    }

    IEnumerator PointerHoverAnimation(bool isEntering)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("RectTransform ������Ʈ�� ã�� �� �����ϴ�.");
            yield break;
        }

        // ���� �����ϰ� ��ǥ ������ ����
        float currentScale = rectTransform.localScale.x;
        float targetScale = isEntering ? maxScale : minScale;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float normalizedTime = elapsed / duration; // 0 ~ 1
            float easedTime = EaseInQuad(normalizedTime); // ��¡ �Լ� ����

            float scale = Mathf.Lerp(currentScale, targetScale, easedTime);
            rectTransform.localScale = new Vector3(scale, scale, scale);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // �ִϸ��̼� ���� �� ��Ȯ�� ������ ����
        rectTransform.localScale = new Vector3(targetScale, targetScale, targetScale);
        hoverCoroutine = null;
    }

    /// <summary>
    /// Quadratic Ease In �Լ�
    /// t: 0 ~ 1
    /// </summary>
    private float EaseInQuad(float t)
    {
        return t * t;
    }
}
