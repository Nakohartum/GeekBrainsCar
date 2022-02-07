using UnityEngine;

namespace Racing.Tools
{
    internal static class ResourceLoader
    {
        public static GameObject LoadPrefab(ResourcePath path)
        {
            return Resources.Load<GameObject>(path.Path);
        }

        public static Sprite LoadSprite(ResourcePath path)
        {
            return Resources.Load<Sprite>(path.Path);
        }

        public static TObject LoadObject<TObject>(ResourcePath path) where TObject : Object
        {
            return Resources.Load<TObject>(path.Path);
        }
    }
}