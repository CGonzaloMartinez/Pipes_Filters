using System;
using CompAndDel.Filters;
using CompAndDel.Pipes;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider p = new PictureProvider();
            IPicture pic = p.GetPicture("../../matrix.png");
            FilterGreyscale greyscale = new FilterGreyscale();
            FilterNegative filternegative = new FilterNegative();
            PipeNull pipeNull = new PipeNull();
            PipeSerial pipeserial2 = new PipeSerial(filternegative, pipeNull);
            PipeSerial pipeSerial = new PipeSerial(greyscale, pipeserial2);
            pipeSerial.Send(pic);
        }
    }
}
