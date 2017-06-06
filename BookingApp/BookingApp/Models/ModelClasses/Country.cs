using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ModelClasses
{
	public class Country {

		private int code;
		private int id;
		private string name;
		public List<Region> m_Region;

		public Country(){

		}

		~Country(){

		}

		public int Code{
			get{
				return code;
			}
			set{
				code = value;
			}
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