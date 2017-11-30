using System;
using System.Threading;

namespace Area51
{
	

	static class Globals
	{
		public static Semaphore semaphore = new Semaphore(1, 1);
		public static Random rand = new Random();
	}
}
