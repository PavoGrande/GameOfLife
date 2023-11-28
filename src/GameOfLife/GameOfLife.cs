namespace GameOfLife
{
    public class LifeSimulation
    {
        private readonly bool[,] _cells;
        private readonly int _height;
        private readonly int _width;

        /// <summary>
        ///     Initializes a new Game of Life.
        /// </summary>
        /// <param name="height">height of the cell field.</param>
        /// <param name="width">width of the cell field.</param>
        public LifeSimulation(int height, int width)
        {
            _height = height;
            _width = width;
            _cells = new bool[height, width];
            GenerateField();
        }

        /// <summary>
        ///     Advances the game by one generation and prints the current state to console.
        /// </summary>
        public void DrawAndGrow()
        {
            DrawGame();
            Grow();
        }

        /// <summary>
        ///     Advances the game by one generation according to GoL's ruleset.
        /// </summary>
        private void Grow()
        {
            for (var i = 0; i < _height; i++)
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

        /// <summary>
        ///     Checks how many alive neighbors are in the vicinity of a cell.
        /// </summary>
        /// <param name="x">X-coordinate of the cell.</param>
        /// <param name="y">Y-coordinate of the cell.</param>
        /// <returns>The number of alive neighbors.</returns>
        private int GetNeighbors(int x, int y)
        {
            var numOfAliveNeighbors = 0;

            for (var i = x - 1; i < x + 2; i++)
            for (var j = y - 1; j < y + 2; j++)
            {
                if (!(i < 0 || j < 0 || i >= _height || j >= _width))
                {
                    if (_cells[i, j])
                    {
                        numOfAliveNeighbors++;
                    }
                }
            }
            return numOfAliveNeighbors;
        }

        /// <summary>
        ///     Draws the game to the console.
        /// </summary>
        private void DrawGame()
        {
            for (var i = 0; i < _height; i++)
            for (var j = 0; j < _width; j++)
            {
                Console.Write(_cells[i, j] ? "x" : " ");
                if (j == _width - 1) Console.WriteLine("\r");
            }

            Console.SetCursorPosition(0, Console.WindowTop);
        }

        /// <summary>
        ///     Initializes the field with random boolean values.
        /// </summary>
        private void GenerateField()
        {
            var generator = new Random();
            for (var i = 0; i < _height; i++)
            for (var j = 0; j < _width; j++)
            {
                var number = generator.Next(2);
                _cells[i, j] = number != 0;
            }
        }
    }
}