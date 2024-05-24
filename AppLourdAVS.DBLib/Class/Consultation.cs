using System;
using System.Collections.Generic;

namespace AppLourdAVS.DBLib.Class;

public partial class Consultation
{
    public ulong Id { get; set; }

    public DateTime Date { get; set; }

    public DateTime Deadline { get; set; }

    public bool Delay { get; set; }

    public ulong TypeId { get; set; }

    public ulong UserId { get; set; }

    public ulong PraticienId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Praticien Praticien { get; set; } = null!;

    public virtual Type Type { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
