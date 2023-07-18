using System;
using System.Text;
using System.Text.RegularExpressions;
using Demo_API.Data;
using Demo_API.Types;
using Newtonsoft.Json;

namespace Demo_API.ShipLocalMock
{
    /// <summary>
    /// This class implements the IShipStorage. It proides methodes to Create, Read, Update and Delete Ships from a local json file.
    /// </summary>
	public class ShipDB : IShipStorage
    {

        private List<Ship> ListOfShips = new List<Ship>();
        private string path = Path.Combine(Environment.CurrentDirectory, "ShipLocalMock/ShipStorage.json");

        public ShipDB()
        {
            if (File.Exists(path))
            {
                Console.WriteLine("Read File");
                string ships = File.ReadAllText(path);
                ListOfShips = JsonConvert.DeserializeObject<List<Ship>>(ships);
                Console.WriteLine(ListOfShips.Count);
            }
            else
            {
                Console.WriteLine("File not Found");
            }
        }

        /// <summary>
        /// This methode persist the local ListOfShips into the json file.
        /// </summary>
        private void PersistChanges()
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(ListOfShips));
        }

        /// <summary>
        /// This methode creates a new ship in the ListOfShips and call the PersistChanges methode.
        /// </summary>
        /// <param name="ship">A string with the new, serialized ship object</param>
        /// <returns>A bool who indicates, if the ship was created successfull</returns>
        public bool CreateShip(string ship)
        {
            string regex = @"[A-Z]{4}-[0-9]{4}-[A_Z0-9]{2}";

            Ship newShip = JsonConvert.DeserializeObject<Ship>(ship);

            if (Regex.Match(newShip.code, regex).Value == newShip.code)
            {
                foreach (Ship s in ListOfShips)
                {
                    if (s.code == newShip.code)
                    {
                        Console.WriteLine("ID is not Unique");
                        return false;
                    }
                }

                ListOfShips.Add(newShip);
                PersistChanges();
                return true;
            }
            else
            {
                Console.WriteLine("False Code Format");
            }
            return false;
        }

        /// <summary>
        /// This methode deletes a ship in the ListOfShips and call the PersistChanges methode.
        /// </summary>
        /// <param name="code">The code of the ship which should be deleted</param>
        /// <returns>A bool who indicates, if the ship was deleted successfull</returns>
        public bool DeleteShip(string code)
        {

            foreach (Ship ship in ListOfShips)
            {
                if (ship.code == code)
                {
                    ListOfShips.Remove(ship);
                    PersistChanges();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// This methodes selects a specified ship from the ListOfShips
        /// </summary>
        /// <param name="code">The code of the ship</param>
        /// <returns>The serialized ship</returns>
        public string ReadShip(string code)
        {
            foreach (Ship ship in ListOfShips)
            {
                if (ship.code == code)
                {
                    PersistChanges();
                    return JsonConvert.SerializeObject(ship);
                }
            }
            return JsonConvert.SerializeObject("");
        }

        /// <summary>
        /// This methode updates a ship in the ListOfShips and call the PersistChanges methode.
        /// </summary>
        /// <param name="ship">The serialized ship which shuld be updated</param>
        /// <returns>A bool who indicates, if the ship was updated successfull</returns>x
        public bool UpdateShip(string ship)
        {
            Ship shipUpdate = JsonConvert.DeserializeObject<Ship>(ship);

            foreach (Ship s in ListOfShips)
            {
                if (s.code == shipUpdate.code)
                {
                    s.UpdateShip(shipUpdate);
                    PersistChanges();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// This methodes selects all ships from the ListOfShips
        /// </summary>
        /// <returns>A </returns>
        public string GetAllShips()
        {
            return JsonConvert.SerializeObject(ListOfShips);
        }
    }
}

