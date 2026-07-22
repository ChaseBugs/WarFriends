using System;
using System.Collections.Generic;
using UnityEngine.Scripting;

[Serializable]
[Preserve]
public class EventAssignmentsConfig
{
	public string nameOfEvent;

	public string eventDescription;

	public int startTime;

	public int endTime;

	public EventLook eventLook;

	public List<EventMilestone> milestones;

	public List<EventAssignmentConfig> assignments;

	public CustomEventData customEventData;

	public bool showInCarousel;

	public string url;

	public int eventTargetValue => 0;

	public string textureName => null;
}
