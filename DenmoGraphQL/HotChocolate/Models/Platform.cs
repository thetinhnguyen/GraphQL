using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateDemo.Models
{
    public class Platform
    {
        /// <summary>
        /// Represents the unique ID for the platform.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Represents the name for the platform.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Represents a purchased, valid license for the platform.
        /// </summary>
        public string LicenseKey { get; set; }

        /// <summary>
        /// This is the list of available commands for this platform.
        /// </summary>
        public ICollection<Command> Commands { get; set; } = new List<Command>();

    }
}
