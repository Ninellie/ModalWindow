using System;
using UnityEngine;

[Serializable]
public class ShopItemProperties
{
    [SerializeField] private string title;
    [SerializeField] private string description;
    [SerializeField] private int price;
    [SerializeField] private Sprite icon;

    public string Title => title;
    public string Description => description;
    public int Price => price;
    public Sprite Icon => icon;
}