using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CognitiveCoreUCU;
using CompAndDel.Filters;


namespace CompAndDel.Pipes
{
    public class PipeCondicionalFork : IPipe
    {
        IPipe truePipe;
        IPipe falsePipe;
        IBooleanFilter booleanFilter;


        /// <summary>
        /// La cañería recibe una imagen, la clona y envìa la original por una cañeria y la clonada por otra.
        /// </summary>
        /// <param name="tipoFiltro">Tipo de filtro que se debe aplicar sobre la imagen. Se crea un nuevo filtro con los parametros por defecto</param>
        /// <param name="nextPipe">Siguiente cañeria con filtro</param>
        /// <param name="next2Pipe">Siguiente cañeria sin filtro</param>
        public PipeCondicionalFork(IBooleanFilter booleanFilter, IPipe truePipe, IPipe falsePipe) 
        {
            this.truePipe = truePipe;
            this.falsePipe = falsePipe;
            this.booleanFilter = booleanFilter;
        }

        /// <summary>
        /// La cañería recibe una imagen, construye un duplicado de la misma, 
        /// y envía la original por una cañería y el duplicado por otra.
        /// </summary>
        /// <param name="picture">imagen a filtrar y enviar a las siguientes cañerías</param>
        public IPicture Send(IPicture picture)
        {
            if (this.booleanFilter.Evaluate())
            {
                return this.truePipe.Send(picture);
            }
            else
            {
                return this.falsePipe.Send(picture);
            }
        }
    }
}
