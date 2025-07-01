using System;
using UnityEngine;

public class MasterGasController : MonoBehaviour
{
    public static MasterGasController instance;
    public event Action<bool> OnGasStateChanged;
    public bool IsGasOn { get; private set; }


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private float GetZAngle()
    {
        float angle = transform.localEulerAngles.z;
        if (angle > 180f) angle -= 360f; 
        return angle;
    }

    private bool UpdateGasState()
    {
        float zAngle = GetZAngle();
        bool previousState = IsGasOn;
        IsGasOn = zAngle < 0f;

        if (IsGasOn != previousState)
        {
            OnGasStateChanged?.Invoke(IsGasOn);
        }

        return IsGasOn;
    }
    public void OnGrabEnd()
    {
        UpdateGasState();
    }
}

