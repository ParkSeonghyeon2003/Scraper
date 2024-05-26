using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private bool isLeft = true;
    private float rayLength = 0.6f;

    private void FixedUpdate()
    {
        if (isLeft != (rayLength < 0)) rayLength *= -1;
        Debug.DrawRay(transform.position, transform.right * rayLength, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, rayLength, LayerMask.GetMask("Block"));
        if (hit.collider != null) {
            isLeft = !isLeft;
        }
        transform.position = new Vector3(transform.position.x+(isLeft ? -1 : 1)*Time.deltaTime, transform.position.y, 0);
    }
}
