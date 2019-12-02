using System.Drawing;

namespace Shapes {

    static class GameImages
    {
        public static Image asterImage;
        public static Image shipImage;

        static GameImages()
        {
            asterImage = Image.FromFile(@"..\..\asteroid96.png");
            shipImage = Image.FromFile(@"..\..\ship.png");
        }
    }
}