using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class MoveFractalSound : MonoBehaviour
{

    public FastNoiseUnity fastNoise;

    public float timerFrequency;

    private float timer;

    private int intRandom;
    private int previousInt = 2;

    private void Start()
    {
        StartCoroutine(ChangeFrequency());
    }

    IEnumerator ChangeFrequency()
    {
        timer = timerFrequency;
        while(timer > 0)
        {
            yield return new WaitForSeconds(1f);

            timer--;
            Debug.Log(timer);
            
            intRandom = Random.Range(5, 10);


            if (timer == 1)
            {
                Debug.Log("1 IS THE KING");
                fastNoise.frequency = intRandom;
                fastNoise.seed = intRandom;
                fastNoise.octaves = intRandom;
                fastNoise.gain = intRandom;
                fastNoise.cellularJitter = intRandom;
                fastNoise.lacunarity = intRandom;
            }
            
            if (timer <= 0)
            {
                Debug.Log("enter the frequency variable change");
                fastNoise.frequency = Random.Range(1, 3);
                timer = timerFrequency;
            }

            gameObject.GetComponent<Transform>();

        }
    }
    
    
}
