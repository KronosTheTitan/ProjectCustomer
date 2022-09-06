using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// the transform belonging to the target
    /// the camera needs to follow.
    /// </summary>
    public Transform target;
    
    /// <summary>
    /// the offset the camera will maintain of the target.
    /// </summary>
    public Vector3 followOffset;
    
    /// <summary>
    /// The distance in front of the target the camera will point at.
    /// </summary>
    public float lookAheadDst = 10;
    
    /// <summary>
    /// the time a movement needs to be longer than before the camera
    /// will respond.
    /// </summary>
    public float smoothTime = .1f;
    
    /// <summary>
    /// the smoothing for the camera rotating after the target.
    /// </summary>
    public float rotSmoothSpeed = 3;

    /// <summary>
    /// used in smoothing the camera movement.
    /// </summary>
    Vector3 _smoothV;

    
    void LateUpdate()
    {
        //select the targetPosition based on the 
        Vector3 targetPos = target.position + target.forward * followOffset.z + target.up * followOffset.y + target.right * followOffset.x;
        
        //set the position to a smooth interpolated spot between its current position, target position based on its smoothing values.
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _smoothV, smoothTime);

        //grab the rotation from the transform component of the camera
        Quaternion rot = transform.rotation;
        
        //make the camera point at the targets position + its forward vector * the look ahead distance.
        transform.LookAt(target.position + target.forward * lookAheadDst);
        
        //set the target rotation to the now new transform.rotation.
        Quaternion targetRot = transform.rotation;

        //use a smooth interpolation between the original rotation (rot) and the target rotation
        //base on the change in time and the rotation smooth speed.
        //the transforms rotation is then set to this calculations results.
        transform.rotation = Quaternion.Slerp(rot,targetRot,Time.deltaTime * rotSmoothSpeed);
    }
}