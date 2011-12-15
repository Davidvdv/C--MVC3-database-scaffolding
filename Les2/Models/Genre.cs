using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Les2.Models
{
	public class Genre
	{
		public int GenreID { get; set; }

		[Required]
		public string Name { get; set; }

		public virtual ICollection<Game> Games { get; set; }
	}
}