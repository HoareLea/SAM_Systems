﻿
using SAM.Geometry.Planar;

namespace SAM.Geometry.Systems
{
    public interface IDisplaySystemObject<T> : IDisplaySystemObject where T : ISystemGeometry
    {
        T SystemGeometry { get; }
    }

    public interface IDisplaySystemObject
    {
        bool Move(Vector2D vector2D);
    }
}
