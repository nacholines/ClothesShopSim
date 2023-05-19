using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopKeeperController : MonoBehaviour, IInteractable
{
    [SerializeField] ShopWindow shopPrefab;
    [SerializeField] Canvas canvas;
    [SerializeField] List<Item> shopItems;
    ShopWindow _shop;
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
        _shop = Instantiate(shopPrefab, canvas.transform).GetComponent<ShopWindow>();
        _shop.OpenShop(_inventory,controller.Inventory);
    }

    public string GetPrompt()
    {
        return "open shop";
    }

    
}
