using UnityEngine;

public class CrystallController : MonoBehaviour, IUsableObject
{
    public void Use(GameObject gameObject)
    {
        Destroy(this.gameObject);

        gameObject.GetComponent<Inventory>().PickUpItem(this.gameObject, "Crystall");
    }
}
