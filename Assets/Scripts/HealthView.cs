using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health Health;
    
    protected virtual void Start()
    {
        HandleValueChange();
    }

    private void OnEnable()
    {
        Health.OnValueChanged += HandleValueChange;
    }

    private void OnDisable()
    {
        Health.OnValueChanged -= HandleValueChange;
    }

    protected abstract void HandleValueChange();
}
