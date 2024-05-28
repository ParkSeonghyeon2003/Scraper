using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private bool isLeft = true;
    private float rayLength = 0.6f;

    private void FixedUpdate()
    {
        // 움직이는 방향과 ray 방향 맞추기
        if (isLeft != (rayLength < 0)) rayLength *= -1;

        Debug.DrawRay(transform.position, transform.right * rayLength, Color.red);

        // Block에 닿으면 움직이는 방향 틀기
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, rayLength, LayerMask.GetMask("Block"));
        if (hit.collider != null) {
            isLeft = !isLeft;
        }

        // 움직임 처리
        transform.position = new Vector3(transform.position.x+(isLeft ? -1 : 1)*Time.deltaTime, transform.position.y, 0);
    }
}
