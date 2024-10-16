using UnityEngine;
using System.Collections;
using System;

public class Counter : MonoBehaviour
{
    private int _currentCountValue = 0;
    private float _delay = 0.5f;
    private bool _isActive = false;
    private Coroutine _countCoroutine;
    private WaitForSeconds _waitForSeconds;

    public event Action<int> CountChanged;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isActive)
            {
                StopCounting();
            }
            else
            {
                StartCounting();
            }
        }
    }

    private void StartCounting()
    {
        _isActive = true;
        _countCoroutine = StartCoroutine(IncreaseCount());
    }

    private void StopCounting()
    {
        _isActive = false;

        if (_countCoroutine != null)
        {
            StopCoroutine(_countCoroutine);
            _countCoroutine = null;
        }
    }

    private IEnumerator IncreaseCount()
    {
        _waitForSeconds = new WaitForSeconds(_delay);

        while (_isActive)
        {
            _currentCountValue++;
            CountChanged?.Invoke(_currentCountValue);

            yield return _waitForSeconds;
        }
    }
}
