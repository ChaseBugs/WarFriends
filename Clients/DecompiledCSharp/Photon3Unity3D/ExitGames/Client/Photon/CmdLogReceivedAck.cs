namespace ExitGames.Client.Photon;

internal class CmdLogReceivedAck : CmdLogItem
{
	public int ReceivedSentTime;

	public CmdLogReceivedAck(NCommand command, int timeInt, int rtt, int variance)
	{
		TimeInt = timeInt;
		Channel = command.commandChannelID;
		SequenceNumber = command.ackReceivedReliableSequenceNumber;
		Rtt = rtt;
		Variance = variance;
		ReceivedSentTime = command.ackReceivedSentTime;
	}

	public override string ToString()
	{
		return $"ACK  NOW: {TimeInt,5}  CH: {Channel,3} SQ: {SequenceNumber,4} RTT: {Rtt,4} VAR: {Variance,3}  Sent: {ReceivedSentTime,5} Diff: {TimeInt - ReceivedSentTime,4}";
	}
}
