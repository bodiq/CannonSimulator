using GlobalHandlers;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SliderHandler : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private TextMeshProUGUI powerCount;
        [SerializeField] private CannonFireSettings cannonFireSettings;

        private void Start()
        {
            OnValueChanged(cannonFireSettings.MinPower);
        }

        private void OnEnable()
        {
            slider.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged(float value)
        {
            slider.value = value;
            powerCount.text = slider.value.ToString();
            EventsHandler.OnPowerChange?.Invoke(value);
        }

        private void OnDisable()
        {
            slider.onValueChanged.RemoveListener(OnValueChanged);
        }
    }
}
