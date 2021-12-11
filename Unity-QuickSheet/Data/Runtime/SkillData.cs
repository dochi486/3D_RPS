using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
/// 
[System.Serializable]
public class SkillData
{
  [SerializeField]
  int skillid;
  public int Skillid { get {return skillid; } set { this.skillid = value;} }
  
  [SerializeField]
  string name;
  public string Name { get {return name; } set { this.name = value;} }
  
  [SerializeField]
  string description;
  public string Description { get {return description; } set { this.description = value;} }
  
  [SerializeField]
  int cooltime;
  public int Cooltime { get {return cooltime; } set { this.cooltime = value;} }
  
  [SerializeField]
  string iconname;
  public string Iconname { get {return iconname; } set { this.iconname = value;} }
  
  [SerializeField]
  SkillType skilltype;
  public SkillType SKILLTYPE { get {return skilltype; } set { this.skilltype = value;} }
  
}