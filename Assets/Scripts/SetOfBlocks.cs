using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOfBlocks : MonoBehaviour
{
    [SerializeField] private List<GameObject> blockSet;



    private void Update()
    {
        if (BlockSpawner.Instance.wholeSetDestroyed == false)
        {
            foreach (GameObject g in blockSet)
            {
                if (g != null) return;
                Destroy(g);
                if (blockSet.Count <= 0)
                {
                    BlockSpawner.Instance.wholeSetDestroyed = true;
                }
            }
        }
        
    }
}
