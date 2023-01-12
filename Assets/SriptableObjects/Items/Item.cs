using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField] protected string Label;
    [SerializeField] protected string Description;
    [SerializeField] protected int Price;
    [SerializeField] private GameObject Prefab;
    [SerializeField] private Sprite Icon;
     
    public abstract void PickUp();
    public abstract void Use();
}