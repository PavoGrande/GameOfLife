using GameOfLife;

// Constants for the game rules.
const int height = 10;
const int width = 30;
const uint maxRuns = 100;

var runs = 0;

var sim = new LifeSimulation(height, width);

while (runs++ < maxRuns)
{
    sim.DrawAndGrow();

    // Give the user a chance to view the game in a more reasonable speed.
    Thread.Sleep(100);
}