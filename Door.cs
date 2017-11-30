using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51
{
	class Door
	{
		public bool Authenticate(Agent.AuthLevel security, Elevator.Floors floor)
		{
			if (security == Agent.AuthLevel.TopSecret)
				return true;

			if (security == Agent.AuthLevel.Secret)
			{
				if (floor > Elevator.Floors.S)
					return false;
				else
					return true;
			}

			if (security == Agent.AuthLevel.Confidential)
			{
				if (floor > Elevator.Floors.G)
					return false;
				else
					return true;
			}

			return false;
		}
	}
}
