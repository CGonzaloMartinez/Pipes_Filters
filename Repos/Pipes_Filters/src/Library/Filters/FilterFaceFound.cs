using System;
using CognitiveCoreUCU;


namespace CompAndDel.Filters
{
    public class FilterFaceFound : IBooleanFilter
    {
        public IPicture picture;
        public IPicture Filter(IPicture image)
        {
            this.picture = image;
            return image;
        }
        public void Persist(IPicture image, string pathToPersist)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image,pathToPersist);
        }
        public bool Evaluate()
        {
            Persist(picture, "facefound.png");
            CognitiveFace cogFace = new CognitiveFace("620e818a46524ceb92628cde08068242",false);
            cogFace.Recognize("facefound.png");

            return cogFace.FaceFound;
        }
    }
}