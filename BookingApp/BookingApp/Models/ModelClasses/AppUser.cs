using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ModelClasses
{
	public class AppUser {

		private string email;
		public int Id { get; set; }
        public string FullName { get; set; }
        private string password;
		private string username;

		public AppUser(){

		}

		~AppUser(){

		}

		public string Email{
			get{
				return email;
			}
			set{
				email = value;
			}
		}

		public string Password{
			get{
				return password;
			}
			set{
				password = value;
			}
		}

		public string Username{
			get{
				return username;
			}
			set{
				username = value;
			}
		}

	}

}