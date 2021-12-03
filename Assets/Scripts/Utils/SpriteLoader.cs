using UnityEngine;

public class SpriteLoader
{
    private static Cache<Sprite> spriteCache = new Cache<Sprite>();

    public static Sprite load(string resourcePath)
    {
        Sprite sprite = spriteCache.get(resourcePath);
        if (sprite != null)
        {
            return sprite;
        }
        else
        {
            sprite = Resources.Load<Sprite>(resourcePath);
            spriteCache.put(resourcePath, sprite);
            return sprite;
        }
    }
}
