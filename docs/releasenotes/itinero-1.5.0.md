Itinero 1.5.0 Release Notes
---------------------------

This is a minor update.

- It is now possible to control node-based restrictions in the lua profiles.
- Updated Reminiscense to 1.3.0.

### 1.3.1 -> 1.4.0

New features:

- Added support for elevation, an example with [SRTM](https://github.com/itinero/srtm) is available [here](https://github.com/itinero/routing/tree/develop/samples/Sample.Elevation).
- .NET core support for Itinero.IO.Shape and Itinero.Geo. (Thanks NTS!)
- CancellationToken support in most algorithms.
- Improved the Itinero native Geo operations.
- Support for extra data (non-attributes) to be linked to edges and vertices.
- Support for keeping OSM way/node IDs.
- Support for removing restrictions from RouterDb.
- AttributesIndex is writeable after serializing RouterDb.
- Support to start/end routes in a given direction (angle).
- Support for island detection: this feature makes sure all resolved points can be routed.
- Support for optimizing a sequence to prevent u-turns.
- Support for cached routerpoints to prevent recalculation.
- Support for disabling tag 'normalization' in (lua) vehicle profiles.

Bugfixes:

- We don't register profiles globally anymore, it's now possible to load multiple routerdbs in the same process.
- Fixed #157 'Route.ProjectOn timeFromStartInSeconds is always 0'.
- Fixed #153 'DirectionCalculator sometimes erroneously returns default turn direction of 'Left''.
- Fixed #141 'Add extension method to get directed edge id on routerpoint.'
- Fixed #203 'One-to-many routing returns only first path'.
- Fixed #214 'The index out of range exception has been thrown when I try to build the whole US router db'
- Fixed #209 'AddContraction Stalls'
- Fixed #238 'DynamicProfile is not thread safe'
- Fixed #253 'Exception contracting europe-latest.osm.pbf'

### 1.3.0 -> 1.3.1

- Fixed issue in dualgraph builder not keeping topology.

### 1.2.0 -> 1.3.0

New features:

- Added the option to extract part of the network: https://github.com/itinero/routing/wiki/RouterDb#extracting-an-area
- Added the option to write a routerdb as a shapefile: https://github.com/itinero/routing/wiki/Shapefiles#routerdb-to-shapefile
- Added the option to keep original node id's and to keep meta-data on vertices: https://github.com/itinero/routing/wiki/Development-Plan:--Meta-data-on-vertices

Bugfixes:

- Fixed weight matrix calculation issues related to oneways: https://github.com/itinero/routing/issues/116
- Fixed hilbert search sometimes missing closest vertex. Thanks @ironromeo

### 1.1.1 -> 1.2.0

- Fixed maxspeed normalization issue.
- Implemented support for nested relations by allowing multiple passes over relations if requested.
- Implemented support for nested cycle route relations in the default bicycle profile.
- Fixed directed weight matrix issue related to resolved points on oneway segments.

### 1.1.0 -> 1.1.1

- Fixed issue with directed weight matrix being unable to handle new contraction hierarchies.
- Fixed issue with directed edge-based routes not returning single-edge routes. This was a breaking change in behaviour.

### Itinero 1.1.0

This update fixes the issues with the edge-based routing experience in v1.0. On top of that there are some more enhancements for network simplification and several bugfixes related to resolving and restriction handling.

Extra functionality:

- Calculate directed routes, arrive and depart on an edge in a fixed direction.
- An extension method to optimize a network by removing obsolete vertices.
- Added support for simplification of edge geometries.

Behaviour changes:

- Contraction performance improvements.
- RouterDb's are bigger after contraction when using advanced restrictions.
- Performances improvements when loading raw OSM data (thanks @airbreather).
- Allow inserting a non-portable array implementation (thanks @airbreather).
- Fixed bollard nodes restriction handling.
- Added a more advanced network builder with support for single-vertex restrictions.
- By default OSM restrictions are now for motor_vehicles.

Bugfixes:

- Fixed NUnit test runner (thanks @airbreather).
- Fixed issue in hilbert search cause resolve to fail in rare cases.
