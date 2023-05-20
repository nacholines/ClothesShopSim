using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour, IWallet
{
    private float _money;
    public KeyCode InteractKey = KeyCode.E;
    public KeyCode WardrobeKey = KeyCode.I;
    private string _interactMessage;
    private IInteractable _interactable;
    private PromptMessage _prompt;
    public GameObject promptPrefab;
    public Canvas canvas;
    [SerializeField]private GameObject WardrobePrefab;
    [SerializeField] private PlayerCustomization customization;

    private Inventory _inventory;
    public Inventory Inventory => _inventory;


    private Wallet _wallet;
    public Wallet Wallet => _wallet;


    void Start()
    {
        _interactMessage = "Press " + InteractKey.ToString() + " to ";
        _inventory = new Inventory();
        
        _wallet = new Wallet();
        _wallet.SetBalance(300);

    }

    void Update()
    {
        if (Input.GetKeyDown(InteractKey))
        {
            if (_interactable == null) return;
            _interactable.Interact(this);
            if (_prompt) Destroy(_prompt.gameObject);
        }
        if (Input.GetKeyDown(WardrobeKey))
        {
            WardrobeWindow wardrobe = Instantiate(WardrobePrefab, canvas.transform).GetComponent<WardrobeWindow>();
            wardrobe.OpenWardrobe(_inventory, customization);
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

    public float GetBalance()
    {
        return _money;
    }

    public void TakeMoney(float amount)
    {
        if (amount - _money < 0) return;

        _money = -amount;
    }
}
