using System;

namespace BoostNotes.Application.Common.Interfaces
{
	public interface IDateTime
	{
		DateTime NowUtc { get; }
	}
}
