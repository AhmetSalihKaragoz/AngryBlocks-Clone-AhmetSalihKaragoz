using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [SerializeField] private Text lifetext;
    [SerializeField] private int _blockHealth;
    
    void Start()
    {
        lifetext.text = _blockHealth.ToString();
    }

    public void UpdateBlockHealth()
    {
        _blockHealth--;
        lifetext.text = _blockHealth.ToString();
        if (_blockHealth <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.DesroyedBlockCount++;
            GameManager.Instance.UpdateFillAmount();
        }
    }
    
}
