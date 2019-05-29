using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class RadioButtonItem : MonoBehaviour, ISelectableByRay
{
    [SerializeField] private RadioButton _radioButton;
    private bool _isHit;
    
    private void Start()
    {   
        _radioButton.Subscribe(isHit =>
        {
            if (_isHit)
            {
                gameObject.GetComponent<Image>().color = Color.red;
            }
            else
            {
                gameObject.GetComponent<Image>().color = Color.white;
            }
        });
    }
  
    public void RayEnter()
    {
        _isHit = true;
        _radioButton.Execute(true);
    }

    public void RayExit()
    {
        _isHit = false;
    }
    
}

    
    
    
    
