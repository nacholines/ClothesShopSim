using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : MonoBehaviour
{
    private Inventory _shopKeeperInventory;
    private Inventory _playerInventory;
    [SerializeField] private GameObject ItemListPrefab;
    [SerializeField] private Button closeButton;
    [SerializeField] private Transform content;

    private void Awake()
    {
        closeButton.onClick.AddListener(CloseWindow);
    }
    public void OpenShop(Inventory shopKeeperInventory, Inventory playerInventory)
    {
        _shopKeeperInventory = shopKeeperInventory;
        _playerInventory = playerInventory;
        ShowShopItems();
    }

    private void CloseWindow()
    {
        Destroy(gameObject);
    }

    public void ShowShopItems()
    {
        foreach(Item item in _shopKeeperInventory.GetInventory())
        {
            var shopInteraction = new ShopInteraction();
            shopInteraction.callback = SellShopItem;
            shopInteraction.type = "Buy";
            var instantiatedItem = Instantiate(ItemListPrefab,content).GetComponent<ItemListing>();
            instantiatedItem.SetItem(item, shopInteraction);
        }
    }

    public void ShowPlayerItems()
    {
        foreach (Item item in _playerInventory.GetInventory())
        {
            var shopInteraction = new ShopInteraction();
            shopInteraction.type = "Sell";
            shopInteraction.callback = BuyPlayerItem;
            var instantiatedItem = Instantiate(ItemListPrefab,content).GetComponent<ItemListing>();
            instantiatedItem.SetItem(item, shopInteraction);
        }
    }

    public void SellShopItem()
    {

    }

    public void BuyPlayerItem()
    {

    }

}

public class ShopInteraction
{
    public Action callback;
    public string type;
}
