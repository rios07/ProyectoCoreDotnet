using System;

namespace FuncionesCore
{
    public class FTiposDeDatos
    {
        
        public static object FromString(string pTipoDeDato)
        {
            switch (pTipoDeDato)
            {
                case "Boolean":
                    {
                        return new Boolean().GetType();
                    }
                case "Date":
                    {
                        return new DateTime().GetType();
                    }
                case "Double":
                    {
                        return new Double().GetType();
                    }
                case "Integer":
                    {
                        return new int().GetType();
                    }
                case "String":
                    {
                        return new String('K',1).GetType();
                    }
                default:
                    {
                        return new DateTime().GetType();
                    }
            }
        }
    }
}
