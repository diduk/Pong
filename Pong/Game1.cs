//Jelszó : labda ütközés sallárom
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
 Első feladat: A "világ" létrehozásaA dokumentumod alapján már tudod, hogyan kell textúrát betölteni.

feladatod:Deklarálj 3 Rectangle változót: leftPaddle, rightPaddle, és ball.
A LoadContent-ben hozz létre egy egyszerű fehér textúrát (ezt nevezzük "pixel"-nek), amit mindhárom elem kirajzolásához használni fogsz.
A Draw metódusban rajzold ki ezt a három téglalapot a megfelelő helyre.

Tanári segítség a fehér pixelez:
pixel = new Texture2D(GraphicsDevice, 1, 1);pixel.SetData(new[] { Color.White }); Így a Draw-nál a sourceRectangle helyett a cél-téglalapot (ball, leftPaddle stb.) adod meg, és a MonoGame akkorára nyújtja a fehér pixelt, amekkorára akarod.

 színpad : 800 x 480

// A jobb szél lekérdezése:
int jobbSzel = GraphicsDevice.Viewport.Width; 

// Az alja lekérdezése:
int ablakAlja = GraphicsDevice.Viewport.Height;
-------------------------------------------------------
2. Feladat: Az ütők mozgatása
Próbáljuk meg a referenciád alapján életre kelteni a bal oldali ütőt!

A feladatod:
Írd meg az Update metódusba azt a logikát, ami a W billentyűre felfelé, az S billentyűre pedig lefelé mozgatja a leftPaddle-t.

Segítség a logikához:

Kérd le a billentyűzet állapotát: KeyboardState state = Keyboard.GetState();.

Vizsgáld meg a gombot: if (state.IsKeyDown(Keys.W)).

Módosítsd a pozíciót: leftPaddle.Y -= 5; (Mivel a Rectangle.Y egész szám, itt most nem kell a float sebességgel és a deltaTime-mal trükközni, elég egy fix pixelérték az első teszthez).

Ha megírtad és letesztelted, frissítsd a GitHubot, és küldd a linket! Ha elakadsz, másold be ide az Update részedet!
 */

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D pixel;
        Rectangle leftPaddle;
        Rectangle rightPaddle;
        Rectangle ball;
        int ballSpeed = 3;
        int ballDirectionX;// = 1;
        int ballDirectionY;// = 1;
        System.Random random;// = new Random();   


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public void ResetBall()
        {
            ball.X = 400 - 8;
            ball.Y = 240 - 8;
            ballDirectionX = random.Next(0, 2) * 2 - 1;
            ballDirectionY = random.Next(0, 2) * 2 - 1;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            leftPaddle = new Rectangle(5, 240-50, 20, 100);
            rightPaddle = new Rectangle(800-25, 240-50, 20, 100);
            ball = new Rectangle(400-8, 240-8, 16, 16);

            random = new System.Random();

            ResetBall();
 


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ball.X += ballSpeed * ballDirectionX;
            ball.Y += ballSpeed * ballDirectionY;




            // TODO: Add your update logic here

            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.W))
            {
                if (leftPaddle.Y > 5)
                {
                    leftPaddle.Y -= 5;
                }
                else
                {
                    leftPaddle.Y = 0;
                }
            }

            if (state.IsKeyDown(Keys.S))
            {
                if (leftPaddle.Y < GraphicsDevice.Viewport.Height - leftPaddle.Height - 5)
                {
                    leftPaddle.Y += 5;
                }
                else
                {
                    leftPaddle.Y = GraphicsDevice.Viewport.Height - leftPaddle.Height;
                }
            }


            if (state.IsKeyDown(Keys.Up))
            {
                if (rightPaddle.Y > 5)
                {
                    rightPaddle.Y -= 5;
                }
                else
                {
                    rightPaddle.Y = 0;
                }
            }
            if (state.IsKeyDown(Keys.Down))
            {
                if (rightPaddle.Y < GraphicsDevice.Viewport.Height - rightPaddle.Height - 5)
                {
                    rightPaddle.Y += 5;
                }
                else
                {
                    rightPaddle.Y = GraphicsDevice.Viewport.Height - rightPaddle.Height;
                }
            }

            if (ball.Y <= 0 || ball.Y >= GraphicsDevice.Viewport.Height - ball.Height)
            {
                ballDirectionY *= -1;
            }

            if (ball.X <= 0 || ball.X>=GraphicsDevice.Viewport.Width - ball.Width)
            {
                ResetBall();
            }

            if (ball.Intersects(leftPaddle) || ball.Intersects(rightPaddle))
            {
                ballDirectionX *= -1; // Megfordítjuk a vízszintes irányt
            }





            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
           
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //_spriteBatch.Draw(leftPaddle, new Vector2(100,100), Color.White);
            _spriteBatch.Begin();
            _spriteBatch.Draw(pixel, leftPaddle, Color.White);
            _spriteBatch.Draw(pixel, rightPaddle, Color.White);
            _spriteBatch.Draw(pixel, ball, Color.White);

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
