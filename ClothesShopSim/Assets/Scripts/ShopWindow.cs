using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : MonoBehaviour
{
    private Inventory _shopKeeperInventory;
    private Inventory _playerInventory;
    private Wallet _playerWallet;

    [SerializeField] private GameObject ItemListPrefab;
    [SerializeField] private Transform content;
    [SerializeField] private Button showShopButton;
    [SerializeField] private Button showPlayerButton;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        closeButton.onClick.AddListener(CloseWindow);
        showPlayerButton.onClick.AddListener(ShowSellView);
        showShopButton.onClick.AddListener(ShowShopView);
    }
    public void OpenShop(Inventory shopKeeperInventory, Inventory playerInventory, Wallet playerWallet)
    {
        _shopKeeperInventory = shopKeeperInventory;
        _playerInventory = playerInventory;
        _playerWallet = playerWallet;

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
            var shopInteraction = new ItemInteraction();
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
            var shopInteraction = new ItemInteraction();
            shopInteraction.type = "Sell";
            shopInteraction.callback = BuyPlayerItem;
            var instantiatedItem = Instantiate(ItemListPrefab,content).GetComponent<ItemListing>();
            instantiatedItem.SetItem(item, shopInteraction);
        }
    }
    public void ShowShopView()
    {
        DeleteAllItemsFromList();
        ShowShopItems();
    }

    public void ShowSellView()
    {
        DeleteAllItemsFromList();
        ShowPlayerItems();
    }

    public void SellShopItem(Item toSell)
    {
        if (_playerWallet.GetBalance() - toSell.Price < 0) return;
        _shopKeeperInventory.RemoveItem(toSell);
        _playerInventory.AddItem(toSell);
        DeleteItemFromList(toSell);
        _playerWallet.TakeMoney(toSell.Price);
    }

    public void BuyPlayerItem(Item toBuy)
    {
        _playerInventory.RemoveItem(toBuy);
        _shopKeeperInventory.AddItem(toBuy);
        DeleteItemFromList(toBuy);
        _playerWallet.AddMoney(toBuy.Price);
    }

    private void DeleteItemFromList(Item toDelete)
    {
        foreach (ItemListing listed in content.GetComponentsInChildren<ItemListing>())
        {
            if (listed.Item != toDelete) continue;
            Destroy(listed.gameObject);
        }
    }

    private void DeleteAllItemsFromList()
    {
        foreach(ItemListing listed in content.GetComponentsInChildren<ItemListing>())
        {
            Destroy(listed.gameObject);
        }
    }

}

public class ItemInteraction
{
    public Action<Item> callback;
    public string type;
}
