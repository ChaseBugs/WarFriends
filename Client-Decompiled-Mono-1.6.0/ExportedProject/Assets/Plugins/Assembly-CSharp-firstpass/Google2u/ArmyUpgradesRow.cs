using System;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class ArmyUpgradesRow : IGoogle2uRow
	{
		public string NAME;

		public int UNLOCKLEVEL;

		public ObscuredInt PRICE;

		public int CANBEBOUGHT;

		public ObscuredInt PRICEGOLD;

		public ObscuredInt TOTALPOWER;

		public ObscuredFloat COOLDOWN;

		public int DANGERCOEFICIENT;

		public int DELIVERTIME;

		public int STARTINGTIER;

		public int STARTINGLEVEL;

		public int STARTINGSPECIAL;

		public int STARTINGELITE;

		public ObscuredFloat BULLETSPEED;

		public ObscuredFloat PLAYERBEHINDSHIELDDMGRATIO;

		public ObscuredFloat PLAYERDAMAGERATIO;

		public ObscuredFloat PLAYERDAMAGEOVERTIMERATIO;

		public int UNITTYPE;

		public string SPAWNS;

		public ObscuredFloat MOVEMENTSPEED;

		public float COOPHP;

		public float COOPDAMAGE;

		public float BOSSHP;

		public float BOSSDAMAGE;

		public float UNITINMECHANICALRESPAWN;

		public int CLIENTID;

		public float HITSHIELDPROB;

		public int UNLOCKTIER2;

		public int UNLOCKTIER3;

		public int UNLOCKTIER4;

		public int UNLOCKTIER5;

		public int UNLOCKTIER6;

		public bool ISVETERAN;

		public string Get_NAME
		{
			get
			{
				return NAME;
			}
			set
			{
				NAME = value;
			}
		}

		public int Get_UNLOCKLEVEL
		{
			get
			{
				return UNLOCKLEVEL;
			}
			set
			{
				UNLOCKLEVEL = value;
			}
		}

		public ObscuredInt Get_PRICE
		{
			get
			{
				return PRICE;
			}
			set
			{
				PRICE = value;
			}
		}

		public int Get_CANBEBOUGHT
		{
			get
			{
				return CANBEBOUGHT;
			}
			set
			{
				CANBEBOUGHT = value;
			}
		}

		public ObscuredInt Get_PRICEGOLD
		{
			get
			{
				return PRICEGOLD;
			}
			set
			{
				PRICEGOLD = value;
			}
		}

		public ObscuredInt Get_TOTALPOWER
		{
			get
			{
				return TOTALPOWER;
			}
			set
			{
				TOTALPOWER = value;
			}
		}

		public ObscuredFloat Get_COOLDOWN
		{
			get
			{
				return COOLDOWN;
			}
			set
			{
				COOLDOWN = value;
			}
		}

		public int Get_DANGERCOEFICIENT
		{
			get
			{
				return DANGERCOEFICIENT;
			}
			set
			{
				DANGERCOEFICIENT = value;
			}
		}

		public int Get_DELIVERTIME
		{
			get
			{
				return DELIVERTIME;
			}
			set
			{
				DELIVERTIME = value;
			}
		}

		public int Get_STARTINGTIER
		{
			get
			{
				return STARTINGTIER;
			}
			set
			{
				STARTINGTIER = value;
			}
		}

		public int Get_STARTINGLEVEL
		{
			get
			{
				return STARTINGLEVEL;
			}
			set
			{
				STARTINGLEVEL = value;
			}
		}

		public int Get_STARTINGSPECIAL
		{
			get
			{
				return STARTINGSPECIAL;
			}
			set
			{
				STARTINGSPECIAL = value;
			}
		}

		public int Get_STARTINGELITE
		{
			get
			{
				return STARTINGELITE;
			}
			set
			{
				STARTINGELITE = value;
			}
		}

		public ObscuredFloat Get_BULLETSPEED
		{
			get
			{
				return BULLETSPEED;
			}
			set
			{
				BULLETSPEED = value;
			}
		}

		public ObscuredFloat Get_PLAYERBEHINDSHIELDDMGRATIO
		{
			get
			{
				return PLAYERBEHINDSHIELDDMGRATIO;
			}
			set
			{
				PLAYERBEHINDSHIELDDMGRATIO = value;
			}
		}

		public ObscuredFloat Get_PLAYERDAMAGERATIO
		{
			get
			{
				return PLAYERDAMAGERATIO;
			}
			set
			{
				PLAYERDAMAGERATIO = value;
			}
		}

		public ObscuredFloat Get_PLAYERDAMAGEOVERTIMERATIO
		{
			get
			{
				return PLAYERDAMAGEOVERTIMERATIO;
			}
			set
			{
				PLAYERDAMAGEOVERTIMERATIO = value;
			}
		}

		public int Get_UNITTYPE
		{
			get
			{
				return UNITTYPE;
			}
			set
			{
				UNITTYPE = value;
			}
		}

		public string Get_SPAWNS
		{
			get
			{
				return SPAWNS;
			}
			set
			{
				SPAWNS = value;
			}
		}

		public ObscuredFloat Get_MOVEMENTSPEED
		{
			get
			{
				return MOVEMENTSPEED;
			}
			set
			{
				MOVEMENTSPEED = value;
			}
		}

		public float Get_COOPHP
		{
			get
			{
				return COOPHP;
			}
			set
			{
				COOPHP = value;
			}
		}

		public float Get_COOPDAMAGE
		{
			get
			{
				return COOPDAMAGE;
			}
			set
			{
				COOPDAMAGE = value;
			}
		}

		public float Get_BOSSHP
		{
			get
			{
				return BOSSHP;
			}
			set
			{
				BOSSHP = value;
			}
		}

		public float Get_BOSSDAMAGE
		{
			get
			{
				return BOSSDAMAGE;
			}
			set
			{
				BOSSDAMAGE = value;
			}
		}

		public float Get_UNITINMECHANICALRESPAWN
		{
			get
			{
				return UNITINMECHANICALRESPAWN;
			}
			set
			{
				UNITINMECHANICALRESPAWN = value;
			}
		}

		public int Get_CLIENTID
		{
			get
			{
				return CLIENTID;
			}
			set
			{
				CLIENTID = value;
			}
		}

		public float Get_HITSHIELDPROB
		{
			get
			{
				return HITSHIELDPROB;
			}
			set
			{
				HITSHIELDPROB = value;
			}
		}

		public int Get_UNLOCKTIER2
		{
			get
			{
				return UNLOCKTIER2;
			}
			set
			{
				UNLOCKTIER2 = value;
			}
		}

		public int Get_UNLOCKTIER3
		{
			get
			{
				return UNLOCKTIER3;
			}
			set
			{
				UNLOCKTIER3 = value;
			}
		}

		public int Get_UNLOCKTIER4
		{
			get
			{
				return UNLOCKTIER4;
			}
			set
			{
				UNLOCKTIER4 = value;
			}
		}

		public int Get_UNLOCKTIER5
		{
			get
			{
				return UNLOCKTIER5;
			}
			set
			{
				UNLOCKTIER5 = value;
			}
		}

		public int Get_UNLOCKTIER6
		{
			get
			{
				return UNLOCKTIER6;
			}
			set
			{
				UNLOCKTIER6 = value;
			}
		}

		public bool Get_ISVETERAN
		{
			get
			{
				return ISVETERAN;
			}
			set
			{
				ISVETERAN = value;
			}
		}

		public int Length
		{
			get
			{
				return 33;
			}
		}

		public string this[int i]
		{
			get
			{
				return GetStringDataByIndex(i);
			}
		}

		public ArmyUpgradesRow()
		{
		}

		public ArmyUpgradesRow(string _ID, string _NAME, string _UNLOCKLEVEL, string _PRICE, string _CANBEBOUGHT, string _PRICEGOLD, string _TOTALPOWER, string _COOLDOWN, string _DANGERCOEFICIENT, string _DELIVERTIME, string _STARTINGTIER, string _STARTINGLEVEL, string _STARTINGSPECIAL, string _STARTINGELITE, string _BULLETSPEED, string _PLAYERBEHINDSHIELDDMGRATIO, string _PLAYERDAMAGERATIO, string _PLAYERDAMAGEOVERTIMERATIO, string _UNITTYPE, string _SPAWNS, string _MOVEMENTSPEED, string _COOPHP, string _COOPDAMAGE, string _BOSSHP, string _BOSSDAMAGE, string _UNITINMECHANICALRESPAWN, string _CLIENTID, string _HITSHIELDPROB, string _UNLOCKTIER2, string _UNLOCKTIER3, string _UNLOCKTIER4, string _UNLOCKTIER5, string _UNLOCKTIER6, string _ISVETERAN)
		{
			NAME = _NAME.Trim();
			int result;
			if (int.TryParse(_UNLOCKLEVEL, out result))
			{
				UNLOCKLEVEL = result;
			}
			else
			{
				Debug.LogError("Failed To Convert UNLOCKLEVEL string: " + _UNLOCKLEVEL + " to int");
			}
			int result2;
			if (int.TryParse(_PRICE, out result2))
			{
				PRICE = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert PRICE string: " + _PRICE + " to float");
			}
			int result3;
			if (int.TryParse(_CANBEBOUGHT, out result3))
			{
				CANBEBOUGHT = result3;
			}
			else
			{
				Debug.LogError("Failed To Convert CANBEBOUGHT string: " + _CANBEBOUGHT + " to int");
			}
			int result4;
			if (int.TryParse(_PRICEGOLD, out result4))
			{
				PRICEGOLD = result4;
			}
			else
			{
				Debug.LogError("Failed To Convert PRICEGOLD string: " + _PRICEGOLD + " to float");
			}
			int result5;
			if (int.TryParse(_TOTALPOWER, out result5))
			{
				TOTALPOWER = result5;
			}
			else
			{
				Debug.LogError("Failed To Convert TOTALPOWER string: " + _TOTALPOWER + " to float");
			}
			float result6;
			if (float.TryParse(_COOLDOWN, out result6))
			{
				COOLDOWN = result6;
			}
			else
			{
				Debug.LogError("Failed To Convert COOLDOWN string: " + _COOLDOWN + " to float");
			}
			int result7;
			if (int.TryParse(_DANGERCOEFICIENT, out result7))
			{
				DANGERCOEFICIENT = result7;
			}
			else
			{
				Debug.LogError("Failed To Convert DANGERCOEFICIENT string: " + _DANGERCOEFICIENT + " to int");
			}
			int result8;
			if (int.TryParse(_DELIVERTIME, out result8))
			{
				DELIVERTIME = result8;
			}
			else
			{
				Debug.LogError("Failed To Convert DELIVERTIME string: " + _DELIVERTIME + " to int");
			}
			int result9;
			if (int.TryParse(_STARTINGTIER, out result9))
			{
				STARTINGTIER = result9;
			}
			else
			{
				Debug.LogError("Failed To Convert STARTINGTIER string: " + _STARTINGTIER + " to int");
			}
			int result10;
			if (int.TryParse(_STARTINGLEVEL, out result10))
			{
				STARTINGLEVEL = result10;
			}
			else
			{
				Debug.LogError("Failed To Convert STARTINGLEVEL string: " + _STARTINGLEVEL + " to int");
			}
			int result11;
			if (int.TryParse(_STARTINGSPECIAL, out result11))
			{
				STARTINGSPECIAL = result11;
			}
			else
			{
				Debug.LogError("Failed To Convert STARTINGSPECIAL string: " + _STARTINGSPECIAL + " to int");
			}
			int result12;
			if (int.TryParse(_STARTINGELITE, out result12))
			{
				STARTINGELITE = result12;
			}
			else
			{
				Debug.LogError("Failed To Convert STARTINGELITE string: " + _STARTINGELITE + " to int");
			}
			float result13;
			if (float.TryParse(_BULLETSPEED, out result13))
			{
				BULLETSPEED = result13;
			}
			else
			{
				Debug.LogError("Failed To Convert BULLETSPEED string: " + _BULLETSPEED + " to float");
			}
			float result14;
			if (float.TryParse(_PLAYERBEHINDSHIELDDMGRATIO, out result14))
			{
				PLAYERBEHINDSHIELDDMGRATIO = result14;
			}
			else
			{
				Debug.LogError("Failed To Convert PLAYERBEHINDSHIELDDMGRATIO string: " + _PLAYERBEHINDSHIELDDMGRATIO + " to float");
			}
			float result15;
			if (float.TryParse(_PLAYERDAMAGERATIO, out result15))
			{
				PLAYERDAMAGERATIO = result15;
			}
			else
			{
				Debug.LogError("Failed To Convert PLAYERDAMAGERATIO string: " + _PLAYERDAMAGERATIO + " to float");
			}
			float result16;
			if (float.TryParse(_PLAYERDAMAGEOVERTIMERATIO, out result16))
			{
				PLAYERDAMAGEOVERTIMERATIO = result16;
			}
			else
			{
				Debug.LogError("Failed To Convert PLAYERDAMAGEOVERTIMERATIO string: " + _PLAYERDAMAGEOVERTIMERATIO + " to float");
			}
			int result17;
			if (int.TryParse(_UNITTYPE, out result17))
			{
				UNITTYPE = result17;
			}
			else
			{
				Debug.LogError("Failed To Convert UNITTYPE string: " + _UNITTYPE + " to int");
			}
			SPAWNS = _SPAWNS.Trim();
			float result18;
			if (float.TryParse(_MOVEMENTSPEED, out result18))
			{
				MOVEMENTSPEED = result18;
			}
			else
			{
				Debug.LogError("Failed To Convert MOVEMENTSPEED string: " + _MOVEMENTSPEED + " to float");
			}
			float result19;
			if (float.TryParse(_COOPHP, out result19))
			{
				COOPHP = result19;
			}
			else
			{
				Debug.LogError("Failed To Convert COOPHP string: " + _COOPHP + " to float");
			}
			float result20;
			if (float.TryParse(_COOPDAMAGE, out result20))
			{
				COOPDAMAGE = result20;
			}
			else
			{
				Debug.LogError("Failed To Convert COOPDAMAGE string: " + _COOPDAMAGE + " to float");
			}
			float result21;
			if (float.TryParse(_BOSSHP, out result21))
			{
				BOSSHP = result21;
			}
			else
			{
				Debug.LogError("Failed To Convert BOSSHP string: " + _BOSSHP + " to float");
			}
			float result22;
			if (float.TryParse(_BOSSDAMAGE, out result22))
			{
				BOSSDAMAGE = result22;
			}
			else
			{
				Debug.LogError("Failed To Convert BOSSDAMAGE string: " + _BOSSDAMAGE + " to float");
			}
			float result23;
			if (float.TryParse(_UNITINMECHANICALRESPAWN, out result23))
			{
				UNITINMECHANICALRESPAWN = result23;
			}
			else
			{
				Debug.LogError("Failed To Convert UNITINMECHANICALRESPAWN string: " + _UNITINMECHANICALRESPAWN + " to float");
			}
			int result24;
			if (int.TryParse(_CLIENTID, out result24))
			{
				CLIENTID = result24;
			}
			else
			{
				Debug.LogError("Failed To Convert CLIENTID string: " + _CLIENTID + " to int");
			}
			float result25;
			if (float.TryParse(_HITSHIELDPROB, out result25))
			{
				HITSHIELDPROB = result25;
			}
			else
			{
				Debug.LogError("Failed To Convert HITSHIELDPROB string: " + _HITSHIELDPROB + " to float");
			}
			int result26;
			if (int.TryParse(_UNLOCKTIER2, out result26))
			{
				UNLOCKTIER2 = result26;
			}
			else
			{
				Debug.LogError("Failed To Convert UNLOCKTIER2 string: " + _UNLOCKTIER2 + " to int");
			}
			int result27;
			if (int.TryParse(_UNLOCKTIER3, out result27))
			{
				UNLOCKTIER3 = result27;
			}
			else
			{
				Debug.LogError("Failed To Convert UNLOCKTIER3 string: " + _UNLOCKTIER3 + " to int");
			}
			int result28;
			if (int.TryParse(_UNLOCKTIER4, out result28))
			{
				UNLOCKTIER4 = result28;
			}
			else
			{
				Debug.LogError("Failed To Convert UNLOCKTIER4 string: " + _UNLOCKTIER4 + " to int");
			}
			int result29;
			if (int.TryParse(_UNLOCKTIER5, out result29))
			{
				UNLOCKTIER5 = result29;
			}
			else
			{
				Debug.LogError("Failed To Convert UNLOCKTIER5 string: " + _UNLOCKTIER5 + " to int");
			}
			int result30;
			if (int.TryParse(_UNLOCKTIER6, out result30))
			{
				UNLOCKTIER6 = result30;
			}
			else
			{
				Debug.LogError("Failed To Convert UNLOCKTIER6 string: " + _UNLOCKTIER6 + " to int");
			}
			bool result31;
			if (bool.TryParse(_ISVETERAN, out result31))
			{
				ISVETERAN = result31;
			}
			else
			{
				Debug.LogError("Failed To Convert ISVETERAN string: " + _ISVETERAN + " to bool");
			}
		}

		public string GetStringDataByIndex(int index)
		{
			string result = string.Empty;
			switch (index)
			{
			case 0:
				result = NAME.ToString();
				break;
			case 1:
				result = UNLOCKLEVEL.ToString();
				break;
			case 2:
				result = PRICE.ToString();
				break;
			case 3:
				result = CANBEBOUGHT.ToString();
				break;
			case 4:
				result = PRICEGOLD.ToString();
				break;
			case 5:
				result = TOTALPOWER.ToString();
				break;
			case 6:
				result = COOLDOWN.ToString();
				break;
			case 7:
				result = DANGERCOEFICIENT.ToString();
				break;
			case 8:
				result = DELIVERTIME.ToString();
				break;
			case 9:
				result = STARTINGTIER.ToString();
				break;
			case 10:
				result = STARTINGLEVEL.ToString();
				break;
			case 11:
				result = STARTINGSPECIAL.ToString();
				break;
			case 12:
				result = STARTINGELITE.ToString();
				break;
			case 13:
				result = BULLETSPEED.ToString();
				break;
			case 14:
				result = PLAYERBEHINDSHIELDDMGRATIO.ToString();
				break;
			case 15:
				result = PLAYERDAMAGERATIO.ToString();
				break;
			case 16:
				result = PLAYERDAMAGEOVERTIMERATIO.ToString();
				break;
			case 17:
				result = UNITTYPE.ToString();
				break;
			case 18:
				result = SPAWNS.ToString();
				break;
			case 19:
				result = MOVEMENTSPEED.ToString();
				break;
			case 20:
				result = COOPHP.ToString();
				break;
			case 21:
				result = COOPDAMAGE.ToString();
				break;
			case 22:
				result = BOSSHP.ToString();
				break;
			case 23:
				result = BOSSDAMAGE.ToString();
				break;
			case 24:
				result = UNITINMECHANICALRESPAWN.ToString();
				break;
			case 25:
				result = CLIENTID.ToString();
				break;
			case 26:
				result = HITSHIELDPROB.ToString();
				break;
			case 27:
				result = UNLOCKTIER2.ToString();
				break;
			case 28:
				result = UNLOCKTIER3.ToString();
				break;
			case 29:
				result = UNLOCKTIER4.ToString();
				break;
			case 30:
				result = UNLOCKTIER5.ToString();
				break;
			case 31:
				result = UNLOCKTIER6.ToString();
				break;
			case 32:
				result = ISVETERAN.ToString();
				break;
			}
			return result;
		}

		public string GetStringData(string colID)
		{
			string result = string.Empty;
			switch (colID)
			{
			case "NAME":
				result = NAME.ToString();
				break;
			case "UNLOCKLEVEL":
				result = UNLOCKLEVEL.ToString();
				break;
			case "PRICE":
				result = PRICE.ToString();
				break;
			case "CANBEBOUGHT":
				result = CANBEBOUGHT.ToString();
				break;
			case "PRICEGOLD":
				result = PRICEGOLD.ToString();
				break;
			case "TOTALPOWER":
				result = TOTALPOWER.ToString();
				break;
			case "COOLDOWN":
				result = COOLDOWN.ToString();
				break;
			case "DANGERCOEFICIENT":
				result = DANGERCOEFICIENT.ToString();
				break;
			case "DELIVERTIME":
				result = DELIVERTIME.ToString();
				break;
			case "STARTINGTIER":
				result = STARTINGTIER.ToString();
				break;
			case "STARTINGLEVEL":
				result = STARTINGLEVEL.ToString();
				break;
			case "STARTINGSPECIAL":
				result = STARTINGSPECIAL.ToString();
				break;
			case "STARTINGELITE":
				result = STARTINGELITE.ToString();
				break;
			case "BULLETSPEED":
				result = BULLETSPEED.ToString();
				break;
			case "PLAYERBEHINDSHIELDDMGRATIO":
				result = PLAYERBEHINDSHIELDDMGRATIO.ToString();
				break;
			case "PLAYERDAMAGERATIO":
				result = PLAYERDAMAGERATIO.ToString();
				break;
			case "PLAYERDAMAGEOVERTIMERATIO":
				result = PLAYERDAMAGEOVERTIMERATIO.ToString();
				break;
			case "UNITTYPE":
				result = UNITTYPE.ToString();
				break;
			case "SPAWNS":
				result = SPAWNS.ToString();
				break;
			case "MOVEMENTSPEED":
				result = MOVEMENTSPEED.ToString();
				break;
			case "COOPHP":
				result = COOPHP.ToString();
				break;
			case "COOPDAMAGE":
				result = COOPDAMAGE.ToString();
				break;
			case "BOSSHP":
				result = BOSSHP.ToString();
				break;
			case "BOSSDAMAGE":
				result = BOSSDAMAGE.ToString();
				break;
			case "UNITINMECHANICALRESPAWN":
				result = UNITINMECHANICALRESPAWN.ToString();
				break;
			case "CLIENTID":
				result = CLIENTID.ToString();
				break;
			case "HITSHIELDPROB":
				result = HITSHIELDPROB.ToString();
				break;
			case "UNLOCKTIER2":
				result = UNLOCKTIER2.ToString();
				break;
			case "UNLOCKTIER3":
				result = UNLOCKTIER3.ToString();
				break;
			case "UNLOCKTIER4":
				result = UNLOCKTIER4.ToString();
				break;
			case "UNLOCKTIER5":
				result = UNLOCKTIER5.ToString();
				break;
			case "UNLOCKTIER6":
				result = UNLOCKTIER6.ToString();
				break;
			case "ISVETERAN":
				result = ISVETERAN.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{NAME : " + NAME.ToString() + "} ";
			empty = empty + "{UNLOCKLEVEL : " + UNLOCKLEVEL + "} ";
			empty = empty + "{PRICE : " + PRICE.ToString() + "} ";
			empty = empty + "{CANBEBOUGHT : " + CANBEBOUGHT + "} ";
			empty = empty + "{PRICEGOLD : " + PRICEGOLD.ToString() + "} ";
			empty = empty + "{TOTALPOWER : " + TOTALPOWER.ToString() + "} ";
			empty = empty + "{COOLDOWN : " + COOLDOWN.ToString() + "} ";
			empty = empty + "{DANGERCOEFICIENT : " + DANGERCOEFICIENT + "} ";
			empty = empty + "{DELIVERTIME : " + DELIVERTIME + "} ";
			empty = empty + "{STARTINGTIER : " + STARTINGTIER + "} ";
			empty = empty + "{STARTINGLEVEL : " + STARTINGLEVEL + "} ";
			empty = empty + "{STARTINGSPECIAL : " + STARTINGSPECIAL + "} ";
			empty = empty + "{STARTINGELITE : " + STARTINGELITE + "} ";
			empty = empty + "{BULLETSPEED : " + BULLETSPEED.ToString() + "} ";
			empty = empty + "{PLAYERBEHINDSHIELDDMGRATIO : " + PLAYERBEHINDSHIELDDMGRATIO.ToString() + "} ";
			empty = empty + "{PLAYERDAMAGERATIO : " + PLAYERDAMAGERATIO.ToString() + "} ";
			empty = empty + "{PLAYERDAMAGEOVERTIMERATIO : " + PLAYERDAMAGEOVERTIMERATIO.ToString() + "} ";
			empty = empty + "{UNITTYPE : " + UNITTYPE + "} ";
			empty = empty + "{SPAWNS : " + SPAWNS.ToString() + "} ";
			empty = empty + "{MOVEMENTSPEED : " + MOVEMENTSPEED.ToString() + "} ";
			empty = empty + "{COOPHP : " + COOPHP + "} ";
			empty = empty + "{COOPDAMAGE : " + COOPDAMAGE + "} ";
			empty = empty + "{BOSSHP : " + BOSSHP + "} ";
			empty = empty + "{BOSSDAMAGE : " + BOSSDAMAGE + "} ";
			empty = empty + "{UNITINMECHANICALRESPAWN : " + UNITINMECHANICALRESPAWN + "} ";
			empty = empty + "{CLIENTID : " + CLIENTID + "} ";
			empty = empty + "{HITSHIELDPROB : " + HITSHIELDPROB + "} ";
			empty = empty + "{UNLOCKTIER2 : " + UNLOCKTIER2 + "} ";
			empty = empty + "{UNLOCKTIER3 : " + UNLOCKTIER3 + "} ";
			empty = empty + "{UNLOCKTIER4 : " + UNLOCKTIER4 + "} ";
			empty = empty + "{UNLOCKTIER5 : " + UNLOCKTIER5 + "} ";
			empty = empty + "{UNLOCKTIER6 : " + UNLOCKTIER6 + "} ";
			return empty + "{ISVETERAN : " + ISVETERAN + "} ";
		}
	}
}
