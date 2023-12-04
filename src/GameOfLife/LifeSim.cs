namespace GameOfLife
{
    /// <summary>
    ///     Game of life simulation.
    /// </summary>
    public class LifeSim
    {
        private readonly bool[,] _cells;
        private readonly int _height;
        private readonly int _width;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LifeSim"/> class.
        /// </summary>
        /// <param name="height">The height of the board.</param>
        /// <param name="width">The width of the board.</param>
        public LifeSim(int height, int width)
        {
            _height = height;
            _width = width;
            _cells = new bool[height, width];

            GenerateBoard();
        }

        public void DrawAndGrow()
        {
            DrawGame();
            Grow();
        }

        private void Grow()
        {
            for (var i = 0; i < _height; i++)
            {
                for (var j = 0; j < _width; j++)
                {
                    var numOfAliveNeighbors = GetNeighbors(i, j);

                    if (_cells[i, j])
                    {
                        if (numOfAliveNeighbors < 2)
                        {
                            _cells[i, j] = false;
                        }

                        if (numOfAliveNeighbors > 3)
                        {
                            _cells[i, j] = false;
                        }
                    }
                    else
                    {
                        if (numOfAliveNeighbors == 3)
                        {
                            _cells[i, j] = true;
                        }
                    }
                }
            }
        }

        private int GetNeighbors(int x, int y)
        {
            var aliveNeighbors = 0;

            for (var i = x - 1; i < x + 2; i++)
            {
                for (var j = y - 1; j < y + 2; j++)
                {
                    if (!(i < 0 || j < 0 || i >= _height || j >= _width))
                    {
                        if (_cells[i, j])
                        {
                            aliveNeighbors++;
                        }
                    }
                }
            }

            return aliveNeighbors;
        }

        private void DrawGame()
        {
            for (var i = 0; i < _height; i++)
            {
                for (var j = 0; j < _width; j++)
                {
                    Console.Write(_cells[i, j] ? "*" : " ");

                    if (j == _width - 1)
                    {
                        Console.WriteLine("\r");
                    }
                }
            }

            Console.SetCursorPosition(0, Console.WindowTop);
        }

        private void GenerateBoard()
        {
            var random = new Random();

            for (var i = 0; i < _height; i++)
            {
                for (var j = 0; j < _width; j++)
                {
                    var value = random.Next(2);
                    _cells[i, j] = value != 0;
                }
            }
        }
    }
}