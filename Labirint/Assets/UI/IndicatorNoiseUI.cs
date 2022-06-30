using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Canvas))]
public class IndicatorNoiseUI : MonoBehaviour
{

    
    [SerializeField] private Image _indicatorNoiseImage;
    [SerializeField] private Gradient _colorIndicator;
    [SerializeField] private float _speedChange;
    private Canvas _canvas;
    private NoiseIndicator _noiseIndicator;
    private float _maxNoise;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }


    private void Start()
    {
        
         SetActiveIndicator(false);
       
    }

    
    public void Init(float maxNoise, NoiseIndicator noiseIndicator)
    {
        StopAllCoroutines();
        _indicatorNoiseImage.fillAmount = 0;
        _noiseIndicator = noiseIndicator;
        _noiseIndicator.OnChangedCountNoise.AddListener(ChangeCount);
        _maxNoise = maxNoise;
    }
    public void SetActiveIndicator(bool isActive)
    {
        _canvas.enabled = isActive;
    }
    public void ChangeCount(float countNoise)
    {

        StopAllCoroutines();
        StartCoroutine(ChangeCountCoroutine(countNoise));
    }
    private IEnumerator ChangeCountCoroutine(float countNoise)
    {
        
            while (_indicatorNoiseImage.fillAmount != countNoise / _maxNoise)
            {
                yield return new WaitForEndOfFrame();
            _indicatorNoiseImage.fillAmount = Mathf.Lerp(_indicatorNoiseImage.fillAmount, countNoise / _maxNoise, _speedChange * Time.deltaTime);

            _indicatorNoiseImage.color = Color.Lerp(_indicatorNoiseImage.color, _colorIndicator.Evaluate(countNoise / _maxNoise), _speedChange * Time.deltaTime);
            
            
            }
            yield return null;
        
    }

    
}
