using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAnimation : MonoBehaviour
{
    public Sprite[] newSprite; // ���� ������ ��������Ʈ
    public AnimationClip[] newIdleAnimationClip; // ���� ������ idle �ִϸ��̼� Ŭ��

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private int index = 0;

    void Awake()
    {
        // ���� ������Ʈ�� SpriteRenderer�� Animator ������Ʈ�� �����ɴϴ�.
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        spriteRenderer.sprite = newSprite[index];
    }

    void OnEnable()
    {
        index = Random.Range(0, newSprite.Length);
        // SpriteRenderer�� sprite�� �� ��������Ʈ�� �����մϴ�.
        animator.SetInteger("Index", index);
        spriteRenderer.sprite = newSprite[index];
        Debug.Log($"Index: {index}, newSprite[index]: {newSprite[index]}");

        // SpriteRenderer�� Animator�� �����ϴ��� Ȯ���մϴ�.
        if (spriteRenderer != null && animator != null)
        {
            ChangeSpriteAndIdleAnimation();
        }
        else
        {
            Debug.LogError("SpriteRenderer or Animator component is missing on this game object.");
        }
    }

    private void ChangeSpriteAndIdleAnimation()
    {
        /*
        // ���� Animator Controller�� ������� Animator Override Controller�� �����մϴ�.
        AnimatorOverrideController overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);

        // "idle" ������ �ִϸ��̼� Ŭ���� �� Ŭ������ �����մϴ�.
        overrideController["Idle"] = newIdleAnimationClip[index];

        // Animator�� Runtime Animator Controller�� Override Controller�� �����մϴ�.
        animator.runtimeAnimatorController = overrideController;

        Debug.Log(newIdleAnimationClip[index]);
        */
    }
}
