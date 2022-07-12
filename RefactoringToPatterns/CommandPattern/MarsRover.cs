using System.Collections.Generic;

namespace RefactoringToPatterns.CommandPattern
{
    public class MarsRover
    {
        public int _x;
        public int _y;
        private char _direction;
        private readonly string _availableDirections = "NESW";
        public readonly string[] _obstacles;
        public bool _obstacleFound;
        private readonly MoveNorthHandler _moveNorthHandler;
        private readonly MoveWestHandler _moveWestHandler;
        private readonly MoveSouthHandler _moveSouthHandler;
        private readonly MoveEastHandler _moveEastHandler;
        private readonly Dictionary<char, IMoveHandler> _movements = new Dictionary<char, IMoveHandler>();

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            _x = x;
            _y = y;
            _direction = direction;
            _obstacles = obstacles;
            _moveNorthHandler = new MoveNorthHandler(this);
            _moveWestHandler = new MoveWestHandler(this);
            _moveSouthHandler = new MoveSouthHandler(this);
            _moveEastHandler = new MoveEastHandler(this);
            _movements.Add('E', _moveEastHandler);
            _movements.Add('W', _moveWestHandler);
            _movements.Add('N', _moveNorthHandler);
            _movements.Add('S', _moveSouthHandler);

        }
        
        public string GetState()
        {
            return !_obstacleFound ? $"{_x}:{_y}:{_direction}" : $"O:{_x}:{_y}:{_direction}";
        }

        public void Execute(string commands)
        {
            foreach(char command in commands)
            {
                if (command == 'M')
                {
                    IMoveHandler moveHandler = _movements[_direction];
                    moveHandler.Move();
                }
                else if(command == 'L')
                {
                    // get new direction
                    var currentDirectionPosition = _availableDirections.IndexOf(_direction);
                    if (currentDirectionPosition != 0)
                    {
                        _direction = _availableDirections[currentDirectionPosition-1];
                    }
                    else
                    {
                        _direction = _availableDirections[3];
                    }
                } else if (command == 'R')
                {
                    // get new direction
                    var currentDirectionPosition = _availableDirections.IndexOf(_direction);
                    if (currentDirectionPosition != 3)
                    {
                        _direction = _availableDirections[currentDirectionPosition+1];
                    }
                    else
                    {
                        _direction = _availableDirections[0];
                    }
                }
            }
        }
    }
}