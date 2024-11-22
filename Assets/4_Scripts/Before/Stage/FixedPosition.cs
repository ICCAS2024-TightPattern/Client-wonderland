using UnityEngine;

public class FixedPosition : MonoBehaviour
{
    [SerializeField]
    private float xPosition;
    private Animator animator;
    private OpenSceneHandler hadlerScript;

    void Start()
    {
        // �ʱ� ��ġ ����
        animator = GetComponent<Animator>();
        hadlerScript = GetComponent<OpenSceneHandler>();
    }

    void LateUpdate()
    {
        // y ���� �ִϸ��̼�ȭ�ϰ� x�� z ���� ����
        Vector3 animatedPosition = transform.position;
        transform.position = new Vector3(xPosition, animatedPosition.y, 0f);

    }
}
