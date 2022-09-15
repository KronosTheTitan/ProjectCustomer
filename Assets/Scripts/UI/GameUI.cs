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

        private void Update()
        {
            pickedUpCapacity.minValue = 0;
            pickedUpCapacity.maxValue = GameManager.Instance.TrashCapacity;
            pickedUpCapacity.value = GameManager.Instance.CollectedTrash;

            fuel.minValue = 0;
            fuel.maxValue = GameManager.Instance.maxFuel;
            fuel.value = GameManager.Instance.currentFuel;
        }
    }
}
