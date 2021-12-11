using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum RewardType
{
    HP,
    Shield,
    FireRate,
    Attack
}

public class ChallengeDB : SingletonMonoBehaviour<ChallengeDB>
{
    public Challenge challengeData;
    [SerializeField] List<ChallengeData> challengeList;
    [SerializeField] Dictionary<int, ChallengeData> challengeMap;

    new protected void Awake()
    {
        base.Awake();
        challengeList = challengeData.dataArray.ToList();
        challengeMap = challengeList.ToDictionary(x => x.ID);
    }

    internal static ChallengeData GetChallengeData(int challengeID)
    {
        if (Instance.challengeMap.TryGetValue(challengeID, out ChallengeData result) == false)
            Debug.LogError($"{challengeID}가 없습니다.");
        return result;
    }

    internal List<ChallengeData> GetChallengeDatas(List<int> challengeIDs)
    {
        List<ChallengeData> result = new List<ChallengeData>(challengeIDs.Count);

        foreach (var item in challengeIDs)
        {
            result.Add(GetChallengeData(item));
        }
        return result;
    }
}
