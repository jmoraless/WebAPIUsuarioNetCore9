﻿using System;
using System.Collections.Generic;

namespace WebAPIUsuario.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string? UserName { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
