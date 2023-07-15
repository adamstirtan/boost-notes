using System;

namespace BoostNotes.Domain.Entities;

public class Note
{
    public long Id { get; set; }

    public DateTimeOffset Created { get; set; }

    public DateTimeOffset Modified { get; set; }

    public string? Content { get; set; }
}