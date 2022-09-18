using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameUI : MonoBehaviour
    {
        /// <summary>
        /// the slider used for displaying how much of the capacity of the trash bay is filled.
        /// </summary>
        [SerializeField] private Slider pickedUpCapacity;

        /// <summary>
        /// slider used to keep track of fuel.
        /// </summary>
        [SerializeField] private Slider fuel;
        
        /// <summary>
        /// this function is ran when the scene is loaded
        /// </summary>
        private void Start()
        {
            //checks if the trash capacity system is enabled.
            if (GameManager.Instance.trashCapacityEnabled)
            {
                //set the minimum value of the capacity slider at 0.
                pickedUpCapacity.minValue = 0;
            
                //set the max trash capacity to whatever the current capacity is.
                pickedUpCapacity.maxValue = GameManager.Instance.TrashCapacity;
            }
            else
            {
                //when the trash capacity system is not enabled it will delete the trash capacity slider.
                Destroy(pickedUpCapacity.gameObject);
            }
            
            //set the minimum value of the fuel slider.
            fuel.minValue = 0;
            
            //set the maximum fuel capacity based on the current maximum fuel capacity.
            fuel.maxValue = GameManager.Instance.maxFuel;

        }


        private void Update()
        {
            if (GameManager.Instance.trashCapacityEnabled)
            {
                pickedUpCapacity.value = GameManager.Instance.CollectedTrash;
            }
            
            //Set the value of the fuel slider to equal the player's current fuel level.
            //The slider automatically handles the percentage between minimum and maximum.
            fuel.value = GameManager.Instance.currentFuel;
        }

        
    }
}
