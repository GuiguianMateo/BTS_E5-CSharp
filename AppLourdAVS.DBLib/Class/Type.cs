using System;
using System.Collections.Generic;

namespace AppLourdAVS.DBLib.Class;

public partial class Type
{
    public ulong Id { get; set; }

    public string Name { get; set; } = null!;

    public int Duration { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();

    public virtual ICollection<Demande> Demandes { get; set; } = new List<Demande>();

    public virtual ICollection<Praticien> Praticiens { get; set; } = new List<Praticien>();
}
