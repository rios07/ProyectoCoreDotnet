using System.Collections.Generic;

//namespace FuncionesCore
//{
public static class ClaseExt
{
    public static bool EstaVacia<T>(this List<T> ls)
    {
        if (ls.Count == 0) // no se agregó nada
            return true;
        return false;
    }

    public static bool TieneElementos<T>(this List<T> ls)
    {
        if (ls.Count == 0) // no se agregó nada
            return false;
        return true;
    }
}
//}