using Interfaces;
using Microsoft.Xna.Framework;
using SpriteFactories;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace LegendofZelda
{
    public class RoomLoader
    {
        private XDocument xml;
        public RoomLoader(XDocument xml)
        {
            this.xml = xml;
        }
        public List<Room> Parse()
        {
            List<Room> returner = new List<Room>();

            // Query the data and write out a subset of contacts
            var blocks = from c in xml.Root.Descendants("Item")
                         where c.Element("ObejctType").Value == "Block"
                         select c;


            foreach (var block in blocks)
            {

                string[] locationString = block.Element("Location").Value.Split(" ");
                Vector2 location = new((float)Convert.ToDouble(locationString[0]), (float)Convert.ToDouble(locationString[1]));
                switch (block.Element("ObjectName").Value)
                {

                  

                }

                Console.WriteLine("Contact's Full Name:");
            }

            
            return new List<Room>();
        }
    
    }
}
