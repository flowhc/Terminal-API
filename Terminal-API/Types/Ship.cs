using System;
namespace Demo_API.Types
{
	public class Ship
	{
		public string name { get; set; }
		public float length { get; set; }
        public float width { get; set; }
        public string code { get; set; }

        public Ship()
		{
			
		}

		public void UpdateShip(Ship ship)
		{
			this.name = ship.name;
			this.length = ship.length;
			this.width = ship.width;
		}

	}
}

