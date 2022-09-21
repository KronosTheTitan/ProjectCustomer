using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// the singleton instance used to refer to the GameManager.
    /// only 1 can exist at any given time
    /// </summary>
    public static GameManager Instance { get; private set; }
    
    public TMP_Text trashCollected;
    public TMP_Text trashCollectedFinal;

    public Transform CaptainsMessageTarget;

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
    /// the actual submarine class
    /// </summary>
    [SerializeField] private Submarine Submarine;
    
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
    /// the maximum amount of trash the player can pick up before having to return to base.
    /// </summary>
    public int TrashCapacity { get; private set; } = 3;
    [FormerlySerializedAs("TrashCapacityEnabled")] public bool trashCapacityEnabled;

    public GameObject mainUI;

    /// <summary>
    /// Used to modify the amount of trash collected.
    /// Negative numbers will decrease it, positive numbers increase it
    /// </summary>
    /// <param name="amount"></param>
    public void ModifyCollectedTrash(int amount)
    {
        CollectedTrash += amount;
    }

    public void AddFuel(int amount)
    {
        currentFuel += amount;
        currentFuel = Mathf.Clamp(currentFuel, 0, maxFuel);
    }

    /// <summary>
    /// the maximum fuel capacity
    /// </summary>
    public float maxFuel = 100;
    
    /// <summary>
    /// the current amount of fuel.
    /// </summary>
    public float currentFuel = 100;
    
    /// <summary>
    /// how much fuel is used.
    /// math = ( the percentage of the actual speed / 10 ) * this variable.
    /// </summary>
    public float fuelConsumptionFac = 2;

    /// <summary>
    /// This function is used to control the fuel
    /// consumption rate of the player.
    /// it is based on their current speed.
    /// </summary>
    private void FuelUsage()
    {
        //set the speed percentage to account for reverse.
        //just an if statement that checks if the speed percentage is below 0 and flips it to above 0 if true.
        float actualSpeedPercent = Submarine.speedPercent >= 0 ? Submarine.speedPercent : Submarine.speedPercent * -1;
        
        //decrease the amount of fuel the player has
        currentFuel -= actualSpeedPercent * fuelConsumptionFac;
    }

    private float _lastFuelTick = 0;
    [SerializeField] private float fuelTickInterval = 1;

    private void Update()
    {
        if (Time.time > _lastFuelTick + fuelTickInterval)
        {
            _lastFuelTick = Time.time;
            FuelUsage();
        }
        
        trashCollected.text = CollectedTrash.ToString();
        trashCollectedFinal.text = CollectedTrash.ToString();
    }
}
