using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Shared.MongoEntities
{
    [BsonIgnoreExtraElements]
    public class Matches
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string _id { get; set; }

        [BsonElement("InternalID")]
        public int Id { get; set; }

        [BsonElement("UniqueID")]
        public long UniqueID { get; set; }

        [BsonElement("Event")]
        public Event Event { get; set; } = new Event();

        [BsonElement("Odds")]
        public Odds Odds { get; set; } = new Odds();

        [BsonElement("coverage")]
        public int Coverage { get; set; } = 1;

        [BsonElement("info")]
        public List<Info> Info { get; set; } = new List<Info>();

        [BsonElement("Infos")]
        public List<object> Infos { get; set; } = new List<object>();

        [BsonElement("date")]
        public DateTime? Date { get; set; } = DateTime.Now;

        [BsonElement("cal")]
        public int Cal { get; set; } = 0;

        [BsonElement("UDate")]
        public DateTime UDate { get; set; } = DateTime.Now;

        [BsonElement("updSec")]
        public double updSec { get; set; } = 0;

        [BsonElement("sport")]
        public string Sport { get; set; } = string.Empty;

        [BsonElement("betstart")]
        public string Betstart { get; set; } = string.Empty;

        [BsonElement("b_counter")]
        public int BCounter { get; set; } = 0;

        [BsonElement("counter")]
        public int Counter { get; set; } = 1;

        [BsonElement("IsStopped")]
        public bool IsStopped { get; set; } = false;

        [BsonElement("isNotified")]
        public bool IsNotified { get; set; } = false;

        [BsonElement("FirstInfo")]
        public string FirstInfo { get; set; } = string.Empty;

        [BsonElement("hasData")]
        public bool HasData { get; set; } = false;

        [BsonElement("MatchStartedOn")]
        public DateTime? MatchStartedOn { get; set; }

        [BsonElement("OddsCounter")]
        public int OddsCounter { get; set; } = 1;

        [BsonElement("MessageNo")]
        public int MessageNo { get; set; } = 1;

        [BsonElement("source")]
        public int source { get; set; }

        [BsonElement("hasClosed")]
        public bool HasClosed { get; set; } = false;
    }

    [BsonIgnoreExtraElements]
    public class Event
    {
        [BsonElement("E")]
        public E E { get; set; } = new E();
    }

    [BsonIgnoreExtraElements]
    public class E
    {
        [BsonElement("sentTimeStamp")]
        public string SentTimeStamp { get; set; } = string.Empty;

        [BsonElement("O")]
        public string O { get; set; } = "00:00";

        [BsonElement("TimeStamp")]
        public string TimeStamp { get; set; } = string.Empty;

        [BsonElement("ScoutID")]
        public string ScoutId { get; set; } = "0";

        [BsonElement("PID")]
        public string PID { get; set; } = string.Empty;

        [BsonElement("SID")]
        public string SID { get; set; } = string.Empty;

        [BsonElement("EventID")]
        public int EventID { get; set; } = 0;

        [BsonElement("FI")]
        public string FI { get; set; } = string.Empty;

        [BsonElement("H")]
        public string H { get; set; } = string.Empty;

        [BsonElement("A")]
        public string A { get; set; } = string.Empty;

        [BsonElement("K")]
        public string K { get; set; } = string.Empty;

        [BsonElement("CK")]
        public string CK { get; set; } = string.Empty;

        [BsonElement("TM")]
        public string TM { get; set; } = string.Empty;

        [BsonElement("TMM")]
        public string TMM { get; set; } = string.Empty;

        [BsonElement("S")]
        public string S { get; set; } = "0-0";

        [BsonElement("HTS")]
        public string HTS { get; set; } = "0-0";
        [BsonElement("HTC")]
        public string HTC { get; set; } = "0-0";
        [BsonElement("HT2C")]
        public string HT2C { get; set; } = "0-0";

        [BsonElement("ETS")]
        public string ETS { get; set; } = "0-0";

        [BsonElement("EHTS")]
        public string EHTS { get; set; } = "0-0";

        [BsonElement("FTS")]
        public string FTS { get; set; } = "0-0";

        [BsonElement("PTS")]
        public string PTS { get; set; } = "0-0";

        [BsonElement("SS")]
        public string SS { get; set; } = "0-0";

        [BsonElement("SRV")]
        public string SRV { get; set; } = "1";

        [BsonElement("P")]
        public string P { get; set; } = string.Empty;

        [BsonElement("PS")]
        public string PS { get; set; } = "0-0";

        [BsonElement("EDate")]
        public string EDate { get; set; } = string.Empty;

        [BsonElement("T")]
        public string T { get; set; } = string.Empty;

        [BsonElement("PJ")]
        public string PJ { get; set; } = string.Empty;

        [BsonElement("TID1")]
        public string TID1 { get; set; } = string.Empty;

        [BsonElement("TID2")]
        public string TID2 { get; set; } = string.Empty;

        [BsonElement("KC1")]
        public string KC1 { get; set; } = string.Empty;

        [BsonElement("KC2")]
        public string KC2 { get; set; } = string.Empty;

        [BsonElement("TC1")]
        public string TC1 { get; set; } = string.Empty;

        [BsonElement("TC2")]
        public string TC2 { get; set; } = string.Empty;

        [BsonElement("PStart")]
        public string PStart { get; set; } = string.Empty;

        [BsonElement("TStart")]
        public string TStart { get; set; } = string.Empty;

        [BsonElement("SC1")]
        public string SC1 { get; set; } = string.Empty;

        [BsonElement("SC2")]
        public string SC2 { get; set; } = string.Empty;

        [BsonElement("CornerT1")]
        public string CornerT1 { get; set; } = "0";

        [BsonElement("CornerT2")]
        public string CornerT2 { get; set; } = "0";

        [BsonElement("KV1")]
        public string KV1 { get; set; } = string.Empty;

        [BsonElement("KV2")]
        public string KV2 { get; set; } = string.Empty;

        [BsonElement("KK1")]
        public string KK1 { get; set; } = string.Empty;

        [BsonElement("KK2")]
        public string KK2 { get; set; } = string.Empty;

        [BsonElement("TH1")]
        public string TH1 { get; set; } = string.Empty;

        [BsonElement("TH2")]
        public string TH2 { get; set; } = string.Empty;

        [BsonElement("FK1")]
        public string FK1 { get; set; } = string.Empty;

        [BsonElement("FK2")]
        public string FK2 { get; set; } = string.Empty;

        [BsonElement("GK1")]
        public string GK1 { get; set; } = string.Empty;

        [BsonElement("GK2")]
        public string GK2 { get; set; } = string.Empty;

        [BsonElement("PE1")]
        public string PE1 { get; set; } = string.Empty;

        [BsonElement("PE2")]
        public string PE2 { get; set; } = string.Empty;

        [BsonElement("SU1")]
        public string SU1 { get; set; } = string.Empty;

        [BsonElement("SU2")]
        public string SU2 { get; set; } = string.Empty;

        [BsonElement("MatchType")]
        public string MatchType { get; set; } = "1";

        [BsonElement("history")]
        public string History { get; set; } = string.Empty;

        [BsonElement("remaining_time")]
        public string RemainingTime { get; set; } = string.Empty;

        [BsonElement("remaining_time_period")]
        public string RemainingTimePeriod { get; set; } = string.Empty;

        [BsonElement("bestOfSets")]
        public int BestOfSets { get; set; } = 0;

        [BsonElement("playerRetired")]
        public string PlayerRetired { get; set; } = string.Empty;

        [BsonElement("TieBreak")]
        public bool TieBreak { get; set; } = false;

        [BsonElement("shotsOnTarget")]
        public string ShotsOnTarget { get; set; } = "0-0";

        [BsonElement("matchShots")]
        public string MatchShots { get; set; } = "0-0";
        [BsonElement("total180Score")]
        public string Total180Score { get; set; } = "0-0";

        [BsonElement("tryCount")]
        public string TryCount { get; set; } = "0-0";

        [BsonElement("q1FirstScore")]
        public string Q1FirstScore { get; set; } = "0";
        [BsonElement("q2FirstScore")]
        public string Q2FirstScore { get; set; } = "0";
        [BsonElement("q3FirstScore")]
        public string Q3FirstScore { get; set; } = "0";
        [BsonElement("q4FirstScore")]
        public string Q4FirstScore { get; set; } = "0";

        [BsonElement("q1FirstAction")]
        public string Q1FirstAction { get; set; } = "0";
        [BsonElement("q2FirstAction")]
        public string Q2FirstAction { get; set; } = "0";
        [BsonElement("q3FirstAction")]
        public string Q3FirstAction { get; set; } = "0";
        [BsonElement("q4FirstAction")]
        public string Q4FirstAction { get; set; } = "0";
        [BsonElement("behindCount")]
        public string BehindCount { get; set; } = "0-0";
        [BsonElement("totalAces")]
        public string TotalAces { get; set; } = "0-0";
        [BsonElement("totalDoubleFault")]
        public string TotalDoubleFault { get; set; } = "0-0";

        [BsonElement("tieBreakCount")]
        public string TieBreakCount { get; set; } = "0";

        [BsonElement("h1TryCount")]
        public string H1TryCount { get; set; } = "0-0";

        [BsonElement("h2TryCount")]
        public string H2TryCount { get; set; } = "0-0";

        [BsonElement("totalBreakScore")]
        public string TotalBreakScore { get; set; } = "0-0";

        [BsonElement("tieBreakScore")]
        public string TieBreakScore { get; set; } = "0-0";

        [BsonElement("InningsNo")]
        public int InningsNo { get; set; } = 0; // 1, 2, 3, 4

        [BsonElement("BattingTeam")]
        public int BattingTeam { get; set; } = 0; // home or away

        [BsonElement("Runs")]
        public int Runs { get; set; } = 0;

        [BsonElement("Wickets")]
        public int Wickets { get; set; } = 0;

        [BsonElement("Overs")]
        public int Overs { get; set; } = 0;

        [BsonElement("Balls")]
        public int Balls { get; set; } = 0; // home or away

        [BsonElement("CrOvers")]
        public int CrOvers { get; set; } = 0;

        [BsonElement("Delivery")]
        public int Delivery { get; set; } = 0;

        [BsonElement("Lst6D")]
        public List<Last6Deliveries> Last6Deliveries { get; set; } = new List<Last6Deliveries>();

        [BsonElement("CricketScoreBoard")]
        public CricketDetail CricketScoreBoard { get; set; } = null;


    }

    [BsonIgnoreExtraElements]
    public class Info
    {
        [BsonElement("minute")]
        public int Minute { get; set; } = 0;

        [BsonElement("I")]
        public string I { get; set; } = string.Empty;

        [BsonElement("IC")]
        public string IC { get; set; } = string.Empty;

        [BsonElement("player")]
        public string Player { get; set; } = "0";

        [BsonElement("oldPlayer")]
        public string OldPlayer { get; set; } = "0";

        [BsonElement("totalGoals")]
        public string TotalGoals { get; set; } = string.Empty;

        [BsonElement("oldTotalGoals")]
        public string OldTotalGoals { get; set; } = string.Empty;

        [BsonElement("totalGoalsET")]
        public string TotalGoalsET { get; set; } = string.Empty;

        [BsonElement("oldTotalGoalsET")]
        public string OldTotalGoalsET { get; set; } = string.Empty;

        [BsonElement("totalCorners")]
        public string TotalCorners { get; set; } = string.Empty;

        [BsonElement("totalCornersET")]
        public string TotalCornersET { get; set; } = string.Empty;

        [BsonElement("oldTotalCornersET")]
        public string OldTotalCornersET { get; set; } = string.Empty;

        [BsonElement("totalCards")]
        public string TotalCards { get; set; } = string.Empty;

        [BsonElement("totalFreeKicks")]
        public string TotalFreeKicks { get; set; } = string.Empty;

        [BsonElement("totalGoalKicks")]
        public string TotalGoalKicks { get; set; } = string.Empty;

        [BsonElement("totalThrowIns")]
        public string TotalThrowIns { get; set; } = string.Empty;

        [BsonElement("oldTotalCorners")]
        public string OldTotalCorners { get; set; } = string.Empty;

        [BsonElement("totalYellow")]
        public string TotalYellow { get; set; } = string.Empty;

        [BsonElement("totalYellowET")]
        public string TotalYellowET { get; set; } = string.Empty;

        [BsonElement("oldTotalYellow")]
        public string OldTotalYellow { get; set; } = string.Empty;

        [BsonElement("oldTotalYellowET")]
        public string OldTotalYellowET { get; set; } = string.Empty;

        [BsonElement("totalRed")]
        public string TotalRed { get; set; } = string.Empty;

        [BsonElement("totalRedET")]
        public string TotalRedET { get; set; } = string.Empty;

        [BsonElement("oldTotalRed")]
        public string OldTotalRed { get; set; } = string.Empty;

        [BsonElement("oldTotalRedET")]
        public string OldTotalRedET { get; set; } = string.Empty;

        [BsonElement("totalPenalty")]
        public string TotalPenalty { get; set; } = string.Empty;

        [BsonElement("totalScoredPenalty")]
        public string TotalScoredPenalty { get; set; } = string.Empty;

        [BsonElement("totalMissedPenalty")]
        public string TotalMissedPenalty { get; set; } = string.Empty;

        [BsonElement("oldTotalScoredPenalty")]
        public string OldTotalScoredPenalty { get; set; } = string.Empty;

        [BsonElement("oldTotalMissedPenalty")]
        public string OldTotalMissedPenalty { get; set; } = string.Empty;

        [BsonElement("PenaltyShootoutScore")]
        public string PenaltyShootoutScore { get; set; } = string.Empty;

        [BsonElement("PenaltyShootoutTotal")]
        public string PenaltyShootoutTotal { get; set; } = string.Empty;

        [BsonElement("actionType")]
        public string ActionType { get; set; } = string.Empty;

        [BsonElement("BInfoID")]
        public string BInfoID { get; set; } = string.Empty;

        [BsonElement("UDate")]
        public DateTime UDate { get; set; } = DateTime.Now;

        [BsonElement("CreatedOn")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [BsonElement("ProcessOn")]
        public DateTime ProcessOn { get; set; } = DateTime.Now.AddMinutes(5);

        [BsonElement("game")]
        public int Game { get; set; } = 0;

        [BsonElement("setGame")]
        public int SetGame { get; set; } = 0;

        [BsonElement("goal")]
        public int Goal { get; set; } = 0;

        [BsonElement("inning")]
        public int Inning { get; set; } = 0;

        [BsonElement("extraInning")]
        public int ExtraInning { get; set; } = 0;

        [BsonElement("frame")]
        public int Frame { get; set; } = 0;

        [BsonElement("quarter")]
        public int Quarter { get; set; } = 0;

        [BsonElement("half")]
        public int Half { get; set; } = 0;

        [BsonElement("set")]
        public int Set { get; set; } = 0;

        [BsonElement("leg")]
        public int Leg { get; set; } = 0;

        [BsonElement("seq")]
        public int Seq { get; set; } = 0;

        [BsonElement("oldTotalScore")]
        public string OldTotalScore { get; set; } = string.Empty;
        [BsonElement("totalScore")]
        public string TotalScore { get; set; } = string.Empty;
        [BsonElement("totalInnRuns")]
        public string TotalInnRuns { get; set; } = string.Empty;
        [BsonElement("totalInnHits")]
        public string TotalInnHits { get; set; } = string.Empty;
        [BsonElement("totalHits")]
        public string TotalHits { get; set; } = string.Empty;

        [BsonElement("totalSetScore")]
        public string TotalSetScore { get; set; } = string.Empty;

        [BsonElement("total1HTSetScore")]
        public string Total1HTSetScore { get; set; } = string.Empty;

        [BsonElement("total2HTSetScore")]
        public string Total2HTSetScore { get; set; } = string.Empty;

        [BsonElement("totalPoints")]
        public string TotalPoints { get; set; } = string.Empty;
        [BsonElement("totalHalfPoints")]
        public string TotalHalfPoints { get; set; } = string.Empty;
        [BsonElement("oldTotalPoints")]
        public string OldTotalPoints { get; set; } = string.Empty;
        [BsonElement("oldTotalHalfPoints")]
        public string OldTotalHalfPoints { get; set; } = string.Empty;
        [BsonElement("pointsScored")]
        public string PointsScored { get; set; } = string.Empty;

        [BsonElement("totalPointsHome")]
        public string TotalPointsHome { get; set; } = string.Empty;
        [BsonElement("totalHalfPointsHome")]
        public string TotalHalfPointsHome { get; set; } = string.Empty;

        [BsonElement("totalPointsAway")]
        public string TotalPointsAway { get; set; } = string.Empty;
        [BsonElement("totalHalfPointsAway")]
        public string TotalHalfPointsAway { get; set; } = string.Empty;

        [BsonElement("totalPointsPartial")]
        public string TotalPointsPartial { get; set; } = string.Empty;

        [BsonElement("totalPointsPartialHome")]
        public string TotalPointsPartialHome { get; set; } = string.Empty;

        [BsonElement("totalPointsPartialAway")]
        public string TotalPointsPartialAway { get; set; } = string.Empty;

        [BsonElement("overTimeTotalScore")]
        public string OverTimeTotalScore { get; set; } = string.Empty;

        [BsonElement("status")]
        public int Status { get; set; } = 0;

        [BsonElement("tieBreak")]
        public int TieBreak { get; set; } = 0;

        [BsonElement("overtimeIncluded")]
        public string OvertimeIncluded { get; set; } = string.Empty;

        [BsonElement("totalScoreOT")]
        public string TotalScoreOt { get; set; } = string.Empty;

        [BsonElement("minFrom")]
        public string MinFrom { get; set; } = string.Empty;

        [BsonElement("minTo")]
        public string MinTo { get; set; } = string.Empty;

        [BsonElement("lastGoal")]
        public string LastGoal { get; set; } = "0";

        [BsonElement("lastCorner")]
        public string LastCorner { get; set; } = "0";

        [BsonElement("lastYellow")]
        public string LastYellow { get; set; } = "0";

        [BsonElement("lastRed")]
        public string LastRed { get; set; } = "0";

        [BsonElement("method")]
        public string Method { get; set; } = string.Empty;

        [BsonElement("Calculated")]
        public bool Calculated { get; set; } = false;

        [BsonElement("isPenalty")]
        public bool IsPenalty { get; set; } = false;

        [BsonElement("overtime")]
        public bool Overtime { get; set; } = false;

        [BsonElement("isDeleted")]
        public bool IsDeleted { get; set; } = false;

        [BsonElement("isProcessed")]
        public bool IsProcessed { get; set; } = false;

        [BsonElement("bestOfSets")]
        public int BestOfSets { get; set; } = 0;

        [BsonElement("SDate")]
        public string SDate { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

        [BsonElement("minseq")]
        public string MinSeq { get; set; }

        [BsonElement("updatedFrom")]
        public int UpdatedFrom { get; set; } = 0;

        [BsonElement("wonWithBreak")]
        public bool WonWithBreak { get; set; } = false;
        [BsonElement("setLeadAfter")]
        public string SetLeadAfter { get; set; } = string.Empty;
        [BsonElement("totalBreakScore")]
        public string TotalBreakScore { get; set; } = string.Empty;

        [BsonElement("clearedScore")]
        public string ClearedScore { get; set; } = string.Empty;

        [BsonElement("totalCheckoutScore")]
        public string TotalCheckoutScore { get; set; } = string.Empty;

        [BsonElement("total180Score")]
        public string Total180Score { get; set; } = string.Empty;

        [BsonElement("tryCount")]
        public string TryCount { get; set; } = string.Empty;

        [BsonElement("SRV")]
        public string SRV { get; set; } = string.Empty;

        [BsonElement("LastPenaltyShoot")]
        public string LastPenaltyShoot { get; set; } = string.Empty;
    }

    [BsonIgnoreExtraElements]
    public class Odds
    {
        [BsonElement("Games")]
        public Games Games { get; set; } = new Games();
    }

    [BsonIgnoreExtraElements]
    public class Games
    {
        [BsonElement("G")]
        public List<G> G { get; set; } = new List<G>();
    }

    [BsonIgnoreExtraElements]
    public class G
    {
        [BsonElement("V")]
        public string V { get; set; } = string.Empty;

        [BsonElement("N")]
        public string N { get; set; } = string.Empty;

        [BsonElement("GrpID")]
        public string GrpID { get; set; } = string.Empty;

        [BsonElement("R")]
        public List<R> R { get; set; } = new List<R>();

        [BsonElement("CreatedOn")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [BsonElement("UpdatedOn")]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }

    [BsonIgnoreExtraElements]
    public class R
    {
        [BsonElement("V")]
        public string V { get; set; } = string.Empty;

        [BsonElement("N")]
        public string N { get; set; } = string.Empty;

        [BsonElement("O0")]
        public string O0 { get; set; } = string.Empty;

        [BsonElement("CreatedOn")]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [BsonElement("UpdatedOn")]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }

    [BsonIgnoreExtraElements]
    public class Last6Deliveries
    {
        public int DeliveryNo { get; set; }
        public string Event { get; set; }
        public int Over { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

    [BsonIgnoreExtraElements]
    public class CricketDetail
    {
        public List<Cricket_TeamDetail> Home { get; set; } = new List<Cricket_TeamDetail>();
        public List<Cricket_TeamDetail> Away { get; set; } = new List<Cricket_TeamDetail>();
    }

    [BsonIgnoreExtraElements]
    public class Cricket_TeamDetail
    {
        public bool IsTestMatch { get; set; } = false;
        public string InningsNo { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public string Score { get; set; } = string.Empty;
        public int? Over { get; set; }
        public int? Balls { get; set; }
        public int? CrOver { get; set; }
        public int? Delivery { get; set; }
        public List<Last6Deliveries> Last6Deliveries { get; set; } = new List<Last6Deliveries>();
        public List<Cricket_Batsmen> Batting { get; set; } = new List<Cricket_Batsmen>();
        public List<Cricket_FOW> FallOfWickets { get; set; } = new List<Cricket_FOW>();
        public List<Cricket_Overs> Overs { get; set; } = new List<Cricket_Overs>();
        public List<Cricket_Players> Players { get; set; } = new List<Cricket_Players>();
    }

    [BsonIgnoreExtraElements]
    public class Cricket_Batsmen
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public bool IsOut { get; set; }
        public int R { get; set; }
        public int B { get; set; }
        public int F { get; set; }
        public int S { get; set; }
        public float SR { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Cricket_FOW
    {
        public int Runs { get; set; }
        public int WicketNo { get; set; }
        public string PlayerName { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Cricket_Overs
    {
        [BsonElement("No")]
        public int OverNo { get; set; }

        [BsonElement("OR")]
        public int OverRuns { get; set; }

        [BsonElement("R")]
        public int Runs { get; set; }

        [BsonElement("W")]
        public int Wickets { get; set; }

        [BsonElement("S")]
        public string Score { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Cricket_Players
    {
        public int ID { get; set; }
        public string PlayerName { get; set; }
    }

}
