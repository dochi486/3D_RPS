using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
/// 
[System.Serializable]
public class ChallengeData
{
  [SerializeField]
  int id;
  public int ID { get {return id; } set { this.id = value;} }
  
  [SerializeField]
  string title;
  public string Title { get {return title; } set { this.title = value;} }
  
  [SerializeField]
  string condition;
  public string Condition { get {return condition; } set { this.condition = value;} }
  
  [SerializeField]
  float reward;
  public float Reward { get {return reward; } set { this.reward = value;} }
  
  [SerializeField]
  float goalcount;
  public float Goalcount { get {return goalcount; } set { this.goalcount = value;} }
  
  [SerializeField]
  RewardType rewardtype;
  public RewardType REWARDTYPE { get {return rewardtype; } set { this.rewardtype = value;} }
  
}