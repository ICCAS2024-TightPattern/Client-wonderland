using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public bool onTimer = true;     // Ÿ�̸� on/off

    public GameObject timer;        // "Gauge Front" : Ÿ�̸� ��
    public float duration;          // Ÿ�̸� �ð�
    public TextMeshProUGUI text;    // ���� �ð� ����ϴ� �ؽ�Ʈ

    public int integerTimer = 20;

    private float elapsedTime;      // ����ð�
    private Vector3 initialScale;   // �ʱ� Ÿ�̸� �� ���� ���� �����

    // Start is called before the first frame update
    void Start()
    {
        if (timer == null)
        {
            timer = this.gameObject;
        }
        elapsedTime = 0f;
        initialScale = timer.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (onTimer)
        {
            if (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float newWidth = Mathf.Lerp(initialScale.x, 0, elapsedTime / duration);
                timer.transform.localScale = new Vector3(newWidth, initialScale.y, initialScale.z);
                text.text = $"{Mathf.Ceil(duration - elapsedTime)}��";
                integerTimer = (int)Mathf.Ceil(duration - elapsedTime);
            }
        }
    }

    /// <summary>
    /// ���ο� ���� �ð� ���
    /// </summary>
    public void NewProblemTimer(float duration)
    {
        this.duration = duration;
        elapsedTime = 0f;
        timer.transform.localScale = initialScale;
        text.text = $"{Mathf.Ceil(duration - elapsedTime)}��";
        onTimer = true;
    }
}
