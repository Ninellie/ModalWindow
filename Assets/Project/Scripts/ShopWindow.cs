using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShopWindow : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform itemListParent;
    
    [SerializeField] private ShopItemList itemList;
    [SerializeField] private IntVariable coins;
    
    [SerializeField] private List<ShopItemElement> itemElements;

    private Tween _openingTween;
    
    private void OnEnable()
    {
        coins.OnChange.AddListener(ValidateItems);
    }

    private void OnDisable()
    {
        coins.OnChange.RemoveListener(ValidateItems);
        _openingTween?.Kill();
    }

    public void AddItems()
    {
        itemElements = new List<ShopItemElement>();
        
        foreach (var shopItem in itemList.Items)
        {
            var item = Instantiate(itemPrefab, itemListParent);
            var itemElement = item.GetComponent<ShopItemElement>();
            
            itemElement.Initiate(shopItem);
            itemElement.OnBuy.AddListener(coins.ApplyChange);
            
            itemElements.Add(itemElement);
        }
    }

    public void ValidateItems()
    {
        var coinsInWallet = coins.GetValue();
        foreach (var itemElement in itemElements)
        {
            if (itemElement.Properties.Price <= coinsInWallet)
            {
                itemElement.SetAvailable();
                continue;
            }
            itemElement.SetUnavailable();
        }
    }

    public void AnimateOpening()
    {
        transform.localScale.Set(0.8f, 0.8f, 0.8f);
        _openingTween = transform.DOScale(1, 1).SetEase(Ease.InElastic);
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}