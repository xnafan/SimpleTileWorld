namespace Model
{
    public class Tile
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public TerrainType Terrain { get; set; }

        public Tile(int row, int column, TerrainType terrain)
        {
            this.Row = row;
            this.Column = column;
            this.Terrain = terrain;
        }
    }
}