using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class users
    {
        public int id_users { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string lastname { get; set; }
        public string FirstName { get; set; }
        public string patronymic { get; set; }
        public string phone { get; set; }
        public int id_group { get; set; }
		public int id_category { get; set; }
	}
}
