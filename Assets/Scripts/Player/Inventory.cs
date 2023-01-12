using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static int _crystallCount = 0;
    public int CrystallCount => _crystallCount;
    private static int _oreCount = 0;
    public int OreCount => _oreCount;

    public void PickUpItem(GameObject gameObject, string name)
    {
        if (gameObject.name.Contains("Ore"))
            _oreCount++;
        if (gameObject.name.Contains("Crystall"))
            _crystallCount++;
    }

    public static void SetDefault()
    {
        _oreCount = 0;
        _crystallCount = 0;
    }

    public bool TryReduceCrystallCount(uint count)
    {
        if (count <= _crystallCount)
        {
            _crystallCount -= (int)count;

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TryReduceOreCount(uint count)
    {
        if (count <= _oreCount)
        {
            _oreCount -= (int)count;

            return true;
        }
        else
        {
            return false;
        }
    }
}
