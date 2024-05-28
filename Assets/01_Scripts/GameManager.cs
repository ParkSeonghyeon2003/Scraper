using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �̱���
    private static GameManager instance = null;

    public string userName;

    private float health;
    private float maxHealth;

    private int wallet;

    // �̱���
    public static GameManager Instance
    {
        get
        {
            if (instance == null) {
                instance = null;
            }
            return instance;
        }
    }

    void Awake()
    {
        // �̱���
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(this.gameObject);
        }
        
        // �׽�Ʈ ������
        userName = "�ڼ���";
        maxHealth = 100.0f;
        health = maxHealth;
        wallet = 0;
    }
}
