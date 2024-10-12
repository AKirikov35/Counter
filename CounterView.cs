using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countText;
    [SerializeField] private Counter _counter;

    private void Start()
    {
        _countText.text = _counter.CurrentCountValue.ToString();
    }

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