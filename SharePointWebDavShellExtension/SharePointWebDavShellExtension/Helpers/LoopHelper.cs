using System;
using System.Linq;

namespace SharePointWebDavShellExtension.Helpers
{
	public static class LoopHelper
	{
		public static void TryWhile(Func<bool> condition, Func<bool> handler, params Action[] unsuccessfullActions)
		{
			bool successfull = false;

			while (condition.Invoke() && !successfull)
				successfull = handler.Invoke();

			if(!successfull && unsuccessfullActions!= null && unsuccessfullActions.Any())
				foreach (var unsuccessfullAction in unsuccessfullActions)
				{
					unsuccessfullAction.Invoke();
				}
		}
	}
}