using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Chest : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // �÷��̾ ������..
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        animator.SetBool("Open", true);
        StartCoroutine(ChangeLightColor());
        Destroy(gameObject, 5.0f);
    }

    // ������ �Һ��� �ʷϻ����� ����
    IEnumerator ChangeLightColor()
    {
        yield return new WaitForSeconds(0.5f);
        Light2D[] lights = GetComponentsInChildren<Light2D>();

        Color green;
        ColorUtility.TryParseHtmlString("#2FFE4F", out green);
        lights[0].color = green;
        lights[1].color = green;
    }
}
