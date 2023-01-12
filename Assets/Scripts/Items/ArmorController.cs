using UnityEngine;

public class ArmorController : MonoBehaviour
{
    private uint _armor;
    public uint Armor => _armor;
    private uint _cost;
    public uint Cost => _cost;
    [SerializeField] private uint _upgradeArmor;
    [SerializeField] private uint _costIncrease;

    private void Upgrade()
    {
        _armor += _upgradeArmor;
        _cost += _costIncrease;
    }

    public bool TryUpgrade(GameObject sender)
    {
        Inventory inventory = sender.GetComponent<Inventory>();

        if (inventory.CrystallCount >= _cost)
        {
            Upgrade();

            return true;
        }
        else
        {
            return false;
        }
    }
}
