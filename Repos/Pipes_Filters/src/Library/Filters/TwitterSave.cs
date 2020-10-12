using TwitterUCU;

namespace CompAndDel.Filters
{
    public class TwitterSave : IFilter
    {
        private TwitterImage twitterImage= new TwitterImage("CkovShLMNVCY0STsZlcRUFu99", "6rc35cHCyqFQSy4vIIjKiCYu31qqkBBkSS5BRlqeYCt5r7zO5B", "1396065818-MeBf8ybIXA3FpmldORfBMdmrVJLVgijAXJv3B18", "gNytQjJgLvurJekVU0wmBBkrR1Th40sJmTO8JDhiyUkuy");
    
        /// <summary>
        /// Recibe una imagen y la publica en Twitter.
        /// </summary>
        /// <param name="image">Imagen con el filtro aplicado a publicar.</param>
        /// <returns>Imagen con el filtro aplicado.</returns>
        
       
        public IPicture Filter(IPicture image)
        {
            Persist(image,"twitter.png");
            twitterImage.PublishToTwitter("","twitter.png");
            return image;
        }

        public void Persist(IPicture image, string pathToPersist)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image,pathToPersist);
        }


    }
}
         