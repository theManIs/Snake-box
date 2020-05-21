using System;
using UnityEngine;

namespace Snake_box
{
    public static partial class DirectionExtensions
    {
        public static Vector3 ToEulerAngles(this Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    return new Vector3(0, -90, 0);
                case Direction.Right:
                    return new Vector3(0, 90, 0);
                case Direction.Up:
                    return new Vector3(0, 0, 0);
                case Direction.Down:
                    return new Vector3(0, 180, 0);
                default:
                    throw new ArgumentException();
            }
        }

        public static Quaternion ToQuaternion(this Direction direction) => Quaternion.Euler(direction.ToEulerAngles());

        public static bool IsOpposite(this Direction dir1, Direction dir2)
        {
            switch (dir1)
            {
                case Direction.None:
                    return false;
                case Direction.Left:
                    return dir2 == Direction.Right;
                case Direction.Right:
                    return dir2 == Direction.Left;
                case Direction.Up:
                    return dir2 == Direction.Down;
                case Direction.Down:
                    return dir2 == Direction.Up;
                default:
                    throw new ArgumentException();
            }
        }
    } 
}
