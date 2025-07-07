using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int coins = 0;
    public Text coinsText;

    void Start() { UpdateCoinsUI(); }

    public void OnBallBounce() {
        // Optional: Add feedback here
    }

    public void OnSpeedBoost() {
        // Optional: Add feedback here
    }

    public void AddCoins(int amount) {
        coins += amount;
        UpdateCoinsUI();
    }

    void UpdateCoinsUI() {
        if (coinsText) coinsText.text = $"Coins: {coins}";
    }
}
