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
        // 싱글톤
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
        // 테스트 데이터
        userName = "박성현";
        maxHealth = 100.0f;
        health = maxHealth;
        money = 0;
    }
}
