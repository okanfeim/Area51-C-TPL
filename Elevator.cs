using System.Threading;

namespace Area51
{
	static class Elevator
	{
		public enum Floors
		{
			G, S, T1, T2
		};

		public static Floors Floor { get; set; }
		public static Door Door = new Door();

		public static void Call(Floors callerfloor)
		{
			while (Floor != callerfloor)
			{
				Thread.Sleep(1000);
				if (Floor < callerfloor) Floor++;
				if (Floor > callerfloor) Floor--;
			}
		}

		public static void Move(Floors targetfloor)
		{
			while (Floor != targetfloor)
			{
				Thread.Sleep(1000);
				if (Floor < targetfloor) Floor++;
				if (Floor > targetfloor) Floor--;
			}
		}

	}
}
