using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace ModelClasses {
	public class Accommodation {

		private string address;
		private bool approved;
		private float averageGrade;
		private string description;
		private int id;
		private string imageURL;
		private double latitude;
		private double longitude;
		private string name;
        [Required]
        public Place place { get; set; }
		public List<Comment> m_Comment;
		public List<Room> m_Room;

		public Accommodation(){

		}

		~Accommodation(){

		}

		public string Address{
			get{
				return address;
			}
			set{
				address = value;
			}
		}

		public bool Approved{
			get{
				return approved;
			}
			set{
				approved = value;
			}
		}

		public float AverageGrade{
			get{
				return averageGrade;
			}
			set{
				averageGrade = value;
			}
		}

		public string Description{
			get{
				return description;
			}
			set{
				description = value;
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

		public string ImageURL{
			get{
				return imageURL;
			}
			set{
				imageURL = value;
			}
		}

		public double Latitude{
			get{
				return latitude;
			}
			set{
				latitude = value;
			}
		}

		public double Longitude{
			get{
				return longitude;
			}
			set{
				longitude = value;
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