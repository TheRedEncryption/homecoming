using UnityEngine;
using UnityEngine.Rendering;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

[RequireComponent(typeof(Collider))]
public class Inventory : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    InventoryUI ui;
    [SerializeField]
    AudioSource audioSource;

    [Header("Prefabs")]
    [SerializeField]
    GameObject droppedItemPrefab;

    [Header("Audio Clips")]
    [SerializeField]
    AudioClip pickUpItemAudio;
    [SerializeField]
    AudioClip dropItemAudio;

    [Header("State")]
    [SerializeField]
    SerializedDictionary<string, Item> inventory = new();

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Touched: " + other.name + " | Tag: " + other.tag);

        if (other.CompareTag("DroppedItem"))
        {
            Debug.Log("DroppedItem tag detected!");

            DroppedItem droppedItem = other.GetComponent<DroppedItem>();

            if (droppedItem == null)
            {
                Debug.LogError("DroppedItem script is missing!");
                return;
            }

            if (droppedItem.pickedUp)
            {
                Debug.LogWarning("Item already marked as picked up!");
                return;
            }

            if (droppedItem.item == null)
            {
                Debug.LogError("No Item assigned to DroppedItem!");
                return;
            }

            Debug.Log("Collecting: " + droppedItem.item.id);

            droppedItem.pickedUp = true;
            AddItem(droppedItem.item);

            droppedItem.ApplyCollectionEffect(gameObject);

            Destroy(other.gameObject);

            Debug.Log("Pickup processed!");
        }
    }

    void AddItem(Item item)
    {
        var inventoryId = Guid.NewGuid().ToString();
        inventory.Add(inventoryId, item);
        ui.AddUIItem(inventoryId, item);
    }

    public void DropItem(string inventoryId)
    {
        var droppedItem = Instantiate(droppedItemPrefab, transform.position, Quaternion.identity).GetComponent<DroppedItem>();
        var item = inventory.GetValueOrDefault(inventoryId);
        droppedItem.Initialize(item);
        inventory.Remove(inventoryId);
        ui.RemoveUIItem(inventoryId);
        audioSource.PlayOneShot(dropItemAudio);
    }
}
