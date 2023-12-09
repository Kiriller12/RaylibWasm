using System.Runtime.InteropServices.JavaScript;
using Raylib_cs;

namespace RaylibWasm
{
    public partial class Application
    {
        private static Texture2D logo;
        
        /// <summary>
        /// Application entry point
        /// </summary>
        public static void Main()
        {
            Raylib.InitWindow(512, 512, "RaylibWasm");
            Raylib.SetTargetFPS(60);
            
            logo = Raylib.LoadTexture("Resources/raylib_logo.png");
        }

        /// <summary>
        /// Updates frame
        /// </summary>
        [JSExport]
        public static void UpdateFrame()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.RAYWHITE);

            Raylib.DrawFPS(4, 4);
            Raylib.DrawText("All systems operational!", 4, 32, 20, Color.MAROON);
            
            Raylib.DrawTexture(logo, 4, 64, Color.WHITE);

            Raylib.EndDrawing();
        }
    }
}
