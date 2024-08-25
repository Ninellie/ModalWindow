using DG.Tweening;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject shopWindowPrefab;
    [SerializeField] private Transform canvas;

    private ShopWindow _shopWindow;

    public void OpenShopWindow()
    {
        var item = Instantiate(shopWindowPrefab, canvas);
        
        if (_shopWindow != null)
        {
            _shopWindow.enabled = false;
            Destroy(_shopWindow);
        }
        
        _shopWindow =  item.GetComponent<ShopWindow>();
        
        _shopWindow.AddItems();
        _shopWindow.ValidateItems();
        _shopWindow.AnimateOpening();
    }
}