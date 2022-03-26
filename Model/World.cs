using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class World
    {
        private static Random rnd = new Random();
        private Tile[,] tiles;
        private List<TerrainType> allTerrainTypes = Enum.GetValues(typeof(TerrainType)).Cast<TerrainType>().ToList();

        public int Columns
        {
            get { return tiles.GetLength(0); }
        
        }

        public int Rows
        {
            get { return tiles.GetLength(1); }

        }

        public Tile getTile(int column, int row)
        {
            return tiles[column, row];
        }


        public World(int columns, int rows, int pixelSize)
        {
            tiles = new Tile[columns, rows];
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    tiles[x, y] = new Tile(x, y, getRandomTerrain());
                }
            }
        }

        private TerrainType getRandomTerrain()
        {
            return allTerrainTypes[rnd.Next(allTerrainTypes.Count)];

        }
    }
}
