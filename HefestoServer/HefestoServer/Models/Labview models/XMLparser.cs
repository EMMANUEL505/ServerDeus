using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HefestoServer.Models
{
    public class XMLparser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Zone { get; set; }
        public int Id { get; set; }
        public int Mode { get; set; }
        public int Status { get; set; }
        public float Lat { get; set; }
        public float Long { get; set; }

        public string XMLresult(string type)
        {
            string xmlstring = "<" + type + ">" + Environment.NewLine + "<Name>";
            xmlstring += Name + "</Name>"+Environment.NewLine;
            xmlstring+="<Email>"+ Email +"</Email>"+Environment.NewLine;
            xmlstring += "<Zone>" + Zone + "</Zone>" + Environment.NewLine;
            xmlstring += "<Id>" + Id.ToString() + "</Id>" + Environment.NewLine;
            xmlstring += "<Lat>" + Lat.ToString() + "</Lat>" + Environment.NewLine;
            xmlstring += "<Long>" + Long.ToString() + "</Long>" + Environment.NewLine;
            xmlstring += "<Mode>" + Mode.ToString() + "</Mode>" + Environment.NewLine;
            xmlstring += "<Status>" + Status.ToString() + "</Status>" + Environment.NewLine;
            xmlstring += "</" + type + ">" + Environment.NewLine;
            
            return xmlstring;
        }
          /*<Name>Universidad Tecnologica</Name>
  <Email>hefestoserver@gmail.com</Email>
  <Zone>Zone 5</Zone>
  <Id>16</Id>
  <Lat>96.587</Lat>
  <Long>15.36</Long>
  <Mode>3</Mode>
  <Status>0</Status>*/
    }
    public class XMLalert
    {
        public int Id{get;set;}
        public string Name { get; set; }
        public string Alert { get; set; }
        public int Isread { get; set; }
        public DateTime  Opendate { get; set; }
        public string Closedate { get; set; }


        public string XMLresult(string type)
        {
            string xmlstring = "<"+type+">" + Environment.NewLine + "<Id>";
            xmlstring += Id.ToString() + "</Id>" + Environment.NewLine;
            xmlstring += "<Name>" + Name + "</Name>" + Environment.NewLine;
            xmlstring += "<Alert>" + Alert + "</Alert>" + Environment.NewLine;
            xmlstring += "<Isread>" + Isread + "</Isread>" + Environment.NewLine;
            xmlstring += "<Opendate>" + Opendate.ToString() + "</Opendate>" + Environment.NewLine;
            xmlstring += "<Closedate>" + Closedate.ToString() + "</Closedate>" + Environment.NewLine;
            xmlstring += "</"+type+">" + Environment.NewLine;

            return xmlstring;
        }
    }
        /*<Name>Universidad Tecnologica</Name>
<Email>hefestoserver@gmail.com</Email>
<Zone>Zone 5</Zone>
<Id>16</Id>
<Lat>96.587</Lat>
<Long>15.36</Long>
<Mode>3</Mode>
<Status>0</Status>*/
    public class XMLmonitoring
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public int Status { get; set; }
        public float Current { get; set; }
        public float Voltage { get; set; }
        //public double Var1 { get; set; }
        //public double Var2 { get; set; }


        public string XMLresult(string type)
        {
            string xmlstring = "<" + type + ">" + Environment.NewLine + "<Id>";
            xmlstring += Id.ToString() + "</Id>" + Environment.NewLine;
            xmlstring += "<Name>" + Name + "</Name>" + Environment.NewLine;
            xmlstring += "<Date>" + Date + "</Date>" + Environment.NewLine;
            xmlstring += "<Status>" + Status + "</Status>" + Environment.NewLine;
            xmlstring += "<Current>" + Current.ToString() + "</Current>" + Environment.NewLine;
            xmlstring += "<Voltage>" + Voltage.ToString() + "</Voltage>" + Environment.NewLine;
            xmlstring += "</" + type + ">" + Environment.NewLine;

            return xmlstring;
        }
    }

    }
