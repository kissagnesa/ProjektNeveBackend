using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjektNeveBackend.Models;

public partial class Jogok
{
    public int Id { get; set; }

    public int Szint { get; set; }

    public string Nev { get; set; } = null!;

    public string Leiras { get; set; } = null!;


    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
