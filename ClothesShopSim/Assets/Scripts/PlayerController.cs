using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour, IHasInventory
{
    public float Money;
    public List<Item> Inventory;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void AddItem(Item item)
    {
        Inventory.Add(item);
        Money -= item.Price;
    }

    public void RemoveItem(string itemName)
    {
        Item itemToDelete = Inventory.FirstOrDefault(item => item.name == itemName);

        if (itemToDelete != null)
        {
            Inventory.Remove(itemToDelete);
        }
    }
}
