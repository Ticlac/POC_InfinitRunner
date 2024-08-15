using UnityEngine;


public enum CollectibleType
{
    GASTANK,
    COINS,
    ICE

}

[CreateAssetMenu(fileName = "CollectibleData", menuName = "Data/CollectibleData")]
public class CollectibleData : ScriptableObject
{
    public CollectibleType type;
    public GameObject prefab;
    public float amount;

    public void Process()
    {
        switch (type)
        {
            case CollectibleType.GASTANK:
                AddFuel();
                break;
        }
    }

    private void AddFuel()
    {
        Debug.Log("CollectibleData AddFuel");
    }
}
