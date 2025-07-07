using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BallSkinSelector : MonoBehaviour
{
    public BallSkinDatabase database;
    public Renderer ballRenderer;
    public Dropdown dropdown;

    void Start()
    {
        PopulateDropdown();
        dropdown.onValueChanged.AddListener(delegate { ChangeSkin(dropdown.value); });
    }

    public void PopulateDropdown()
    {
        dropdown.ClearOptions();
        var unlocked = database.skins.Where(s => s.unlocked).ToList();
        foreach (var skin in unlocked)
            dropdown.options.Add(new Dropdown.OptionData(skin.skinName));
        dropdown.RefreshShownValue();
    }

    public void ChangeSkin(int index)
    {
        var unlocked = database.skins.Where(s => s.unlocked).ToList();
        if (index < unlocked.Count)
            ballRenderer.material = unlocked[index].skinMaterial;
    }
}
