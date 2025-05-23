using UnityEngine;

[System.Serializable]
public class WeaponSlot
{
    private Item item;
    [SerializeField] public Weapon_Item weapon;
    int weaponQuantity;
    int quantity;
    private Sprite weaponIcon;
    private bool isInitialized = false;



    public WeaponSlot()
    {
        item = null;
        weapon = null;
        if (weapon != null)
        {
            weapon.itemQuantity = weaponQuantity;
        }
            
    }

    public WeaponSlot(Item _item, int _quantity)
    {
        weaponQuantity = weapon.itemQuantity;
        item = _item;
        quantity = _quantity;
    }

    public WeaponSlot(Weapon_Item _tool, int _quantity)
    {
        weaponQuantity = weapon.itemQuantity ;
        weapon = _tool;
        quantity = _quantity;
    }

    public Sprite GetIcon() => weaponIcon;
    public Weapon_Item GetWeapon() => weapon;
    public int GetQuantity() 
    {
        if(!isInitialized)
        {
            weaponQuantity = weapon.itemQuantity;
            isInitialized = true;
        }
      
        return weaponQuantity;
    }
    public string GetDescription() => weapon != null ? weapon.description : string.Empty;
    public string GetName() => weapon != null ? weapon.name : string.Empty;

    public void AddQuantity(int _quantity) => weaponQuantity += _quantity;
    public void SubQuantity(int _quantity) => weaponQuantity -= _quantity;

    //public int GetID() => slotWeapon != null ? slotWeapon.itemID : -1;
    //public void SetTool(Consumeable_Item newTool) => slotWeapon = newTool;
    public Item GetItem() => item;

}
