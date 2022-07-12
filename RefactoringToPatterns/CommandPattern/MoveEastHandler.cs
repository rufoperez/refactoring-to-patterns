using System.Linq;

namespace RefactoringToPatterns.CommandPattern
{
    public class MoveEastHandler
    {
        private MarsRover _marsRover;

        public MoveEastHandler(MarsRover marsRover)
        {
            _marsRover = marsRover;
        }

        public void Move()
        {
            _marsRover._obstacleFound = _marsRover._obstacles.Contains($"{_marsRover._x + 1}:{_marsRover._y}");
            // check if rover reached plateau limit or found an obstacle
            _marsRover._x = _marsRover._x < 9 && !_marsRover._obstacleFound ? _marsRover._x += 1 : _marsRover._x;
        }
    }
}