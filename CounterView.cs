using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CountChanged += UpdateCountText;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= UpdateCountText;
    }

    private void UpdateCountText(int currentValue)
    {
        _countText.text = currentValue.ToString();
    }
}
