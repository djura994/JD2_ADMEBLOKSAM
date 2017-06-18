using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace ModelClasses
{
	public class AccommodationType {

		private int id;
		private string name;
        [JsonIgnore]
		public List<Accommodation> m_Accommodation;

		public AccommodationType(){

		}

		~AccommodationType(){

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