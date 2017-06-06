using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ModelClasses
{
	public class Region {

		private int id;
		private string name;
		public List<Place> m_Place;

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