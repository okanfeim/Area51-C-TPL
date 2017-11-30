using System.Threading.Tasks;

namespace Area51
{
	class Agent
	{
		public enum AuthLevel
		{
			Confidential,
			Secret,
			TopSecret
		};

		public AuthLevel SecurityLevel { get; set; }
		public Elevator.Floors CurrentFloor { get; set; }
		public Agent(AuthLevel security, Elevator.Floors floor)
		{
			SecurityLevel = security;
			CurrentFloor = floor;
		}

		public void DoStuff()
		{
			Elevator.Floors TargetFloor;
			do TargetFloor = (Elevator.Floors)Globals.rand.Next(0, 3);
			while (TargetFloor != CurrentFloor);

			Task.Factory.StartNew(() => { Elevator.Call(CurrentFloor); })
			.ContinueWith((previousTask) => Elevator.Move(TargetFloor))
			.ContinueWith((previousTask) =>
			{
				if (!Elevator.Door.Authenticate(SecurityLevel, Elevator.Floor))
					DoStuff();
				else
					Globals.semaphore.Release();
			});
		}
	}
}
