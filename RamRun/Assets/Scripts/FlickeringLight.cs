﻿using UnityEngine;
using System.Collections;

public class FlickeringLight : MonoBehaviour {

    public float based = 0.0f; // start
    public float amplitude = 1.0f; // amplitude of the wave
    public float phase = 0.0f; // start point inside on wave cycle
    public float frequency = 0.5f; // cycle frequency per second
 
    private Color originalColor;
    private EnemyManager enemyManager;

    void Start() {
        originalColor = GetComponent<Light>().color;

        GameObject mainCameraObject = GameObject.FindWithTag("MainCamera");
        if (mainCameraObject != null)
        {
            enemyManager = mainCameraObject.GetComponent<EnemyManager>();
        }

        if (enemyManager == null)
        {
            Debug.Log("Cannot find 'EnemyManager' script");
        }
    }

    void Update()
    {
        Light light = GetComponent<Light>();
        if (enemyManager.isGameOver())
        {
            light.color = Color.black;
        } else
        {  
            light.color = originalColor * (EvalWave());
        }
    }

    float EvalWave()
    {
        float x = (Time.time + phase) * frequency;
        float y;

        x = 2*(x - Mathf.Floor(x)); // normalized value (0..1)

        if (x < 1) y = Mathf.Sin(x * Mathf.PI);
        else y = Mathf.Sin((2-x) * Mathf.PI);

        return (y * amplitude) + based;
    }
}

