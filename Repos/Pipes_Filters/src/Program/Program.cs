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
            IPicture pic = p.GetPicture("../../Sequence-1.png");
            FilterGreyscale greyscale = new FilterGreyscale();
            FilterNegative filternegative = new FilterNegative();
            PipeNull pipeNull = new PipeNull();
            FilterSave saveFilter = new FilterSave();

            PipeSerial pipeserial3 = new PipeSerial(saveFilter, pipeNull);

            PipeFork pipeFork3 = new PipeFork(pipeNull, pipeserial3);

            PipeSerial pipeserial2 = new PipeSerial(filternegative, pipeFork3);

            PipeFork pipeFork2 = new PipeFork(pipeserial2, pipeserial3);

            PipeSerial pipeSerial = new PipeSerial(greyscale, pipeFork2);

            PipeFork pipeFork1 = new PipeFork(pipeSerial, pipeserial3);


            pipeFork1.Send(pic);
        }
    }
}
