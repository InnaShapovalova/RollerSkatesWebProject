﻿using Rollers.Domain.Models;

namespace Rollers.ViewModels
{
	public class LocationViewModel
	{
		public RollerSkateMapLocation RollerSkateMapLocation { get; set; }
		public string GoogleApiKey { get; set; }
	}
}