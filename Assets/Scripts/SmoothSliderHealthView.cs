using System.Collections;
using UnityEngine;

public class SmoothSliderHealthView : SliderHealthView
{
    [SerializeField] private float _speed;
    
    private Coroutine _healthChangingCoroutine;
    private float _localScaleX;

    private void Start()
    {
        _localScaleX = Health.transform.localScale.x;
        base.Start();
    }

    private void Update()
    {
        if (_localScaleX != Health.transform.localScale.x)
        {
            Vector3 localScale = new Vector3(Health.transform.localScale.x, transform.localScale.y, transform.localScale.z);
            transform.localScale = localScale;
            _localScaleX = transform.localScale.x;
        }
    }

    protected override void HandleValueChange()
    {
        if (_healthChangingCoroutine != null)
            StopCoroutine(_healthChangingCoroutine);
        
        _healthChangingCoroutine = StartCoroutine(HealthChanging());
    }

    private IEnumerator HealthChanging()
    {
        while (Slider.value != Health.Current)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, Health.Current, Time.deltaTime * _speed);
            yield return null;
        }
    }
}
