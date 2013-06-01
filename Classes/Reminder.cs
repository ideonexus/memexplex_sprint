using System;

namespace mxplx
{
	public enum ReminderTypes { Time, Interval }
	
	public class Reminder
	{
		#region Instance variables

		private DateTime setAt;
		private TimeSpan time;

		public string Name;
		public ReminderTypes ReminderType;
		public bool Active = false;

		#endregion

		#region Properties

		public TimeSpan Time
		{
			get { return time; }
			set {
				time = value;
				setAt = DateTime.Now;
			}
		}

		public DateTime NextOccurance
		{
			get {
				if (ReminderType == ReminderTypes.Interval)
					return setAt.Add(time);
				else {
					DateTime next = setAt.Subtract(setAt.TimeOfDay).Add(time);
					if (setAt.TimeOfDay > time)
						return next.AddDays(1);
					else
						return next;
				}
			}
		}

		#endregion

		#region Methods

		public override string ToString()
		{
			return Name;
		}

		public Reminder Clone()
		{
			return (Reminder)MemberwiseClone();
		}

		#endregion
	}
}