using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIImageFader : MonoBehaviour
{
    [SerializeField] private Image _img;
    [SerializeField] private float _fadeDuration = 0.5f;
    [SerializeField] private bool _isBlack = true;
    [SerializeField] private float _targetAlpha;
    private Coroutine currentFade;

    private void Awake()
    {
        if (_img == null) _img = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _targetAlpha = 0f;
        currentFade = StartCoroutine(FadeTo(_targetAlpha));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isBlack = !_isBlack;          

            if (_isBlack)
                _targetAlpha = 1f;  
            else
                _targetAlpha = 0f;   

            if (currentFade != null) StopCoroutine(currentFade);
            currentFade = StartCoroutine(FadeTo(_targetAlpha));
        }
    }

    private IEnumerator FadeTo(float targetAlpha)
    {
        float startAlpha = _img.color.a;
        float time = 0f;

        while (time < _fadeDuration)
        {
            time = time + Time.deltaTime;
            float duration = time / _fadeDuration;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, duration);
            Color color = _img.color;
            color.a = newAlpha;
            _img.color = color;

            yield return null;
        }

        Color finalColor = _img.color;
        finalColor.a = targetAlpha;
        _img.color = finalColor;

        currentFade = null;
    }
}
