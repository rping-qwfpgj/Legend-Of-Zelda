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
            var query = from c in xml.Root.Descendants("contact")
                        where (int)c.Attribute("id") < 4
                        select c.Element("firstName").Value + " " +
                               c.Element("lastName").Value;


            foreach (string name in query)
            {
                Console.WriteLine("Contact's Full Name: {0}", name);
            }

            

            return new List<Room>();
        }
    
    }
}
