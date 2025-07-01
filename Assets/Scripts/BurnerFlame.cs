using UnityEngine;

public class BurnerFlame : MonoBehaviour
{
    [Header("Flame Settings")]
    [SerializeField] private AudioSource ignitionSound;

    private GameObject activeFlame;
    private bool isLit = false;
    private bool isGasFlowing = false;

    void Start()
    {
        PerformEffect();
    }
    public void SetGasFlowing(bool flowing)
    {
        isGasFlowing = flowing;

        if (!isGasFlowing && isLit)
            Extinguish();
    }

    public void TryIgnite()
    {
        if (isLit || !isGasFlowing) return;

        isLit = true;

        activeFlame = ObjectPool.instance.GetObjectFromPool();
        if (activeFlame != null)
        {
            activeFlame.transform.position = transform.position;
            activeFlame.SetActive(true);

            var ps = activeFlame.GetComponent<ParticleSystem>();
            if (ps != null) ps.Play();
        }

        if (ignitionSound != null) ignitionSound.Play();
    }

    private void PerformEffect()
    {
        activeFlame = ObjectPool.instance.GetObjectFromPool();
        if (activeFlame != null)
        {
            activeFlame.transform.position = transform.position;
            activeFlame.SetActive(true);

            var ps = activeFlame.GetComponent<ParticleSystem>();
            if (ps != null) ps.Play();
        }

        if (ignitionSound != null) ignitionSound.Play();
    }

    public void Extinguish()
    {
        isLit = false;

        if (activeFlame != null)
        {
            activeFlame.SetActive(false);
            activeFlame = null;
        }

        if (ignitionSound != null) ignitionSound.Stop();
    }
}
