using System.Runtime.CompilerServices;
using UnityEngine;

public static class EnemyAggression
{
    public static float AggressionMultiplier = 1f;
    public static void ApplyGlobalAggression(float amount) 
    {
        AggressionMultiplier += Mathf.Max(0f, amount);

        EnemyController[] enemies =
            Object.FindObjectsByType<EnemyController>(
                FindObjectsSortMode.None);

        foreach (EnemyController enemy in enemies)
        {
            enemy.UpdateEnemyAggression();
        }

        Debug.Log("Enemy Aggression Applied! Multiplier: "
            + AggressionMultiplier);
   
    }

    [RuntimeInitializeOnLoadMethod(
            RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetAggression()
    {
        AggressionMultiplier = 1f;
    }

}
