using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Trash : MonoBehaviour
{
    /// <summary>
    /// the amount of trash collected when the parent object is
    /// "picked up"
    /// </summary>
    [SerializeField] private int yield = 1;
    
    /// <summary>
    /// this method is called when something collides with this gameObjects
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //check if the other gameObject is the player, if its not exit the method
        if (other.gameObject != GameManager.Instance.Player) return;
        
        //call the method to add the amount trash set in the yield variable to the GameManagers
        //collectedTrash variable
        GameManager.Instance.ModifyCollectedTrash(yield);
        
        //destroy the gameObject, the trash spawner it belongs to will spawn a new one in due time
        Destroy(gameObject);
    }
}
