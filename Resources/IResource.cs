﻿namespace HatlessEngine
{
	public interface IResource
	{
		string Id { get; }

		/// <summary>
		/// Disposes/Unloads any memory resources from this resource and removes this resource from Resources.
		/// Yes that's alot of resource in one line I know...
		/// </summary>
		void Destroy();
	}
}
