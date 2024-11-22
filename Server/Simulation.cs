
using System;
using System.Collections.Generic;

namespace EVE.Game
{
    public class PlanetSimulation
    {
        public List<Planet> Planets { get; private set; }

        public PlanetSimulation()
        {
            Planets = new List<Planet>
            {
                new Planet("Earth", 1000, 500, 1500, 200),
                new Planet("Mars", 800, 600, 900, 300),
                new Planet("Venus", 700, 1000, 800, 150)
            };
        }

        public void RunDailyCycle()
        {
            foreach (var planet in Planets)
            {
                planet.UpdateResources();
            }
        }

        public void DisplayPlanets()
        {
            foreach (var planet in Planets)
            {
                planet.DisplayStatus();
            }
        }
    }
}
