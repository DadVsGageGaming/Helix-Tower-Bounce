using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameManager gameManager;
    public BallSkinDatabase ballDatabase;
    public Transform shopPanel;
    public GameObject shopItemPrefab;
    public BallSkinSelector skinSelector;

    void Start()
    {
        RefreshShop();
    }

    public void RefreshShop()
    {
        foreach (Transform t in shopPanel) Destroy(t.gameObject);
        foreach (var skin in ballDatabase.skins)
        {
            GameObject go = Instantiate(shopItemPrefab, shopPanel);
            go.GetComponentInChildren<Text>().text = $"{skin.skinName} - {skin.price} coins";
            var button = go.GetComponentInChildren<Button>();
            button.interactable = !skin.unlocked && gameManager.coins >= skin.price;
            string skinName = skin.skinName;
            button.onClick.AddListener(() => TryBuySkin(skinName));
        }
        if (skinSelector) skinSelector.PopulateDropdown();
    }

    void TryBuySkin(string skinName)
    {
        var skin = ballDatabase.GetSkin(skinName);
        if (!skin.unlocked && gameManager.coins >= skin.price)
        {
            gameManager.coins -= skin.price;
            skin.unlocked = true;
            RefreshShop();
        }
    }
}
