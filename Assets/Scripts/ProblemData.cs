using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class ProblemData : MonoBehaviour
{
    public static ProblemData instance;
    public QuestionData[][] problemData = new QuestionData[2][];
    public QuestionData problem3Data;
    public List<Sprite> spriteFromServer;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� �� ��ü�� �ı����� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnLoadStageData(string theme)
    {
        string getProblemUrl;
        getProblemUrl = $"https://worderland.kro.kr/api/question/{theme}?stage=1";
        StartCoroutine(GetRequest(getProblemUrl, 1));
        getProblemUrl = $"https://worderland.kro.kr/api/question/{theme}?stage=2";
        StartCoroutine(GetRequest(getProblemUrl, 2));
        getProblemUrl = $"https://worderland.kro.kr/api/question/{theme}?stage=3";
        StartCoroutine(GetRequestStage3(getProblemUrl));
    }

    /// <summary>
    /// Get Problem Set from server.
    /// </summary>
    /// <param name="uri"></param>
    /// <returns></returns>
    IEnumerator GetRequest(string uri, int stage)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            // ��û ������
            yield return request.SendWebRequest();

            // ���� ó��
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Loading.OnError();
                Debug.LogError(request.error);
            }
            else
            {
                // ���� �ޱ�
                string jsonResponse = request.downloadHandler.text;
                Debug.Log("Response: " + jsonResponse);

                // JSON �Ľ�
                QuestionResponseData responseData = JsonUtility.FromJson<QuestionResponseData>(jsonResponse);

                // ������ ����
                if (responseData.success)
                {
                    problemData[stage - 1] = responseData.data.Clone() as QuestionData[];
                    Debug.Log($"Response: {problemData[stage - 1]}");
                    // 2 �������� �������, �̸� �̹��� �ٿ�ε�.
                    if (stage == 2 && SceneTheme.theme != "carousel")
                    {
                        CheckIsImageProblem();
                    }
                    else
                    {

                        Loading.sceneLoadedCount++;
                    }
                }
                else
                {
                    Loading.OnError();
                    Debug.LogError("Request failed with message: " + responseData.message);
                }
            }
        }
    }
    IEnumerator GetRequestStage3(string uri)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            // ��û ������
            yield return request.SendWebRequest();

            // ���� ó��
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Loading.OnError();
                Debug.LogError(request.error);
            }
            else
            {
                // ���� �ޱ�
                string jsonResponse = request.downloadHandler.text;
                Debug.Log("Response: " + jsonResponse);

                // JSON �Ľ�
                Question3ResponseData responseData = JsonUtility.FromJson<Question3ResponseData>(jsonResponse);

                // ������ ����
                if (responseData.success)
                {
                    problem3Data = responseData.data;
                    Loading.sceneLoadedCount++;

                    // �� ���� �ƴ��� ���� �ΰ�
                    /*
                    int questionId = problemData.questionId;
                    string content = problemData.content;
                    Debug.Log("Question ID: " + questionId);
                    Debug.Log("Content: " + content);
                    */
                }
                else
                {
                    Loading.OnError();
                    Debug.LogError("Request failed with message: " + responseData.message);
                }
            }
        }
    }


    /// <summary>
    /// �̹��� url���� �̹����� �ٿ�ε� �޾� Sprite�� ���
    /// </summary>
    /// <param name="url">�̹��� url</param>
    /// <returns></returns>
    IEnumerator DownloadImage(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            spriteFromServer.Add(sprite);
            Loading.sceneLoadedCount++;
        }
    }


    private void CheckIsImageProblem()
    {
        foreach (var content in problemData[1])
        {
            if (content.content.StartsWith("http"))
            {
                StartCoroutine(DownloadImage(content.content));
            }
        }
    }
}
