using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Trash : MonoBehaviour
{
    [SerializeField] private GameObject message;
    /// <summary>
    /// the amount of trash collected when the parent object is
    /// "picked up"
    /// </summary>
    [SerializeField] private int yield = 1;
    [SerializeField] private int fuel = 0;
    
    /// <summary>
    /// this method is called when something collides with this gameObjects
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //check if the other gameObject is the player, if its not exit the method.
        if (other.gameObject != GameManager.Instance.Player) return;
        
        //check if the trash capacity system is enabled, if its not return out of the method.
        if (GameManager.Instance.trashCapacityEnabled)
        {
            if (GameManager.Instance.TrashCapacity < GameManager.Instance.CollectedTrash + yield)
            {
                return;
            }
        }
        
        //call the method to add the amount trash set in the yield variable to the GameManagers
        //collectedTrash variable
        GameManager.Instance.ModifyCollectedTrash(yield);
        GameManager.Instance.AddFuel(fuel);
        
        GameObject messageObject = Instantiate(message, GameManager.Instance.CaptainsMessageTarget, true);
        messageObject.transform.position = new Vector3(Screen.width/2,Screen.height/2,1);

        //destroy the gameObject, the trash spawner it belongs to will spawn a new one in due time
        Destroy(gameObject);
    }
}
