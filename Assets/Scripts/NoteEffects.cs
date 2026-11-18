using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusEffects : MonoBehaviour
{
    private HashSet<string> appliedEffects = new HashSet<string>();

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void ApplyEffect(Item item)
    {
        if (item == null || string.IsNullOrEmpty(item.id))
            return;

        if (!appliedEffects.Add(item.id)) 
        {
            Debug.Log("Effect already applied: " +  item.id);
            return;
        }

        switch (item.collectionEffect)
        {
            case CollectionEffect.SpeedBoost:
                if (playerMovement != null)
                {
                    playerMovement.ApplySpeedBoost(item.effectAmount);
                    Debug.Log("Permanent speed boost applied!");
                }
                break;

            case CollectionEffect.EnemyAggression:
                Debug.Log("Enemy aggression effect collected.");
                break;

            case CollectionEffect.EnemySlow:
                Debug.Log("Enemy slow effect collected.");
                break;

            case CollectionEffect.AreaUnlock:
                Debug.Log("Area unlock effect collected.");
                break;

            case CollectionEffect.KeySpawn:
                Debug.Log("Key spawn effect collected.");
                break;

            case CollectionEffect.LimitVision:
                Debug.Log("Limited vision effect collected.");
                break;
        }
    }
}
