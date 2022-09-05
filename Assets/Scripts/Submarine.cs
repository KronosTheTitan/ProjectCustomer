using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Submarine : MonoBehaviour
{
    [SerializeField] private float minSpeed = -1;
    [SerializeField] private float maxSpeed = 5;
    [SerializeField] private float maxPitchSpeed = 3;
    [SerializeField] private float maxTurnSpeed = 50;
    [SerializeField] private float acceleration = 2;

    [SerializeField] private float smoothSpeed = 3;
    [SerializeField] private float smoothTurnSpeed = 3;

    [SerializeField] private Transform propeller;
    [SerializeField] private Transform rudderPitch;
    [SerializeField] private Transform rudderYaw;
    [SerializeField] private float propellerSpeedFac = 2;
    [SerializeField] private float rudderAngle = 30;

    Vector3 velocity;
    float yawVelocity;
    float pitchVelocity;
    float currentSpeed;
    [SerializeField] private Material propSpinMat;

    [SerializeField] private Rigidbody _rigidbody;

    void Start () {
        //currentSpeed = maxSpeed;
    }

    void Update () {
        
        //acceleration
        float accelDir = 0;
        if (Input.GetKey (KeyCode.Q)) {
            //Debug.Log("Q");
            accelDir -= 1;
        }
        if (Input.GetKey (KeyCode.E)) {
            //Debug.Log("E");
            accelDir += 1;
        }
        
        //add acceleration to the currentSpeed. Accounts for framerate.
        currentSpeed += acceleration * Time.deltaTime * accelDir;
        //clamp currentSpeed between 0 and the maximum speed.
        currentSpeed = Mathf.Clamp (currentSpeed, minSpeed, maxSpeed);
        
        //calculate percentage of max speed reached.
        float speedPercent = currentSpeed / maxSpeed;

        Vector3 targetVelocity = transform.forward * currentSpeed;
        velocity = Vector3.Lerp (velocity, targetVelocity, Time.deltaTime * smoothSpeed);

        float targetPitchVelocity = Input.GetAxisRaw ("Vertical") * maxPitchSpeed;
        pitchVelocity = Mathf.Lerp (pitchVelocity, targetPitchVelocity, Time.deltaTime * smoothTurnSpeed);

        float targetYawVelocity = Input.GetAxisRaw ("Horizontal") * maxTurnSpeed;
        yawVelocity = Mathf.Lerp (yawVelocity, targetYawVelocity, Time.deltaTime * smoothTurnSpeed);
        transform.localEulerAngles += (Vector3.up * yawVelocity + Vector3.left * pitchVelocity) * Time.deltaTime * speedPercent;
        //rigidbody.MovePosition(transform.forward * currentSpeed * Time.deltaTime);
        _rigidbody.velocity = targetVelocity;

        //VISUAL EFFECTS
        //todo replace these with whatever the artists want to use.
        rudderYaw.localEulerAngles = Vector3.up * yawVelocity / maxTurnSpeed * rudderAngle;
        rudderPitch.localEulerAngles = Vector3.left * pitchVelocity / maxPitchSpeed * rudderAngle;

        propeller.Rotate (Vector3.forward * Time.deltaTime * propellerSpeedFac * speedPercent, Space.Self);
        //propSpinMat.color = new Color (propSpinMat.color.r, propSpinMat.color.g, propSpinMat.color.b, speedPercent * .3f);
        
        //Debug.Log(accelDir);
        //Debug.Log(velocity);
        Debug.Log(targetYawVelocity);
        Debug.Log(targetPitchVelocity);
    }
}
