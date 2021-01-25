using System;

namespace denergoncalves.projetos.CaluladoraImposto
{
    public static class ICMSHelper
    {
        public static decimal AdicionarICMS(decimal valor, decimal icms)
        {
            if (icms < 0 || icms >= 1) throw new ArgumentException("valor deve ser maior igual a zero e menor que 1");
            if (valor == 0 || icms == 0) return valor;

            var _valor = valor < 0 ? -valor : valor;
            //  valor           =       ( 1 - icms)%
            //  ? (valorIcms)   =       icms % 
            var resultado = (_valor * icms / (1 - icms)) + _valor;

            return (valor < 0) ? -resultado : resultado;
        }
    }
}
