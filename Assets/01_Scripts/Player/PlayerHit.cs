using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D collider)  // Stay -> Enter 
    {
        if (!collider.gameObject.CompareTag("Enemy"))
            return;
        //GetHit(collider.gameObject.GetComponent<EnemyMove>().weaponDamage);
    }

    public void GetHit(float damage)
    {
        GameManager.Instance.health -= damage;

        if (GameManager.Instance.health <= 0)
        {
            Time.timeScale = 0.0f;
            // ��Ȱ �̺�Ʈ, ���� �й� �̺�Ʈ 
        }
    }
}
