using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace ModelClasses
{
	public class Region {

		private int id;
		private string name;
        [Required]
        public Country country { get; set; }
		

		public Region(){

		}

		~Region(){

		}

		public int Id{
			get{
				return id;
			}
			set{
				id = value;
			}
		}

		public string Name{
			get{
				return name;
			}
			set{
				name = value;
			}
		}

	}

}