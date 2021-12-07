using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Project
{
    [NotMapped]
    [Keyless]
    public class TeamRole
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
    }
}