using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace mtts;

public class App : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SpriteFont font;
    private int v = 0;
    private RNG rng;
    private Texture2D tex;
    private Player pl;
    private Camera cam;
    private MouseState mouse_pos;

    public App()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.IsFullScreen = true;
        _graphics.ApplyChanges();
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        rng = new RNG(123);
        cam = new Camera(
            new Vector2(0, 50),
            new Vector2(
                _graphics.PreferredBackBufferWidth,
                _graphics.PreferredBackBufferHeight
            )
        );
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        font = Content.Load<SpriteFont>("Fonts/Text");
        tex = Content.Load<Texture2D>("Sprites/Player");
        pl = new Player(tex, new Vector2(0, 0));
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        mouse_pos = Mouse.GetState();
        pl.Update(gameTime);

        v += 10;
        v %= 1000;
        cam.Update(pl.position, gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(20, 20, 20));
        _spriteBatch.Begin(transformMatrix: cam.transform);
        _spriteBatch.DrawString(
            font, "X: " + mouse_pos.X + " Y: " + mouse_pos.Y, new Vector2(100, 50), Color.White
        );
        _spriteBatch.DrawString(
            font, rng.Sample(Math.Abs(v)).ToString(), new Vector2(100, 150), Color.White
        );
        _spriteBatch.Draw(pl.spritesheet, pl.position, pl.Frame, Color.White);
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
