using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopKeeperController : MonoBehaviour, IInteractable
{
    [SerializeField] ShopWindow shopPrefab;
    [SerializeField] List<Item> shopItems;

    private ShopWindow _shop;
    private Inventory _inventory;



    private void Awake()
    {
        _inventory = new Inventory();
        foreach (Item item in shopItems)
        {
            _inventory.AddItem(item);
        }
    }

    public void Interact(PlayerController controller)
    {
        if (_shop) return;
        _shop = (ShopWindow) WindowManager.Instance.OpenWindow(shopPrefab);
        _shop.SetUpShop(_inventory,controller.Inventory, controller.Wallet);
        _shop.OpenWindow();
    }

    public string GetPrompt()
    {
        return "open shop";
    }
}
