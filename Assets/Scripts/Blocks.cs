using UnityEngine;
using UnityEngine.UI;

public class Blocks : MonoBehaviour
{
    [SerializeField] private Text lifetext;
    [SerializeField] private int _blockHealth;
    

    public int blockHealth
    { 
        get => _blockHealth;
        set => _blockHealth = value;
    }

    void Start()
    {
        lifetext.text = _blockHealth.ToString();
    }

    public void UpdateBlockHealth()
    {
        _blockHealth--;
        lifetext.text = _blockHealth.ToString();
        if(_blockHealth == 0) { Destroy(gameObject);}
    }
    
}
