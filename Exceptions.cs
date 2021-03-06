using System;

namespace HatlessEngine
{
	[Serializable]
	public class NotLoadedException : Exception { }

	[Serializable]
	public class InvalidDeviceException : Exception { }

	[Serializable]
	public class ProtocolMismatchException : Exception 
	{
		public ProtocolMismatchException() { }
		public ProtocolMismatchException(string message) : base(message) { }
	}

	[Serializable]
	public class InvalidObjectTypeException : Exception
	{
		public InvalidObjectTypeException() { }
		public InvalidObjectTypeException(string message) : base(message) { }
	}

	[Serializable]
	public class NonConvexShapeDesignException : Exception { }

	[Serializable]
	public class ProfilerException : Exception
	{
		public ProfilerException() { }
		public ProfilerException(string message) : base(message) { }
	}

	[Serializable]
	public class NotEnoughCoffeeException : Exception { }

	[Serializable]
	public class ResourceNotFoundException : Exception
	{
		public ResourceNotFoundException() { }
		public ResourceNotFoundException(string message) : base(message) { }
	}
}