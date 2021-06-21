using System;
using Android.Runtime;

namespace BluetoothLeCore.Enum
{
	[PreserveAttribute(AllMembers = true)]
	public enum BLEState
	{
		Unknown,
		Unavailable,
		Unauthorized,
		TurningOn,
		On,
		TurningOff,
		Off
	}
}
