using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SurveyResultManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultTitle;
    [SerializeField] private TextMeshProUGUI resultDetail;

    public void SetText(SurveyResponseData responseData)
    {
        Debug.Log($"responseData : {responseData.result}, {responseData.detailResult}");
        resultTitle.text = responseData.result;
        // ���赵�� ���� �ؽ�Ʈ ���� ����
        if (responseData.result.Equals("Moderate Risk")) { resultTitle.color = Color.yellow; }
        else if (responseData.result.Equals("Significant Risk")) { resultTitle.color = Color.red; }
        else { resultTitle.color = Color.black; }

        resultDetail.text = responseData.detailResult;
    }
}
