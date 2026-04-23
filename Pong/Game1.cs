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


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });

            leftPaddle = new Rectangle(5, 240-50, 20, 100);
            rightPaddle = new Rectangle(800-25, 240-50, 20, 100);
            ball = new Rectangle(400-8, 240-8, 16, 16);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

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
