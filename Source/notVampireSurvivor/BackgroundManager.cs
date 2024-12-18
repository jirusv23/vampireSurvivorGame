using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace notVampireSurvivor
{
    public class BackgroundManager
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly Texture2D _backgroundTexture;
        private readonly int _screenWidth;
        private readonly int _screenHeight;

        public BackgroundManager(SpriteBatch spriteBatch, Texture2D backgroundTexture, int screenWidth, int screenHeight)
        {
            _spriteBatch = spriteBatch;
            _backgroundTexture = backgroundTexture;
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
        }

        public void Draw(Vector2 worldPosition)
        {
            Vector2 backgroundOffset = new Vector2(
                worldPosition.X % _backgroundTexture.Width,
                worldPosition.Y % _backgroundTexture.Height
            );

            int tilesX = (_screenWidth / _backgroundTexture.Width) + 2;
            int tilesY = (_screenHeight / _backgroundTexture.Height) + 2;

            for (int y = -1; y < tilesY; y++)
            {
                for (int x = -1; x < tilesX; x++)
                {
                    Vector2 position = new Vector2(
                        (x * _backgroundTexture.Width) - backgroundOffset.X,
                        (y * _backgroundTexture.Height) - backgroundOffset.Y
                    );

                    _spriteBatch.Draw(_backgroundTexture, position, Color.White);
                }
            }
        }
    }
}
