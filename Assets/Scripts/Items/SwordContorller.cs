using UnityEngine;

public class SwordContorller : MonoBehaviour
{
    private uint _damage;
    public uint Damage => _damage;
    private uint _cost;
    public uint Cost => _cost;
    [SerializeField] private uint _upgradeDamage;
    [SerializeField] private uint _costIncrease;

    private void Upgrade()
    {
        _damage += _upgradeDamage;
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
