using UnityEngine;

public class FixedPosition : MonoBehaviour
{
    private Vector3 initialPosition;
    private Animator animator;
    private OpenSceneHandler hadlerScript;

    void Start()
    {
        // �ʱ� ��ġ ����
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
        hadlerScript = GetComponent<OpenSceneHandler>();
    }

    void LateUpdate()
    {
        // y ���� �ִϸ��̼�ȭ�ϰ� x�� z ���� ����
        Vector3 animatedPosition = transform.position;
        transform.position = new Vector3(initialPosition.x, animatedPosition.y, initialPosition.z);

    }
}
