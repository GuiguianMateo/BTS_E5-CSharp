using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AppLourdAVS.DBLib.Class;

public partial class User
{
    public ulong Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime? EmailVerifiedAt { get; set; }

    public string Password { get; set; } = null!;

    public string? RememberToken { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Firstname { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Gender { get; set; }

    public bool? Client { get; set; }

    public virtual ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();

    public virtual ICollection<Demande> Demandes { get; set; } = new List<Demande>();
}
