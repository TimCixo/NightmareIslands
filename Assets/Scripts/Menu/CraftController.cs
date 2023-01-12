using UnityEngine;

public class CraftController : MonoBehaviour
{
    [SerializeField] private GameObject _sword;
    [SerializeField] private GameObject _helmet;

    private uint _count = 10;

    public void CraftSword(GameObject sender)
    {
        if (sender.GetComponent<Inventory>().TryReduceOreCount(_count))
        {
            Instantiate(_sword, gameObject.transform);
        }
    }

    public void CraftArmor(GameObject sender)
    {
        if (sender.GetComponent<Inventory>().TryReduceOreCount(_count))
        {
            Instantiate(_helmet, gameObject.transform);
        }
    }

    public void UpgradeSword(GameObject sender)
    {
        if(sender.TryGetComponent(out SwordContorller sword))
        {
            if (sword.TryUpgrade(sender))
            {
                sender.GetComponent<Inventory>().TryReduceCrystallCount(sword.Cost);
            }
        }
    }

    public void UpgradeArmor(GameObject sender)
    {
        if (sender.TryGetComponent(out ArmorController armor))
        {
            if (armor.TryUpgrade(sender))
            {
                sender.GetComponent<Inventory>().TryReduceCrystallCount(armor.Cost);
            }
        }
    }
}
