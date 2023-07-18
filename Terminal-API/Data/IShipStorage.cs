using System;
using Demo_API.Types;

namespace Demo_API.Data
{
	public interface IShipStorage
	{
		bool CreateShip(string ship);
		string ReadShip(string code);
		bool UpdateShip(string ship);
		bool DeleteShip(string code);
		string GetAllShips();
	}
}

