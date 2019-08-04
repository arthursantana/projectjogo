using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace TopLevel {
   public class Game1 : Game {
      GraphicsDeviceManager graphics;
      SpriteBatch spriteBatch;

      Scenes.TestScene scene;

      public Game1() {
         graphics = new GraphicsDeviceManager(this);

         Content.RootDirectory = "Content";
         Window.Title = "What's a title?";
         IsFixedTimeStep = false;

         graphics.PreferredBackBufferWidth =  /*640; */GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
         graphics.PreferredBackBufferHeight = /*420; */GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
         graphics.IsFullScreen = true;
         graphics.SynchronizeWithVerticalRetrace = true;
         graphics.ApplyChanges();
      }

      protected override void Initialize() {
         spriteBatch = new SpriteBatch(GraphicsDevice);

         base.Initialize();

         scene = new Scenes.TestScene(this, spriteBatch);
      }

      protected override void LoadContent() {
         Song song = Content.Load<Song>("tomPulante");
         MediaPlayer.Play(song);
      }

      protected override void UnloadContent()
      {
         Content.Unload();
      }

      protected override void Update(GameTime gameTime) {
         if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

         scene.Update(gameTime);

         base.Update(gameTime);
      }

      protected override void Draw(GameTime gameTime) {
         GraphicsDevice.Clear(Color.White);
         spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

         scene.Draw(gameTime);

         spriteBatch.End();
         base.Draw(gameTime);
      }
   }
}
