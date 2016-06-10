﻿// OsmSharp - OpenStreetMap (OSM) SDK
// Copyright (C) 2016 Abelshausen Ben
// 
// This file is part of OsmSharp.
// 
// OsmSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// OsmSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with OsmSharp. If not, see <http://www.gnu.org/licenses/>.

using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using Itinero.Geo;
using Itinero.Osm.Vehicles;
using Itinero.Test.Functional.Staging;
using Itinero.Test.Functional.Tests;
using System;
using System.IO;
using System.Reflection;
using Itinero.Logging;

namespace Itinero.Test.Functional
{
    class Program
    {
        private static Logger _logger;

        static void Main(string[] args)
        {
            // enable logging.
            OsmSharp.Logging.Logger.LogAction = (origin, level, message, parameters) =>
            {
                Console.WriteLine(string.Format("[{0}] {1} - {2}", origin, level, message));
            };
            Itinero.Logging.Logger.LogAction = (origin, level, message, parameters) =>
            {
                Console.WriteLine(string.Format("[{0}] {1} - {2}", origin, level, message));
            };
            _logger = new Logger("Default");

            Itinero.Osm.Vehicles.Vehicle.RegisterVehicles();

            // download and extract test-data if not already there.
            _logger.Log(TraceEventType.Information, "Downloading Luxembourg...");
            Download.DownloadLuxembourgAll();
        
            // TEST1: Tests build a router db for cars, contracting it and calculating routes.
            // test building a router db.
            var routerDb = Runner.GetTestBuildRouterDb(Download.LuxembourgLocal, false, false, Vehicle.Car).TestPerf("Build belgium router db for Car.");
            Runner.GetTestAddContracted(routerDb, Vehicle.Car.Fastest(), false).TestPerf("Add contracted graph for Car.Fastest()");
            Runner.GetTestRandomRoutes(new Router(routerDb), Vehicle.Car.Fastest(), 1000).TestPerf("Testing route calculation speed.");

            _logger.Log(TraceEventType.Information, "Testing finished.");
            Console.ReadLine();
        }
    }
}
