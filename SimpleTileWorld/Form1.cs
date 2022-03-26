using Model;

namespace SimpleTileWorld
{
    public partial class Form1 : Form
    {

        World world = new World(30, 30, 64);
        Camera camera;
        int tilesize = 64;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Dictionary<TerrainType, Rectangle> tilesetTerrainPositions = new Dictionary<TerrainType, Rectangle>();
            for (int tileTypeCounter = 0; tileTypeCounter < 5; tileTypeCounter++)
            {
                tilesetTerrainPositions[(TerrainType)tileTypeCounter] = new Rectangle(tilesize * tileTypeCounter,0, tilesize, tilesize);
            }

            camera = new Camera(world, getTileset(), tilesetTerrainPositions, tilesize, 20, 15);
            updateInfoLabel();
        }

        private Bitmap getTileset()
        {
            var runnintProgramPath = Directory.GetCurrentDirectory();
            var bitmapPath = Path.Combine(runnintProgramPath, "graphics/tileset_64px.png");
            return new Bitmap(bitmapPath);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            camera.render(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    camera.MoveLeft();
                    break;
                case Keys.Up:
                    camera.MoveUp();
                    break;
                case Keys.Right:
                    camera.MoveRight();
                    break;
                case Keys.Down:
                    camera.MoveDown();
                    break;
            }
            Refresh();
            updateInfoLabel();
        }

        private void updateInfoLabel()
        {
            lblInfo.Text = $"Top left camera tile: {camera.TopLeftTile} rendering {camera.ColumnsToRender} x {camera.RowsToRender} in a {world.Columns}x {world.Rows} world  ";
        }
    }
}