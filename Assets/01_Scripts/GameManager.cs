using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ½Ì±ÛÅæ
    private static GameManager instance = null;

    public string userName;

    private float health;
    private float maxHealth;

    private int wallet;

    // ½Ì±ÛÅæ
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
        // ½Ì±ÛÅæ
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(this.gameObject);
        }
        
        // Å×½ºÆ® µ¥ÀÌÅÍ
        userName = "¹Ú¼ºÇö";
        maxHealth = 100.0f;
        health = maxHealth;
        wallet = 0;
    }
}
