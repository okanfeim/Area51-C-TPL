using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Area51
{
	class Program
	{
		static object QueueLock = new object();
		static Queue<Agent> Agents = new Queue<Agent>();

		static void AgentMaker()
		{
			while (true)
			{
				int security = Globals.rand.Next(0, 2);
				int startingfloor = Globals.rand.Next(0, 3);

				Agent TheAgent = new Agent((Agent.AuthLevel)security, (Elevator.Floors)startingfloor);
				lock (QueueLock)
				{
					Agents.Enqueue(TheAgent);
				}

				Thread.Sleep(1000);
			}
		}

		static void Main(string[] args)
		{
			Task.Factory.StartNew(() => AgentMaker());
			Task.Factory.StartNew(() =>
			{
				while (true)
				{
					Globals.semaphore.WaitOne();
					Thread.Sleep(Globals.rand.Next(250, 1000));
					lock (QueueLock)
					{
						if (Agents.Count > 0)
						{
							Agent Agent = Agents.Dequeue();
							Agent.DoStuff();
						}
					}
				}
			});

			Console.WriteLine("Press ENTER to exit.");
			Console.ReadLine();
		}
	}
}
