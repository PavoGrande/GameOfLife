using GameOfLife;

const int height = 10;
const int width = 30;
const uint maxRuns = 100;

var runs = 0;

var sim = new LifeSim(height, width);

while (runs++ < maxRuns)
{
    sim.DrawAndGrow();
    Thread.Sleep(100);
}