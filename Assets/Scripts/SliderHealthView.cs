using UnityEngine.UI;

public class SliderHealthView : HealthView
{
    protected Slider Slider;

    protected override void Start()
    {
        if (TryGetComponent(out Slider slider))
        {
            Slider = slider;
        }
        
        Slider.minValue = 0;
        Slider.maxValue = Health.MaxHealthPont;
        Slider.value = Health.Current;
        base.Start();
    }
    
    protected override void HandleValueChange()
    {
        if (Slider != null)
            Slider.value = Health.Current;
    }
}
