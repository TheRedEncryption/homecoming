using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemySlow : MonoBehaviour
{
    public static float GlobalSpeedMultiplier = 1f;

    public static void ApplyGlobalSlow(float amount)
    {
        GlobalSpeedMultiplier *= Mathf.Clamp01(1f - amount);

        EnemyController[] enemies =
            FindObjectsByType<EnemyController>(
                FindObjectsSortMode.None);

        foreach (EnemyController enemy in enemies)
        {
            enemy.UpdateEnemySpeed();
        }

        Debug.Log("Enemy slowdown applied! Multiplier: " 
            + GlobalSpeedMultiplier);
    }

    [RuntimeInitializeOnLoadMethod(
            RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetSpeed()
    {
        GlobalSpeedMultiplier = 1f;
    }
}
