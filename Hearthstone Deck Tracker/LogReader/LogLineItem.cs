using System;

namespace Hearthstone_Deck_Tracker.LogReader
{
	public class LogLineItem
	{
		public string Namespace { get; set; }
		public DateTime Time { get; private set; }
		public string Line { get; set; }

		public LogLineItem(string ns, string line, DateTime date)
		{
			Namespace = ns;
			Line = line;
			DateTime time;
			Time = (line.Length > 20 && DateTime.TryParse(Line.Substring(2, 16), out time)) ? date.Date.Add(time.TimeOfDay) : date;
			if(Time > DateTime.Now)
				Time = Time.AddDays(-1);
		}
	}
}