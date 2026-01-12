using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using FxResources.System;

namespace BigGreenHead1;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D background;
    Rectangle backgroundRectangle;
    
    private Song song;  
    private BouncingHead head1, head2, head3;
    private BouncingHead[] heads;
    readonly int headCount = 10;

    private Random r = new Random();
    
    
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
        // head1 = new BouncingHead(0,0,1,1);
        // head2 = new BouncingHead(200,200,4,4);
        // head2.DrawingColor = Color.Teal;
        // head3 = new BouncingHead();
        // head3.Velocity = new Vector2(10f, 10f); 
        // head3.DrawingColor = new Color(255, 50, 123);

        // instantiate an array of heads
        heads = new BouncingHead[headCount];
        for (int i = 0; i < headCount; i++)
        {
            heads[i] = new BouncingHead();
            heads[i].Velocity = new Vector2(r.Next(2, 11), r.Next(2, 11));
            int rd = r.Next(200, 256);
            int g = r.Next(0, 256);
            int b = r.Next(150, 256);
            heads[i].DrawingColor = new Color(rd, g, b);
        }
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        // spriteTexture = Content.Load<Texture2D>("greenhead");
        BouncingHead.GraphicsViewport = GraphicsDevice.Viewport;
        BouncingHead.Texture = Content.Load<Texture2D>("greenhead");
        
        background = Content.Load<Texture2D>("sjb");
        backgroundRectangle = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
      
        song = Content.Load<Song>("wakingup");
        MediaPlayer.Play(song);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        // spriteLocation.X += 1f;
        // spriteLocation.Y += 0.5f;

        // spriteLocation += SpriteVelocity;
        //
        // if (spriteLocation.X > graphics.GraphicsDevice.Viewport.Width - spriteTexture.Width || spriteLocation.X < 0)
        // {
        //     SpriteVelocity.X *= -1;
        // }
        //
        // if (spriteLocation.Y > graphics.GraphicsDevice.Viewport.Height - spriteTexture.Height || spriteLocation.Y < 0)
        // {
        //     SpriteVelocity.Y *= -1;
        // }
        // head1.Position += head1.Velocity;
        //
        // if (head1.Position.X > graphics.GraphicsDevice.Viewport.Width - spriteTexture.Width || head1.Position.X < 0)
        // {
        //     head1.Velocity.X = - head1.Velocity.X;
        // }
        //
        // if (head1.Position.Y > graphics.GraphicsDevice.Viewport.Height - spriteTexture.Height || head1.Position.Y < 0)
        // {
        //     head1.Velocity.Y = - head1.Velocity.Y;
        // }
        
        // head1.Update();
        // head2.Update(); 
        // head3.Update();
        
        foreach (BouncingHead head in heads)
        {
            head.Update();
        }
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        // _spriteBatch.Draw(spriteTexture, head1.Position, Color.White);
        _spriteBatch.Draw(background, backgroundRectangle, Color.White);
        foreach (BouncingHead head in heads)
        {
            head.Draw(_spriteBatch);
        }

    _spriteBatch.End();

        base.Draw(gameTime);
    }
}
