using System.Drawing;

namespace Shapes {

    static class GameImages
    {
        public static Image asterImage;
        public static Image shipImage;
        public static Image aidImage;

        static GameImages()
        {
            asterImage  = Image.FromFile(@"..\..\asteroid96.png");
            shipImage   = Image.FromFile(@"..\..\ship.png");
            aidImage    = Image.FromFile(@"..\..\aid.png");
        }
    }
}