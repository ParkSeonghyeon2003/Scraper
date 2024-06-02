using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerStay2D (Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("Enemy"))
            return;
        GameManager.Instance.health -= Time.deltaTime * 10;

        if (GameManager.Instance.health == 0) {
            Time.timeScale = 0.0f;
        }
    }
}
