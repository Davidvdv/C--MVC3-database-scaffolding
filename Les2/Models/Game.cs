using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Les2.Models
{
	public class Game
	{
		public int GameID { get; set; }
		public int GenreID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual Genre Genre { get; set; }
	}
}