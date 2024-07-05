using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemController : MonoBehaviour
{
    //private int problemType = 1;    //���� ���� (1: ������, 2: �ְ���(OCR))

    [SerializeField]
    private GameObject[] choiceButton = new GameObject[4];  // ���� ��ư
    [SerializeField]
    private GameObject[] animals = new GameObject[4];       // �ش� ����

    private TimerController timerController;

    private void Start()
    {
        timerController = GameObject.Find("Gauge Front").GetComponent<TimerController>();
    }

    /// <summary>
    /// ������ ������ ���� ���� �Լ�
    /// </summary>
    /// <param name="chosenNumber"></param>
    public void Choice(int chosenNumber)
    {
        timerController.onTimer = false;
        // ���� ���� ����

        // ���� �� �۾�
        for (int i = 0; i < 4; i++)
        {
            if (i != chosenNumber)
            {
                choiceButton[i].SetActive(false);
                animals[i].SetActive(false);
            }
        }
        // ���� �� ��ü�� 3�� ���� �������� �˷��ִ� �ִϸ��̼�
        StartCoroutine(SetNewProblem(chosenNumber));
    }

    public IEnumerator SetNewProblem(int chosenNumber)
    {
        yield return new WaitForSecondsRealtime(3f);
        choiceButton[chosenNumber].SetActive(false);
        animals[chosenNumber].SetActive(false);
        timerController.NewProblemTimer(20f);
    }
}
