using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BigGreenHead1;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch _spriteBatch;
 
    Texture2D spriteTexture;

    Vector2 spriteLocation = new Vector2(0f, 0f);
    // floating point constant

    private Vector2 SpriteVelocity = new Vector2(1f, .5f);

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        this.Window.Position = new Point(400, 200);
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        spriteTexture = Content.Load<Texture2D>("greenhead");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        // spriteLocation.X += 1f;
        // spriteLocation.Y += 0.5f;

        spriteLocation += SpriteVelocity;
        
        if (spriteLocation.X > graphics.GraphicsDevice.Viewport.Width - spriteTexture.Width || spriteLocation.X < 0)
        {
            SpriteVelocity.X *= -1;
        }
        
        if (spriteLocation.Y > graphics.GraphicsDevice.Viewport.Height - spriteTexture.Height || spriteLocation.Y < 0)
        {
            SpriteVelocity.Y *= -1;
        }
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(spriteTexture, spriteLocation, Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
