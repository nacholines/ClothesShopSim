using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour, IWallet
{
    [Header("Keys")]
    [Space(1)]
    [SerializeField] KeyCode InteractKey = KeyCode.E;
    [SerializeField] KeyCode WardrobeKey = KeyCode.I;

    [Header("Prefabs")]
    [Space(1)]
    [SerializeField] private WardrobeWindow wardrobePrefab;
    [SerializeField] private PromptBase promptPrefab;
    
    private float _money;
    private string _interactMessage;

    private IInteractable _interactable;
    
    private PlayerCustomization _customization;
    private PromptMessage _prompt;
    private WardrobeWindow _wardrobe;
    private Inventory _inventory;
    private Wallet _wallet;
    private Canvas _canvas;
    public Inventory Inventory => _inventory;
    public Wallet Wallet => _wallet;

    void Start()
    {
        _interactMessage = "Press " + InteractKey.ToString() + " to ";
        _inventory = new Inventory();
        
        _wallet = new Wallet();
        _wallet.SetBalance(300);

        _canvas = FindObjectOfType<Canvas>();
        _customization = GetComponent<PlayerCustomization>();

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
            if (_wardrobe) return;
            _wardrobe = (WardrobeWindow) WindowManager.Instance.OpenWindow(wardrobePrefab);
            _wardrobe.SetUpWardrobe(_inventory, _customization);
            _wardrobe.OpenWindow();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if(interactable != null)
        {
            var message = _interactMessage + interactable.GetPrompt();
            _interactable = interactable;

            if (_prompt || !_canvas) return;
            _prompt = (PromptMessage) PromptManager.Instance.ShowPrompt(promptPrefab);
            if (_prompt)
            {
                _prompt.SetMessage(message);
                _prompt.ShowPrompt();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _interactable = null;
        if (_prompt) _prompt.HidePrompt();
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
