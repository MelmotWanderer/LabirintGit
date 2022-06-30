using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class NoiseIndicator : MonoBehaviour
{

    

    
    [SerializeField] private float _maxNoise;
    [SerializeField] private float _countNoiseInStep;
    [SerializeField] private float _countNoiseReduction;

    [HideInInspector] public UnityEvent<float> OnChangedCountNoise;
    [HideInInspector] public UnityEvent OnPlayerDetected;
    private float Noise;
    private bool isDetected = false;


    
    public float GetMaxNoise()
    {
        return _maxNoise;
    }
    public void AddNoise()
    {
      
        StopAllCoroutines();
        
        Noise += _countNoiseInStep;
        Noise = Mathf.Clamp(Noise, 0, _maxNoise);
     
        OnChangedCountNoise?.Invoke(Noise);

        if (!isDetected && Noise == 10)
        {

                OnPlayerDetected?.Invoke();
                isDetected = true;  
        }
          
           
            
       
    }

    public void ReductionNoise()
    {
        if (!isDetected) StartCoroutine(ReductionNoiseCoroutine());


       


    }
    
   
   private IEnumerator ReductionNoiseCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Noise -= _countNoiseReduction;
        Noise = Mathf.Clamp(Noise, 0, _maxNoise);
        OnChangedCountNoise?.Invoke(Noise);
        yield return StartCoroutine(ReductionNoiseCoroutine());
    }
   

}
