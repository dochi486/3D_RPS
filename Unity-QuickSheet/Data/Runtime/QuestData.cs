using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
/// 
[System.Serializable]
public class QuestData
{
  [SerializeField]
  int id;
  public int ID { get {return id; } set { this.id = value;} }
  
  [SerializeField]
  string title;
  public string Title { get {return title; } set { this.title = value;} }
  
  [SerializeField]
  string description;
  public string Description { get {return description; } set { this.description = value;} }
  
  [SerializeField]
  string requirement;
  public string Requirement { get {return requirement; } set { this.requirement = value;} }
  
  [SerializeField]
  string difficulty;
  public string Difficulty { get {return difficulty; } set { this.difficulty = value;} }
  
  [SerializeField]
  int level;
  public int Level { get {return level; } set { this.level = value;} }
  
  [SerializeField]
  int rewardexp;
  public int Rewardexp { get {return rewardexp; } set { this.rewardexp = value;} }
  
  [SerializeField]
  int rewardgold;
  public int Rewardgold { get {return rewardgold; } set { this.rewardgold = value;} }
  
  [SerializeField]
  int rewarditemid;
  public int Rewarditemid { get {return rewarditemid; } set { this.rewarditemid = value;} }
  
  [SerializeField]
  QuestType questtype;
  public QuestType QUESTTYPE { get {return questtype; } set { this.questtype = value;} }
  
}