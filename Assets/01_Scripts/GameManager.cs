using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager Instance { get; set; }


    public string userName;

    public float health;
    public float maxHealth;

    public uint money;


    void Awake()
    {
        // �̱���
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(this.gameObject);
        }

        InitStatus();
        
    }

    private void InitStatus()
    {
        // �׽�Ʈ ������
        userName = "�ڼ���";
        maxHealth = 100.0f;
        health = maxHealth;
        money = 0;
    }
}
