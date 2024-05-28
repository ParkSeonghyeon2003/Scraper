using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text userName;

    public static HUD Instance { get; set; }

    private void Awake()
    {
        // ΩÃ±€≈Ê
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        userName.text = GameManager.Instance.userName;
    }
}
