using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory
{
    public List<Item> GetInventory();
    public void AddItem(Item item);
    public void RemoveItem(string itemName);
}
