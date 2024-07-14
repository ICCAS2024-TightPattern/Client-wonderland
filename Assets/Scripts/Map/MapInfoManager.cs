using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class MapInfoManager : MonoBehaviour
{
    [SerializeField]
    private int theme;  // 0: carousel, 1: ferris_wheel, 2: roller_coaster

    // �ؽ�Ʈ
    [SerializeField]
    private TextMeshProUGUI textStageInfo;

    // �ؽ�Ʈ ������Ʈ
    [SerializeField]
    private GameObject objCorrectness;
    [SerializeField]
    private GameObject objStageInfo;
    [SerializeField]
    private GameObject objNoInfo;

    // ���� ���õ� ������
    [SerializeField]
    private Image[] spriteRenderer = new Image[3];
    [SerializeField]
    private Sprite yellowStar;

    void Start()
    {
        Debug.Log($"NoRecord: {Star.noRecord[theme]}, Correctness: {Star.correctness[theme]}");
        if (Star.noRecord[theme])
        {
            objCorrectness.SetActive(false);
            objStageInfo.SetActive(false);
            objNoInfo.SetActive(true);
        }
        else
        {
            objCorrectness.SetActive(true);
            objStageInfo.SetActive(true);
            objNoInfo.SetActive(false);
            textStageInfo.text = $"{Star.correctness[theme]}%";
            for (int i = theme * 3; i < theme * 3 + 3; i++)
            {
                if (Star.stageStar[i])
                {
                    spriteRenderer[i % 3].sprite = yellowStar;
                }
            }
        }
    }

}
