using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendofZelda
{
    public class GraphGenerator
    {
        int numOfRooms;
        int rushRoomIndex;
        int newRoomsIndex;
        public GraphGenerator(int numOfRooms, int rushRoomIndex)
        {
            this.numOfRooms = numOfRooms;
            this.rushRoomIndex = rushRoomIndex;
            int newRoomsIndex = rushRoomIndex;
            

        }
        public Graph newGraph()
        {
            Graph randomGraph = new Graph();
            Random rnd = new Random();
            List<string> directions = new()
            {
                "left",
                "right",
                "top",
                "bottom"
            };

            for (int i = 0; i < numOfRooms; i++)
            {
                int doors = rnd.Next(4);

                for (int j = 0; j < doors; j++)
                {
                    var directionIndex = rnd.Next(doors);

                    switch (directions[directionIndex])
                    {

                        case "left":
                            randomGraph.AddLeftRightEdge(newRoomsIndex++, rushRoomIndex);
                            break;
                        case "right":
                            randomGraph.AddLeftRightEdge(rushRoomIndex, newRoomsIndex++);
                            break;
                        case "top":
                            randomGraph.AddDownUpEdge(rushRoomIndex, newRoomsIndex++);
                            break;
                        case "bottom":
                             randomGraph.AddDownUpEdge(newRoomsIndex++, rushRoomIndex);
                            break;

                    }
                    directions.RemoveAt(directionIndex);
                }

            }

            return randomGraph;
        }

    }
}
