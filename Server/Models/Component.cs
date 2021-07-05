using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessClone.Server.Models
{
    public class Component
    {
        public int Id {get;set;}
        [Required]
        public string Name {get;set;}

        public string Description {get;set;}
        
        public DateTime CreatedAt { get; set; }

        public Component()
        {
            this.CreatedAt = DateTime.Now;
        }

    }
}