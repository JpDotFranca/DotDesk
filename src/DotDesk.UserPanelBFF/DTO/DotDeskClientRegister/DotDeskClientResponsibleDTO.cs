﻿using DotDesk.Domain.Entities;

namespace DotDesk.UserPanelBFF.DTO.DotDeskClientRegister;

public class DotDeskClientResponsibleDTO
{
    public string Name { get; set; }
    public string Identity { get; set; }
    
    public DotDeskClientResponsible Map()
    {
        return new DotDeskClientResponsible(this.Name, this.Identity);
    }
}