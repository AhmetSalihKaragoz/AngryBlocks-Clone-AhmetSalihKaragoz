using UnityEngine;
using UnityEngine.UI;

public class Fillbar : MonoBehaviour
{
    [SerializeField] private Image _fillbarImage;
    [Range(0, 1)] public float _fillAmount = 0f;
        
    private void Update() 
    {
        _fillbarImage.fillAmount = _fillAmount;
    }
}
