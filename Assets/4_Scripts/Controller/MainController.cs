using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [Header("메인 활성 오브젝트")]
    public GameObject[] enableInMain;

    [Header("맵 활성 오브젝트")]
    public GameObject[] enableInMap;

    [Header("상점 활성 오브젝트")]
    public GameObject[] enableInStore;

    [Header("가방 활성 오브젝트")]
    public GameObject[] enableInBackpack;

    private MainSceneGroupName currentGroup = MainSceneGroupName.Main;

    // Start is called before the first frame update
    void Start()
    {
        // 메인만 켜기
        foreach (GameObject obj in enableInMain)
            obj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGroup(int group)
    {
        // 먼저 켜져있던 이전 씬 오브젝트들 끄고,
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

        // 그리고 켜야될 것들 키기
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
