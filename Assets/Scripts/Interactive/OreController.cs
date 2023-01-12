using UnityEngine;

public class OreController : MonoBehaviour, IUsableObject
{
    public void Use(GameObject gameObject)
    {
        Destroy(this.gameObject);

        gameObject.GetComponent<Inventory>().PickUpItem(this.gameObject, "Ore");
    }
}
