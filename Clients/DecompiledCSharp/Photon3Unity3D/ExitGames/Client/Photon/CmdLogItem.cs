namespace ExitGames.Client.Photon;

internal class CmdLogItem
{
	public int TimeInt;

	public int Channel;

	public int SequenceNumber;

	public int Rtt;

	public int Variance;

	public CmdLogItem()
	{
	}

	public CmdLogItem(NCommand command, int timeInt, int rtt, int variance)
	{
		Channel = command.commandChannelID;
		SequenceNumber = command.reliableSequenceNumber;
		TimeInt = timeInt;
		Rtt = rtt;
		Variance = variance;
	}

	public override string ToString()
	{
		return $"NOW: {TimeInt,5}  CH: {Channel,3} SQ: {SequenceNumber,4} RTT: {Rtt,4} VAR: {Variance,3}";
	}
}
