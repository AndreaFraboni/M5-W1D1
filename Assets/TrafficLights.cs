using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrafficLights : MonoBehaviour
{
    [SerializeField] private GameObject GreenLight;
    [SerializeField] private GameObject YellowLight;
    [SerializeField] private GameObject RedLight;
    [SerializeField] private TextMeshProUGUI _textTime;

    [SerializeField] private float _timeChange;

    private IEnumerator _refCorutine;

    private float _time = 0;

    IEnumerator TrafficLightSequencer()
    {
        while (true)
        {
            GreenLight.GetComponent<Renderer>().material.color = Color.green;
            RedLight.GetComponent<Renderer>().material.color = Color.gray;            
            yield return new WaitForSeconds(_timeChange);
            _time = _timeChange;
            GreenLight.GetComponent<Renderer>().material.color = Color.gray;
            YellowLight.GetComponent<Renderer>().material.color = Color.yellow;
            yield return new WaitForSeconds(_timeChange);
            _time = _timeChange;
            YellowLight.GetComponent<Renderer>().material.color = Color.gray;
            RedLight.GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(_timeChange);
            _time = _timeChange;

        }
    }

    private void TimeToChange()
    {
        _time -= Time.deltaTime;
        _textTime.text = _time.ToString("0.0");
    }

    private void Start()
    {
        _time = _timeChange;

        _refCorutine = TrafficLightSequencer();
        StartCoroutine(_refCorutine);

    }

    private void Update()
    {
        TimeToChange();
    }

}
