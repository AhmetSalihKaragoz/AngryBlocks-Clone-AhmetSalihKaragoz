using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public static BlockSpawner Instance;
    
    [HideInInspector] public bool wholeSetDestroyed = false;
    
    [SerializeField] private List<GameObject> blocks;

    private int _blockIndex = 0;

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

    private void Start()
    {
        SpawnNextSetOfBlocks();
    }

    private void Update()
    {
        if (wholeSetDestroyed)
        {
            SpawnNextSetOfBlocks();
            wholeSetDestroyed = false;
        }
    }

    public void SpawnNextSetOfBlocks()
    {
        Instantiate(blocks[_blockIndex], new Vector3(7.92f, -1.9f, 1.5f),Quaternion.identity);
        _blockIndex++;
    }
}
