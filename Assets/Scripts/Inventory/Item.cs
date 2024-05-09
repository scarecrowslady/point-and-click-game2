using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Item")]

public class Item : ScriptableObject
{
    [Header("GamePlay Only")]
    public ItemType itemType;
    public ActionType actionType;

    public bool isBeingCarried = false;

    [Header("Only UI")]
    public bool stackable = true;
    public bool pickupAble = true;
    public bool carryAble = true;
    public bool isBook = false;

    [Header("Both")]
    public Sprite image;
    public int itemheldAN;
    public string goName;

    public int ID;

    public enum ItemType
    {
        KeyItem,
        Resource,
        SpecialInteract,
        Book,
        Extra
    }
    public enum ActionType
    {
        Produce,
        Unlock,
        Solve,
        Reveal,
        Flavor
    }
}
