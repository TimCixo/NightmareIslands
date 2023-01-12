using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon", order = 51)]
public class Weapon : Item
{
    [SerializeField] private uint _damage;
    [SerializeField] private uint _range;
    [SerializeField] private float _strength;

    public override void PickUp()
    {
    }

    public override void Use()
    { 
    }
}
