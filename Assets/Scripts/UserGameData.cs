[System.Serializable]
public class UserGameData
{
    public int heart;       // ��ȭ
    public int equipHead;   // �������� ���ǰ

    public void Reset()
    {
        heart = 0;
        equipHead = 0;      // �ƹ��͵� ���� �� �� ����
    }
}
