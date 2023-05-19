using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour, IInventory
{
    public float Money;
    public List<Item> Inventory;
    public KeyCode InteractKey = KeyCode.E;
    private string _interactMessage;
    private IInteractable _interactable;
    private PromptMessage _prompt;
    public GameObject promptPrefab;
    public Canvas canvas;


    
    void Start()
    {
        _interactMessage = "Press " + InteractKey.ToString() + " to ";
    }

    void Update()
    {
        if (Input.GetKeyDown(InteractKey))
        {
            if (_interactable == null) return;
            _interactable.Interact(this);
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if(interactable != null)
        {
            var message = _interactMessage + interactable.GetPrompt();
            _interactable = interactable;

            if (_prompt) return;
            _prompt = Instantiate(promptPrefab, canvas.transform).GetComponent<PromptMessage>();
            if (_prompt) _prompt.SetMessage(message);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interactable = null;
        if (_prompt) Destroy(_prompt.gameObject);
    }
}
