using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeWindow : WindowBase
{
    private Inventory _playerInventory;
    private PlayerCustomization _playerCustomization;
    [SerializeField] private CustomizationPreview preview;
    [SerializeField] private GameObject equippableItemPrefab;
    [SerializeField] private Transform content;
    

    public void SetUpWardrobe(Inventory playerInventory, PlayerCustomization customization)
    {
        _playerInventory = playerInventory;
        _playerCustomization = customization;

        ShowWardrobeItems();
    }

    public void ShowWardrobeItems()
    {
        foreach (Item item in _playerInventory.GetInventory())
        {
            var wearableInteraction = new ItemInteraction();
            wearableInteraction.type = "Equip";
            wearableInteraction.callback = SelectItem;
            var instantiatedItem = Instantiate(equippableItemPrefab, content).GetComponent<EquippableItem>();
            instantiatedItem.SetItem(item, wearableInteraction);
        }
    }

    public void SelectItem(Item item) 
    {
        preview.EquipItem(item);
        _playerCustomization.EquipItem(item);
    }

}
