namespace CompAndDel.Filters
{
    public class FilterSave : IFilter
    {
        
        private int counter = 0;
        /// <summary>
        /// Recibe una imagen y la guarda en un archivo local.
        /// </summary>
        /// <param name="image">Imagen a la que se le va a aplicar el filtro.</param>
        /// <returns>Imagen con el filtro aplicado.</returns>
        public IPicture Filter(IPicture image)
        {
            Persist(image, $"step{counter}.png");
            counter ++;
            return image;
        }

        public void Persist(IPicture image, string pathToPersist)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image,pathToPersist);
        }
    }
}
