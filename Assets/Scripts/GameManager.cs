using UnityEngine;

[ExecuteInEditMode]
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// the singleton instance used to refer to the GameManager.
    /// only 1 can exist at any given time
    /// </summary>
    public static GameManager Instance { get; private set; }
    
    private void Start() 
    { 
        // If there already exists an instance destroy this one
        // Else set this object as the new Instance.

        if (Instance != null && Instance != this) 
        {
            DestroyImmediate(this); 
        }
        else
        {
            Instance = this; 
        } 
    }

    /// <summary>
    /// Refers to the player object.
    /// </summary>
    public GameObject Player;
    
    /// <summary>
    /// the prefab object that stores the trash object.
    /// </summary>
    public GameObject TrashPrefab;
    
    /// <summary>
    /// used for reading the amount of trash the player has collected.
    /// cannot be changed outside of this class.
    /// </summary>
    public int CollectedTrash { get; private set; }

    /// <summary>
    /// Used to modify the amount of trash collected.
    /// Negative numbers will decrease it, positive numbers increase it
    /// </summary>
    /// <param name="amount"></param>
    public void ModifyCollectedTrash(int amount)
    {
        CollectedTrash += amount;
    }

}
