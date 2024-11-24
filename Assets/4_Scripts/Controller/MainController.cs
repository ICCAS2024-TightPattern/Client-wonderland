using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [Header("���� Ȱ�� ������Ʈ")]
    public GameObject[] enableInMain;

    [Header("�� Ȱ�� ������Ʈ")]
    public GameObject[] enableInMap;

    [Header("���� Ȱ�� ������Ʈ")]
    public GameObject[] enableInStore;

    [Header("���� Ȱ�� ������Ʈ")]
    public GameObject[] enableInBackpack;

    private MainSceneGroupName currentGroup = MainSceneGroupName.Main;

    // Start is called before the first frame update
    void Start()
    {
        // ���θ� �ѱ�
        foreach (GameObject obj in enableInMain)
            obj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGroup(int group)
    {
        // ���� �����ִ� ���� �� ������Ʈ�� ����,
        switch (currentGroup)
        {
            case MainSceneGroupName.Main:
                foreach (GameObject obj in enableInMain)
                    obj.SetActive(false);
                break;
            case MainSceneGroupName.Map:
                foreach (GameObject obj in enableInMap)
                    obj.SetActive(false);
                break;
            case MainSceneGroupName.Store:
                foreach (GameObject obj in enableInStore)
                    obj.SetActive(false);
                break;
            case MainSceneGroupName.Backpack:
                foreach (GameObject obj in enableInBackpack)
                    obj.SetActive(false);
                break;
        }

        currentGroup = (MainSceneGroupName)group;

        // �׸��� �Ѿߵ� �͵� Ű��
        switch (currentGroup)
        {
            case MainSceneGroupName.Main:
                foreach (GameObject obj in enableInMain)
                    obj.SetActive(true);
                break;
            case MainSceneGroupName.Map:
                foreach (GameObject obj in enableInMap)
                    obj.SetActive(true);
                break;
            case MainSceneGroupName.Store:
                foreach (GameObject obj in enableInStore)
                    obj.SetActive(true);
                break;
            case MainSceneGroupName.Backpack:
                foreach (GameObject obj in enableInBackpack)
                    obj.SetActive(true);
                break;
        }
    }
}
