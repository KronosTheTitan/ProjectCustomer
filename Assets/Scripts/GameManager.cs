using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public GameObject Player;
    public GameObject TrashPrefab;
    
    public int CollectedTrash { get; private set; }

    public void CollectTrash(int collectedAmount)
    {
        CollectedTrash += collectedAmount;
    }

}
