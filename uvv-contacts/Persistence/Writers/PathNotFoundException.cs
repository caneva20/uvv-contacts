using System;

namespace caneva20.Persistence.Writers {
    public class PathNotFoundException : Exception {
        public PathNotFoundException(string path) : base($"Path ${path} not found") { }
    }
}
