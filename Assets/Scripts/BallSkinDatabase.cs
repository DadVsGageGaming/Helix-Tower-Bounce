using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BallSkin
{
    public string skinName;
    public Material skinMaterial;
    public int price;
    public bool unlocked;
}

[CreateAssetMenu(fileName = "BallSkinDatabase", menuName = "ScriptableObjects/BallSkinDatabase", order = 1)]
public class BallSkinDatabase : ScriptableObject
{
    public List<BallSkin> skins;

    public BallSkin GetSkin(string skinName)
    {
        return skins.Find(s => s.skinName == skinName);
    }
}
