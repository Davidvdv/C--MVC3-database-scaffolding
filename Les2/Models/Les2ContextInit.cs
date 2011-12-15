using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Les2.Models
{
	public class Les2ContextInit : DropCreateDatabaseAlways<Les2Context>
	{
		protected override void Seed(Les2Context context)
		{
			context.Genres.Add(new Genre() { GenreID = 1, Name = "FPS" });
			context.Genres.Add(new Genre() { GenreID = 2, Name = "Sport" });

			context.Games.Add(new Game() { GameID = 1, Name = "Battlefield 3", Description = "Lekker knallen", GenreID = 1 });

			base.Seed(context);
		}
	}
}