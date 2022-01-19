using System;
using Raylib_cs;

namespace kolisioner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initiera grafikmotorn
            Raylib.InitWindow(800, 600, "Mitt Raylib fönster");
            Raylib.SetTargetFPS(60);

             //några variabler
           int hastighet = 2;
           Random generator = new Random();
           int poäng = 0;

            
            /* Skapa objekt */
           // Skapa en spelare och en fiende
           Rectangle spelare = new Rectangle(100, 100, 50, 50);
           Rectangle fiende = new Rectangle(generator.Next(400,720),generator.Next(0,520),80, 80);

          

            // Animationsloopen
            while (!Raylib.WindowShouldClose())
            {
                /* Rita ut grafiken */
                // Börja rita
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.DARKBLUE);

                // Rita ut objekt
                Raylib.DrawRectangleRec(fiende,Color.RED);
                Raylib.DrawRectangleRec(spelare,Color.BLUE);

                //visa poängen
                Raylib.DrawText ($"poäng {poäng}", 200,100,50,Color.GOLD);

                //upptäcka kollision
                if (Raylib.CheckCollisionRecs(spelare,fiende))
                {
                    poäng ++;
                    
                    fiende.x= generator.Next(400,720);
                    fiende.y= generator.Next(0,520);
                }

                // Ritat ut på fönstret
                Raylib.EndDrawing();

                /* Interaktion med användare */
                //lyssna på tangenter
                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    spelare.x += hastighet;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                {
                    spelare.x -= hastighet;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                {
                    spelare.y += hastighet;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                {
                    spelare.y -= hastighet;
                }
            }
        }
    }
}
