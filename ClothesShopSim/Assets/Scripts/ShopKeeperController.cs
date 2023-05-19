using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperController : MonoBehaviour, IInteractable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
    }

    public void Interact(PlayerController player)
    {
        OpenShop();
    }

    public void OpenShop()
    {
        Debug.Log("open shop");
    }

    public string GetPrompt()
    {
        return "Open shop";
    }
}
