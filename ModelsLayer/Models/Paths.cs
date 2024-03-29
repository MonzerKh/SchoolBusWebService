﻿using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.Models
{
    public class Paths
    {
        public Paths(LocationPeer from, LocationPeer to)
        {
            this.FromLoc = from;
            this.ToLoc = to;
            this.CalcuateDistance();
        }

        public LocationPeer FromLoc { get; set; }
        public LocationPeer ToLoc { get; set; }
        public double Distance { get; set; }
        public void GneratePaths()
        {
         //  var point = new GMapProvider

            //int transitCallbackIndex = routing.RegisterTransitCallback((long fromIndex, long toIndex) => {
            //    // Convert from routing variable Index to distance matrix NodeIndex.
            //    var fromNode = manager.IndexToNode(fromIndex);
            //    var toNode = manager.IndexToNode(toIndex);
            //    return data.DistanceMatrix[fromNode, toNode];
            //});
        }
        //public double CalculaDistanciaEntreDoisPontos(double lat1, double long1, double lat2, double long2)
        //{
        //    var req = new DistanceMatrixRequest();
        //    req.Origins.
        //    req.AddOrigin(new Waypoint() { Address = _start.ToString() });
        //    req.AddDestination(new Waypoint() { Address = _stop.ToString() });
        //    req.Sensor = false;
        //    req.Mode = TravelMode.driving;
        //    req.Units = Units.imperial;

        //    var response = new DistanceMatrixService().GetResponse(req);

        //    Distance = Convert.ToInt32(response.Rows.First().Elements.First().distance.Value);
        //    Duration = Convert.ToInt32(response.Rows.First().Elements.First().duration.Value);

        //    Console.WriteLine("Distance from {0}, to {1} is {2} - Travel Time: {3}", _start, _stop, Distance, Duration);
        //}

        public void CalcuateDistance()
        {
            this.Distance = Math.Pow(Convert.ToDouble( this.FromLoc.lat - this.ToLoc.lat), 2) 
                          + Math.Pow(Convert.ToDouble(FromLoc.lng - ToLoc.lng), 2);
        }

        static public double CalcuateDistance(LocationPeer parent, LocationPeer child)
        {
            var Distance = (Math.Pow(Convert.ToDouble(parent.lat - child.lat), 2)
                          + Math.Pow(Convert.ToDouble(parent.lng - child.lng), 2)) *10000;
            return Distance;
        }

        public static List<Paths> GeneratePaths(List<LocationPeer> Peers)
        {
            List<Paths> RoutingPath = new List<Paths>();
            foreach (var from in Peers)
                foreach (var to in Peers)
                    RoutingPath.Add(new Paths(from, to));

            return RoutingPath;
        }
    }
}
