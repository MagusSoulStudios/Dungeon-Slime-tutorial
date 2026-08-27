using System.Threading.Tasks.Dataflow;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;

namespace DungeonSlime;

public class Game1 : Core
{
    // define the slime sprite
    private Sprite _slime;
    //defines the bat sprite
    private Sprite _bat;

    public Game1() : base("Dungeon Slime", 1280, 720, false)
    {

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        base.Initialize();
    }

    protected override void LoadContent()
    {
        TextureAtlas atlas = TextureAtlas.FromFile(Content, "images/atlas-definitions.xml");

        // retrieve the slime region from the atlas.
        _slime = atlas.CreateSprite("slime");

        // retrieve the bat region from the atlas.
        _bat = atlas.CreateSprite("bat");

        //Scale the sprites to 4x
        _slime.Scale = Vector2.One * 4f;
        _bat.Scale = Vector2.One * 4f;

           base.LoadContent();

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

        // TODO: Add your drawing code here

        // Begin the sprite batch to prepare for render.
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
  
        // Draw the slime sprite
        _slime.Draw(SpriteBatch, Vector2.Zero);

        // Draw the bat sprite
        _bat.Draw(SpriteBatch, new Vector2(_slime.Width + 10, 0));

        // Always end the sprite batch when finished.
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
