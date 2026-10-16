using System;
using System.Collections;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;
using Google.Protobuf.Collections;
using War.Client;
using War.Protocol;

public class ScoreManager : Singleton<ScoreManager>
{
    private const float KillStreakThreshold = 100f;

	public AudioClip skillStreakSound;

	private ObscuredInt mScore;

	private int mCoopOtherPlayerScore;

	public float killsStreakProgressLoss = 1f;

	public float killStreakScoreRatio = 0.1f;

	public bool isNewKillStreak;

	public ObscuredInt gotWarbucksBoxes;

	public ObscuredInt gotGoldBoxes;

	public Dictionary<SkillShot.SkillShotType, int> skillShotCounts = new Dictionary<SkillShot.SkillShotType, int>();

	public Dictionary<SkillShot.SkillShotType, int> skillShotCountsOponent = new Dictionary<SkillShot.SkillShotType, int>();

	private int mLastScore;

	private float mTimeFromStart;

	private int mTenSeconds;

	private List<int> mKilledEnemiesInXSeconds = new List<int>();

	private List<int> mScoreOverTime = new List<int>();

	private Dictionary<Type, int> mUnitsKilled = new Dictionary<Type, int>();

	private int mLastScoreReported;

	private PhotonView mPhotonView;

    private bool _hasSelfHostedScore;

    private bool IsSelfHostedScoreActive
    {
        get { return _hasSelfHostedScore || IsSelfHostedPvp || IsSelfHostedCoopScore; }
    }

    private static bool IsSelfHostedPvp
    {
        get
        {
            SelfHostedBattleClient client = SelfHostedBattleClient.Active;
            return client != null && client.OwnsMatch && (client.State == null || client.State.Coop == null);
        }
    }

    private static bool IsSelfHostedCoopScore
    {
        get
        {
            SelfHostedBattleClient client = SelfHostedBattleClient.Active;
            return client != null && client.OwnsMatch && client.State != null && client.State.Coop != null &&
                client.State.Coop.MissionType == "Score";
        }
    }

    /// <summary>Replaces supported presentation state with one validated host snapshot.</summary>
    public void ApplySelfHostedSnapshot(MatchSnapshot snapshot, string localPlayerId)
    {
        BattleScoreSnapshotPolicy.Validate(snapshot);
        if (snapshot.Coop != null)
        {
            if (snapshot.Coop.MissionType == "Score")
            {
                ApplySelfHostedCoopScore(snapshot, localPlayerId);
            }

            return;
        }

        BattlePlayerState local;
        BattlePlayerState other;
        ResolveHostParticipants(snapshot, localPlayerId, out local, out other);

        bool isTerminal = snapshot.Phase == BattlePhase.Ended || snapshot.Phase == BattlePhase.Aborted;
        Dictionary<SkillShot.SkillShotType, int> localCounts = skillShotCounts;
        Dictionary<SkillShot.SkillShotType, int> otherCounts = skillShotCountsOponent;
        if (isTerminal)
        {
            localCounts = ReadHostCounts(local.SkillShotCounts, skillShotCounts);
            otherCounts = ReadHostCounts(other.SkillShotCounts, skillShotCountsOponent);
        }

        _hasSelfHostedScore = true;
        mScore = local.Score;
        opponentScore = other.Score;
        killStreakProgress = local.KillStreakProgress;
        killStreakProgressOpponent = other.KillStreakProgress;
        skillShotCounts = localCounts;
        skillShotCountsOponent = otherCounts;
    }

    private void ApplySelfHostedCoopScore(MatchSnapshot snapshot, string localPlayerId)
    {
        CoopScoreProjection projection = CoopScoreProjection.ForPlayer(snapshot, localPlayerId);
        _hasSelfHostedScore = true;
        mScore = projection.LocalScore;
        mCoopOtherPlayerScore = projection.PeerScore;
        opponentScore = projection.PeerScore;
        killStreakProgress = 0f;
        killStreakProgressOpponent = 0f;
    }

    private static void ResolveHostParticipants(MatchSnapshot snapshot, string localPlayerId,
        out BattlePlayerState local, out BattlePlayerState other)
    {
        local = null;
        other = null;
        foreach (BattlePlayerState player in snapshot.Players)
        {
            if (player.PlayerId == localPlayerId)
            {
                local = player;
            }
            else
            {
                other = player;
            }
        }

        if (local == null || other == null)
        {
            throw new InvalidOperationException("Host scores do not identify the local participant.");
        }
    }

    private static Dictionary<SkillShot.SkillShotType, int> ReadHostCounts(
        RepeatedField<BattleSkillShotCount> counts, Dictionary<SkillShot.SkillShotType, int> template)
    {
        var result = new Dictionary<SkillShot.SkillShotType, int>();
        foreach (SkillShot.SkillShotType flag in template.Keys)
        {
            result.Add(flag, 0);
        }

        foreach (BattleSkillShotCount count in counts)
        {
            result[(SkillShot.SkillShotType)count.Flag] = checked((int)count.Count);
        }

        return result;
    }

	public int score
	{
		get
		{
			return mScore;
		}
		set
		{
            if (!IsSelfHostedScoreActive)
            {
                mScore = value;
            }
		}
	}

	public int scoreCoop => score + mCoopOtherPlayerScore;

	public float killStreakProgress { get; private set; }

	public float killStreakProgressOpponent { get; private set; }

	public int opponentScore { get; private set; }

	public float bonusMultiplier { get; set; }

	public float bonusMultiplierEnemy { get; set; }

	public int enemiesKilledAllTypes
	{
		get
		{
			int num = 0;
			foreach (KeyValuePair<Type, int> item in mUnitsKilled)
			{
				num += item.Value;
			}
			return num;
		}
	}

	public event Action<int, int> ScoreChanged;

	public int GetUnitKilledCount(string unitName)
	{
		if (!Mission.behavioursDictionary.ContainsKey(unitName))
		{
			return 0;
		}
		Type value = Mission.behavioursDictionary[unitName].Value1;
		if (mUnitsKilled.ContainsKey(value))
		{
			return mUnitsKilled[value];
		}
		return 0;
	}

	protected override void Awake()
	{
		base.Awake();
		mPhotonView = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameEnded += InstanceOnGameEnded;
		Singleton<GameController>.instance.BeforeGameStarted += Restart;
        SelfHostedBattleClient client = SelfHostedBattleClient.Active;
        if (client != null && client.OwnsMatch)
        {
            client.BindScoreManager(this);
        }
	}

	private void InstanceOnGameEnded(GameController.GameEndReason gameEndReason)
	{
        if (IsSelfHostedScoreActive)
        {
            return;
        }
		mPhotonView.RPC("RecieveOponentScore", PhotonTargets.Others, score);
		foreach (KeyValuePair<SkillShot.SkillShotType, int> skillShotCount in skillShotCounts)
		{
			mPhotonView.RPC("RecieveSkillShotsCount", PhotonTargets.Others, (int)skillShotCount.Key, skillShotCount.Value);
		}
	}

	protected override void Start()
	{
		base.Start();
		AIObject.AIObjectKilled += OnAiObjectKilled;
		StartCoroutine(CheckForScoreChange());
	}

	private void OnAiObjectKilled(AIObject aiObject, DestroyableObject.DamageInfo damageInfo)
	{
		if (PlayerController.currentPlayer.fraction != aiObject.fraction && !(aiObject.behaviour == null))
		{
			if (mUnitsKilled.ContainsKey(aiObject.behaviour.GetType()))
			{
				int value = mUnitsKilled[aiObject.behaviour.GetType()] + 1;
				mUnitsKilled[aiObject.behaviour.GetType()] = value;
			}
			else
			{
				mUnitsKilled.Add(aiObject.behaviour.GetType(), 1);
			}
			List<int> list2;
			List<int> list = (list2 = mKilledEnemiesInXSeconds);
			int index2;
			int index = (index2 = mTenSeconds);
			index2 = list2[index2];
			list[index] = index2 + 1;
		}
	}

	public void Restart()
	{
        _hasSelfHostedScore = IsSelfHostedPvp || IsSelfHostedCoopScore;
		isNewKillStreak = false;
		mLastScore = 0;
		mScore = 0;
		killStreakProgress = 0f;
		killStreakProgressOpponent = 0f;
		gotGoldBoxes = 0;
		gotWarbucksBoxes = 0;
		mLastScoreReported = 0;
		opponentScore = 0;
		skillShotCounts = new Dictionary<SkillShot.SkillShotType, int>();
		skillShotCountsOponent = new Dictionary<SkillShot.SkillShotType, int>();
		mTimeFromStart = 0f;
		mTenSeconds = 0;
		mKilledEnemiesInXSeconds = new List<int>();
		mKilledEnemiesInXSeconds.Add(0);
		mScoreOverTime = new List<int>();
		mScoreOverTime.Add(0);
		mUnitsKilled.Clear();
		mCoopOtherPlayerScore = 0;
		foreach (SkillShotManager.SkillShotItemDefinition skillShotItemDefinition in Singleton<SkillShotManager>.instance.skillShotItemDefinitions)
		{
			skillShotCounts.Add(skillShotItemDefinition.skillShotType, 0);
			skillShotCountsOponent.Add(skillShotItemDefinition.skillShotType, 0);
		}
		killStreakScoreRatio = ((!Singleton<GameController>.instance.isMission) ? Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio).FLOATVALUE : Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio).FLOATVALUE);
		if (!Singleton<GameController>.instance.mainController.dropCreates)
		{
			killStreakScoreRatio = 0f;
		}
		bonusMultiplier = 1f;
		bonusMultiplierEnemy = 1f;
        SelfHostedBattleClient client = SelfHostedBattleClient.Active;
        if ((IsSelfHostedPvp || IsSelfHostedCoopScore) && client.State != null)
        {
            ApplySelfHostedSnapshot(client.State, client.LocalPlayerId);
        }
	}

	private IEnumerator CheckForScoreChange()
	{
		while (true)
		{
			if (score != mLastScoreReported)
			{
				if (this.ScoreChanged != null)
				{
					this.ScoreChanged(score, score - mLastScoreReported);
				}
				mLastScoreReported = score;
			}
			yield return new WaitForSeconds(1f);
		}
	}

	[PunRPC]
	private void RecieveOponentScore(int score)
	{
        if (IsSelfHostedScoreActive)
        {
            return;
        }
		opponentScore = score;
		Debug.Log("score recieved");
	}

	[PunRPC]
	private void RecieveSkillShotsCount(int skillShot, int skillshotCount)
	{
        if (IsSelfHostedScoreActive)
        {
            return;
        }
		skillShotCountsOponent[(SkillShot.SkillShotType)skillShot] = skillshotCount;
	}

	protected void Update()
	{
		if (Singleton<GameController>.instance.gameIsRunning)
		{
            AdvanceLocalStreak();
			mTimeFromStart += Time.deltaTime;
			if (mTimeFromStart > 10f)
			{
				mTimeFromStart -= 10f;
				mTenSeconds++;
				mKilledEnemiesInXSeconds.Add(0);
				mScoreOverTime.Add(score);
			}
		}
	}

    private void AdvanceLocalStreak()
    {
        if (IsSelfHostedScoreActive)
        {
            return;
        }

        killStreakProgress -= Time.deltaTime * killsStreakProgressLoss;
        killStreakProgress = Mathf.Clamp(killStreakProgress, 0f, float.PositiveInfinity);
        if (killStreakProgress > KillStreakThreshold)
        {
            killStreakProgress -= KillStreakThreshold;
            isNewKillStreak = true;
            Singleton<KillStreakManager>.instance.GenerateNewBonus(PlayerController.currentPlayer);
            SoundsManager.Instance.PlaySound(skillStreakSound);
        }

        killStreakProgressOpponent -= Time.deltaTime * killsStreakProgressLoss;
        killStreakProgressOpponent = Mathf.Clamp(killStreakProgressOpponent, 0f, float.PositiveInfinity);
        if (killStreakProgressOpponent > KillStreakThreshold)
        {
            killStreakProgressOpponent -= KillStreakThreshold;
            Singleton<KillStreakManager>.instance.GenerateNewBonus(Singleton<GameController>.instance.opponent);
        }
    }

	private void LateUpdate()
	{
        if (IsSelfHostedScoreActive)
        {
            return;
        }
		if ((Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot) && mLastScore != score)
		{
			mPhotonView.RPC("AddCoopScoreRPC", PhotonTargets.Others, score - mLastScore);
			mLastScore = score;
		}
	}

	[PunRPC]
	private void AddCoopScoreRPC(int scoreToAdd)
	{
        if (IsSelfHostedScoreActive)
        {
            return;
        }
		mCoopOtherPlayerScore += scoreToAdd;
	}

	public void AddSkillshot(SkillShotManager.SkillShotItemDefinition def, PlayerController playerController)
	{
        if (IsSelfHostedScoreActive)
        {
            return;
        }
		if (playerController.isCurrentPlayer && skillShotCounts.ContainsKey(def.skillShotType))
		{
			Dictionary<SkillShot.SkillShotType, int> dictionary2;
			Dictionary<SkillShot.SkillShotType, int> dictionary = (dictionary2 = skillShotCounts);
			SkillShot.SkillShotType skillShotType;
			SkillShot.SkillShotType key = (skillShotType = def.skillShotType);
			int num = dictionary2[skillShotType];
			dictionary[key] = num + 1;
			score += def.points;
			killStreakProgress += (float)def.points * killStreakScoreRatio * bonusMultiplier;
		}
		if (!playerController.isCurrentPlayer && skillShotCountsOponent.ContainsKey(def.skillShotType))
		{
			Dictionary<SkillShot.SkillShotType, int> dictionary4;
			Dictionary<SkillShot.SkillShotType, int> dictionary3 = (dictionary4 = skillShotCountsOponent);
			SkillShot.SkillShotType skillShotType;
			SkillShot.SkillShotType key2 = (skillShotType = def.skillShotType);
			int num = dictionary4[skillShotType];
			dictionary3[key2] = num + 1;
			opponentScore += def.points;
			killStreakProgressOpponent += (float)def.points * killStreakScoreRatio * bonusMultiplierEnemy;
		}
	}

	public int EnemiesKilledInFirstSeconds(int seconds)
	{
		int num = 0;
		int num2 = seconds / 10;
		if (mKilledEnemiesInXSeconds.Count < num2)
		{
			num2 = mKilledEnemiesInXSeconds.Count;
		}
		for (int i = 0; i < num2; i++)
		{
			num += mKilledEnemiesInXSeconds[i];
		}
		return num;
	}

	public int ScoreOverSeconds(int wantedScore, int seconds)
	{
		if (seconds < 60)
		{
			return 0;
		}
		int num = seconds / 60;
		if (mScoreOverTime.Count <= num * 6 + 1)
		{
			return score;
		}
		int num2 = mScoreOverTime[num * 6 + 1];
		if (num2 > wantedScore)
		{
			return num2;
		}
		int num3 = mScoreOverTime.Count - num * 6;
		for (int i = 0; i < num3; i++)
		{
			if (num2 < mScoreOverTime[num * 6 + i] - mScoreOverTime[i])
			{
				num2 = mScoreOverTime[num * 6 + i] - mScoreOverTime[i];
				if (num2 > wantedScore)
				{
					return num2;
				}
			}
		}
		return num2;
	}

	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
        if (IsSelfHostedScoreActive)
        {
            return;
        }
		if (stream.isWriting)
		{
			stream.SendNext(score);
		}
		else
		{
			opponentScore = (int)stream.ReceiveNext();
		}
	}
}
