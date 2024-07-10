using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class LoadItems : MonoBehaviour
{
    // ���� ���������� �������� �ϳ��� ���� ������ �߰��� ���� �ʿ�.
    //public GameObject[] items;
    public GameObject soldOut;

    void Start()
    {
        CheckSoldOut();
    }

    public void CheckSoldOut()
    {
        Debug.Log($"hasItem: {BackendGameData.Instance.UserGameData.hasItem}");
        if (BackendGameData.Instance.UserGameData.hasItem)
        {
            soldOut.SetActive(true);
        }
    }
}
