using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [Header("각 화면의 그룹 오브젝트 (메인/맵/상점/가방 순서)")]
    [SerializeField] private GameObject[] modelGroup;
    [SerializeField] private GameObject[] UIGroup;

    private MainSceneGroupName currentGroup = MainSceneGroupName.Main;

    // Start is called before the first frame update
    void Start()
    {
        // 메인만 켜기
        if (modelGroup[0] == null || UIGroup[0] == null)
        {
            Debug.LogError("컨트롤러에 오브젝트 그룹을 연결해주세요.");
            return;
        }
        modelGroup[0].SetActive(true);
        UIGroup[0].SetActive(true);
        for (int i = 1; i < modelGroup.Length; i++)
        {
            if (modelGroup[i] != null)
                modelGroup[i].SetActive(false);
            if (UIGroup[i] != null)
                UIGroup[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGroup(int group)
    {
        currentGroup = (MainSceneGroupName)group;
        for (int i = 0; i < modelGroup.Length; i++)
        {
            if (modelGroup[i] == null) 
                continue;
            modelGroup[i].SetActive(false);
            if (group == i)
                modelGroup[i].SetActive(true);
        }
        for (int i = 0; i < UIGroup.Length; i++)
        {
            if (UIGroup[i] == null)
                continue;
            UIGroup[i].SetActive(false);
            if (group == i)
                UIGroup[i].SetActive(true);
        }
    }
}
