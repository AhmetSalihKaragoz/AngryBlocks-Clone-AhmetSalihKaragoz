using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private Fillbar fillbar;
    [SerializeField] private CannonShooter _cannonShooter;

    public int DesroyedBlockCount { get; set; } = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateFillAmount()
    {
        fillbar._fillAmount += 0.25f;
        if (fillbar._fillAmount >= 1)
        {
            fillbar._fillAmount = 0;
            DesroyedBlockCount = 0;
            _cannonShooter.ballCount++;
        }
    }
    
    
}
