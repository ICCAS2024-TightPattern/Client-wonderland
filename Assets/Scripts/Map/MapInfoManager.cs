using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class StageData
{
    public string userId;
    public string theme;
    public int stage;
    public int correctAnswers;
}

[System.Serializable]
public class StageResponseData
{
    public int status;
    public bool success;
    public string message;
    public StageData[] data;
}


public class MapInfoManager : MonoBehaviour
{
    [SerializeField]
    private string userId;
    [SerializeField]
    private string theme;

    // �ؽ�Ʈ
    [SerializeField]
    private TextMeshProUGUI textCorrectness;
    [SerializeField]
    private TextMeshProUGUI textStageInfo;
    [SerializeField]
    private TextMeshProUGUI textNoInfo;

    // �ؽ�Ʈ ������Ʈ
    [SerializeField]
    private GameObject objCorrectness;
    [SerializeField]
    private GameObject objStageInfo;
    [SerializeField]
    private GameObject objNoInfo;

    // ���� ���õ� ������
    [SerializeField]
    private SpriteRenderer[] spriteRenderer = new SpriteRenderer[3];
    [SerializeField]
    private Sprite yellowStar;

    private StageData[] stageData;
    private string url;

    void Start()
    {
        url = $"https://worderland.kro.kr/api/result/{userId}?theme={theme}";
        StartCoroutine(GetRequest(url));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            // ��û ������
            yield return request.SendWebRequest();

            // ���� ó��
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                // ���� �ޱ�
                string jsonResponse = request.downloadHandler.text;
                Debug.Log("Response: " + jsonResponse);

                // JSON �Ľ�
                StageResponseData responseData = JsonUtility.FromJson<StageResponseData>(jsonResponse);

                // ������ ����
                if (responseData.success)
                {
                    if (responseData.data == null)
                    {
                        // �� �迭�̸� ���� ���� ���� ��
                        // ���� "��� ����"���� ���
                        objCorrectness.SetActive(false);
                        objStageInfo.SetActive(false);
                        objNoInfo.SetActive(true);
                        textNoInfo.text = "��� ����";
                    }
                    else
                    {
                        stageData = responseData.data.Clone() as StageData[];
                        foreach (var userData in responseData.data)
                        {
                            Debug.Log("User ID: " + userData.userId);
                            Debug.Log("Theme: " + userData.theme);
                            Debug.Log("Stage: " + userData.stage);
                            Debug.Log("Correct Answers: " + userData.correctAnswers);
                        }
                        int correct = 0;
                        for(int i = 0; i < stageData.Length - 1; i++)
                        {
                            correct += stageData[i].correctAnswers;
                        }
                        // UI ������Ʈ
                        objCorrectness.SetActive(true);
                        objStageInfo.SetActive(true);
                        objNoInfo.SetActive(false);

                        float correctness = Mathf.Floor(correct / 11 * 100);
                        textCorrectness.text = "�����";
                        textStageInfo.text = $"{correctness}%";
                        // �� UI ������Ʈ
                        if (correctness > 0f)
                            spriteRenderer[0].sprite = yellowStar;
                        if (correctness > 50f)
                            spriteRenderer[1].sprite = yellowStar;
                        if (correct == 11)
                            spriteRenderer[2].sprite = yellowStar;
                    }
                }
                else
                {
                    Debug.LogError("Request failed with message: " + responseData.message);
                }
            }
        }
    }
}