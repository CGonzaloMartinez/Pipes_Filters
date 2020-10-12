using System;

namespace CompAndDel
{
    /// <summary>
    /// Un filtro grafico.
    /// </summary>
    /// <remarks>
    /// Un filtro procesa una imagen, creando opcionalmente una nueva imagen.
    /// </remarks>
    public interface IBooleanFilter : IFilter
    {
       bool Evaluate();
    }
}