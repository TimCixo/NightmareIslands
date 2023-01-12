using UnityEngine;

[CreateAssetMenu(fileName = "Booster", menuName = "Items/Booster", order = 51)]
public class Booster : Item
{
    [SerializeField] float _cure;

    public override void PickUp()
    {
    }

    public override void Use()
    {
    }
}
