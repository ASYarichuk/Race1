using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsAnimation : MonoBehaviour
{
    [SerializeField] private GameObject[] _wheels = new GameObject[4];

    [SerializeField] private WheelCollider[] _wheelsCollider = new WheelCollider[4];

    private void FixedUpdate()
    {
        for (int i = 0; i < _wheels.Length; i++)
        {
            _wheelsCollider[i].GetWorldPose(out Vector3 wheelPosition, out Quaternion wheelRotation);
            _wheels[i].transform.SetPositionAndRotation(wheelPosition, wheelRotation);
        }
    }
}
