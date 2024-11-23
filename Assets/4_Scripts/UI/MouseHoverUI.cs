using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHoverUI : MonoBehaviour, IPointerExitHandler, IPointerDownHandler, IPointerEnterHandler
{
    [Header("Scale Settings")]
    public float minScale = 1.0f;      // 기본 스케일
    public float maxScale = 1.2f;      // 호버 시 최대 스케일
    public float duration = 0.2f;        // 애니메이션 지속 시간

    private Coroutine coroutine;   // 현재 실행 중인 코루틴
    private bool isPointerDown = false;    // 현재 호버 상태

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isPointerDown)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);

            coroutine = StartCoroutine(PointerHoverAnimation(true));
        }
        isPointerDown = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isPointerDown)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);

            coroutine = StartCoroutine(PointerHoverAnimation(true));
        }
        isPointerDown = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isPointerDown)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);

            coroutine = StartCoroutine(PointerHoverAnimation(false));
        }
        isPointerDown = false;
    }

    IEnumerator PointerHoverAnimation(bool isEntering)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("RectTransform 컴포넌트를 찾을 수 없습니다.");
            yield break;
        }

        // 현재 스케일과 목표 스케일 설정
        float currentScale = rectTransform.localScale.x;
        float targetScale = isEntering ? maxScale : minScale;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float normalizedTime = elapsed / duration; // 0 ~ 1
            float easedTime = EaseInQuad(normalizedTime); // 이징 함수 적용

            float scale = Mathf.Lerp(currentScale, targetScale, easedTime);
            rectTransform.localScale = new Vector3(scale, scale, scale);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // 애니메이션 종료 후 정확한 스케일 설정
        rectTransform.localScale = new Vector3(targetScale, targetScale, targetScale);
        coroutine = null;
    }

    /// <summary>
    /// Quadratic Ease In 함수
    /// t: 0 ~ 1
    /// </summary>
    private float EaseInQuad(float t)
    {
        return t * t;
    }
}
