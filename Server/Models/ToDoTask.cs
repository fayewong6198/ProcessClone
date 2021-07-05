using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessClone.Server.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int ComponentId {get;set;}
        public Component Component {get;set;}
        [ForeignKey("ApplicationUser")]
        public string GrandMasterId {get;set;}
        public ApplicationUser GrandMaster {get;set;}
        [ForeignKey("ApplicationUser")]
        public string MasterId {get;set;}
        public ApplicationUser Master {get;set;}
        [ForeignKey("ApplicationUser")]
        public string AssigneeId {get;set;}
        public ApplicationUser Assignee {get;set;}

        public DateTime CreatedAt { get; set; }

        public ToDoTask()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}