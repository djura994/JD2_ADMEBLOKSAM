using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace ModelClasses
{
	public class Place {

		private int id;
		private string name;
        [Required]
        public Region region { get; set; }

		public Place(){

		}

		~Place(){

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