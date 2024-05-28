using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private Text userName;

    private void Awake()
    {
        userName = GetComponentInChildren<Text>();
        userName.text = GameManager.Instance.userName;
    }
}
