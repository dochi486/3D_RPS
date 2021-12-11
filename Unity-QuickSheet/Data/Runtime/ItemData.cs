using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
/// 
[System.Serializable]
public class ItemData
{
  [SerializeField]
  int id;
  public int ID { get {return id; } set { this.id = value;} }
  
  [SerializeField]
  string name;
  public string Name { get {return name; } set { this.name = value;} }
  
  [SerializeField]
  float damage;
  public float Damage { get {return damage; } set { this.damage = value;} }
  
  [SerializeField]
  float accuracy;
  public float Accuracy { get {return accuracy; } set { this.accuracy = value;} }
  
  [SerializeField]
  float firerate;
  public float Firerate { get {return firerate; } set { this.firerate = value;} }
  
  [SerializeField]
  float reloadspeed;
  public float Reloadspeed { get {return reloadspeed; } set { this.reloadspeed = value;} }
  
  [SerializeField]
  int magazinesize;
  public int Magazinesize { get {return magazinesize; } set { this.magazinesize = value;} }
  
  [SerializeField]
  int price;
  public int Price { get {return price; } set { this.price = value;} }
  
  [SerializeField]
  WeaponType weapontype;
  public WeaponType WEAPONTYPE { get {return weapontype; } set { this.weapontype = value;} }
  
  [SerializeField]
  ItemType itemtype;
  public ItemType ITEMTYPE { get {return itemtype; } set { this.itemtype = value;} }
  
}