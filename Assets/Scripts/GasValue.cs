using UnityEngine;
using UnityEngine.UIElements;

public class GasValue : MonoBehaviour
{
    [Header("Valid Rotation Angles")]
    [SerializeField] private float offValueRotation = 0f;
    [SerializeField] private float highValueRotation = -90f;
    [SerializeField] private float lowValueRotation = -180f;

    [Header("Snapping")]
    [SerializeField] private float snapThreshold = 20f;
    [SerializeField] private bool snapOnRelease = true;

    [Header("Reference")]
    [SerializeField] private BurnerFlame plate;

    private bool gasEnabled = false;
    private bool gasFlowing = false;

    private void Awake()
    {
        MasterGasController.instance.OnGasStateChanged += GasHandle;
    }

    private void OnDestroy()
    {
        MasterGasController.instance.OnGasStateChanged -= GasHandle;
    }

    public void GasHandle(bool value)
    {
        gasEnabled = value;
        SetAngle();
    }

    public void OnGrabEnd()
    {
        SetAngle();
    }
    private float GetCurrentZAngle()
    {
        float z = transform.localEulerAngles.z;
        return (z > 180f) ? z - 360f : z;
    }

    private void SetAngle()
    {
        float currentZ = GetCurrentZAngle();

        float snapped = GetClosestSnapAngle(currentZ);
        transform.localEulerAngles = new Vector3(
            transform.localEulerAngles.x,
            transform.localEulerAngles.y,
            ToEuler(snapped)
        );
        SetGasFlowState(snapped);
    }
    private void SetGasFlowState(float snappedAngle)
    {
        gasFlowing = snappedAngle < 0 && gasEnabled;
        plate.SetGasFlowing(gasFlowing);
    }

    private float GetClosestSnapAngle(float angle)
    {
        float[] validAngles = { offValueRotation, highValueRotation, lowValueRotation };
        float closest = validAngles[0];
        float minDist = Mathf.Abs(angle - closest);

        foreach (float valid in validAngles)
        {
            float dist = Mathf.Abs(angle - valid);
            if (dist < minDist && dist <= snapThreshold)
            {
                minDist = dist;
                closest = valid;
            }
        }

        return closest;
    }

    private float ToEuler(float angle)
    {
        return (angle > 0f) ? angle - 360f  : angle;
    }
}
