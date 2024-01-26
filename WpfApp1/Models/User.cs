using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public Privilage Privilage{ get; set; }
        public bool Status { get; set; }

    }

    public enum Privilage
    {
        Administrator, Petugas
    }
}
