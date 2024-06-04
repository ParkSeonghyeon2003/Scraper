using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text userName;
    public Slider hpSlider;
    public Text hpPercentText;
    public Text moneyText;

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

    void LateUpdate()
    {
        HpBarUpdate();
        MoneyUpdate();
    }

    private void HpBarUpdate()
    {
        float curHp = GameManager.Instance.health;
        float maxHp = GameManager.Instance.maxHealth;
        hpSlider.value = curHp / maxHp;
        hpPercentText.text = string.Format("{0:F0}%", GameManager.Instance.health);
    }

    private void MoneyUpdate()
    {
        moneyText.text = string.Format("{0:D0}", GameManager.Instance.money);
    }
}
