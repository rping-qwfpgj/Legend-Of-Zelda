using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendofZelda.Rooms
{
    public class RushRoomsGenerator
    {
        private int numOfRooms;
        private int rushRoomIndex;
        private int totalNumOfRooms;
        private Game1 game;

        public RushRoomsGenerator(int numOfRooms, int rushRoomIndex, Game1 game)
        {
            this.numOfRooms = numOfRooms;
            this.rushRoomIndex = rushRoomIndex;
            totalNumOfRooms = rushRoomIndex;
            this.game = game;
        }
        public Dictionary<int, List<string>> newGraph()
        {
            Random rnd = new Random();
            int roomsAdded = 0;

            var roomsDoors = new Dictionary<int, List<string>>();

            for (int i = rushRoomIndex; i < rushRoomIndex + numOfRooms; i++)
            {
                roomsDoors.Add(i, new List<string>());
            }

            for (int currentRoomIndex = rushRoomIndex; roomsAdded < 4; currentRoomIndex++)
            {
                List<string> directionsChosen = new();
                List<string> directions = new()
                {
                    "left",
                    "right",
                    "top",
                    "bottom"
                };
                foreach (var door in roomsDoors[currentRoomIndex])
                {
                    directions.Remove(door);
                }

                int numOfDoors;
                if (numOfRooms - roomsAdded >= 4)
                {
                    numOfDoors = rnd.Next(1, directions.Count + 1);
                }
                else
                {
                    if (directions.Count >= numOfRooms - roomsAdded)
                    {
                        numOfDoors = rnd.Next(1, numOfRooms - roomsAdded);
                    }
                    else
                    {
                        numOfDoors = rnd.Next(1, directions.Count + 1);
                    }
                }

                for (int j = 0; j < numOfDoors; j++)
                {
                    var directionIndex = rnd.Next(0, directions.Count);
                    switch (directions[directionIndex])
                    {
                        case "left":
                            game.roomsGraph.AddLeftRightEdge(++totalNumOfRooms, currentRoomIndex);
                            directionsChosen.Add("left");
                            roomsDoors[totalNumOfRooms].Add("right");
                            break;
                        case "right":
                            game.roomsGraph.AddLeftRightEdge(currentRoomIndex, ++totalNumOfRooms);
                            directionsChosen.Add("right");
                            roomsDoors[totalNumOfRooms].Add("left");
                            break;
                        case "top":
                            game.roomsGraph.AddDownUpEdge(currentRoomIndex, ++totalNumOfRooms);
                            directionsChosen.Add("top");
                            roomsDoors[totalNumOfRooms].Add("bottom");
                            break;
                        case "bottom":
                            game.roomsGraph.AddDownUpEdge(++totalNumOfRooms, currentRoomIndex);
                            directionsChosen.Add("bottom");
                            roomsDoors[totalNumOfRooms].Add("top");
                            break;
                    }
                    roomsAdded++;
                    directions.RemoveAt(directionIndex);
                }
                roomsDoors[currentRoomIndex].AddRange(directionsChosen);
            }
            return roomsDoors;
        }



    }
}

