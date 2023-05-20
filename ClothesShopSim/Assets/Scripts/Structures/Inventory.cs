using System.Collections.Generic;
using System.Linq;


public class Inventory : IInventory
{
    private List<Item> _inventory;

    public Inventory()
    {
        _inventory = new List<Item>();
    }
    public List<Item> GetInventory()
    {
        return _inventory;
    }

    public void AddItem(Item item)
    {
        _inventory.Add(item);
    }

    public void RemoveItem(Item toDelete)
    {
        Item itemToDelete = _inventory.FirstOrDefault(item => item == toDelete);

        if (itemToDelete != null)
        {
            _inventory.Remove(itemToDelete);
        }
    }
}
