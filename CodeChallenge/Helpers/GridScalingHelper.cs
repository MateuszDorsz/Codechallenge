using System;
using System.Windows;

namespace CodeChallenge.Helpers
{
    class GridScalingHelper
    {
        private static GridScalingHelper _instance;
        private static readonly object _lock = new object();

        public static GridScalingHelper GetInstance()
        {
            if(_instance == null)
            {
                lock(_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new GridScalingHelper();
                    }
                }
            }
            return _instance;
        }

        private GridScalingHelper() { }

        private double _xMid;
        private double _yMid;
        private double _scale;

        public void SetScaling(double gridWidth, double gridHeight, double maxFigureDimension)
        {
            _xMid = gridWidth / 2;
            _yMid = gridHeight / 2;
            var smallerDimension = Math.Min(gridWidth, gridHeight);
            var scaleBase = smallerDimension / 2;
            _scale = scaleBase / (2 * maxFigureDimension);
        }

        public Point GetScaledPoint(double X, double Y)
        {
            var x = (_scale * X) + _xMid;
            var y = (-_scale * Y) + _yMid;
            return new Point(x, y);
        }

        public double GetScaledDimension(double dimensionToScale)
        {
            return dimensionToScale * _scale;
        }
    }
}
