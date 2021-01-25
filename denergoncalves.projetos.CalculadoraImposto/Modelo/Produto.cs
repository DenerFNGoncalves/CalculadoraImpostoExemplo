using System.Collections.Generic;

namespace denergoncalves.projetos.CaluladoraImposto.Modelo
{
    public class Produto
    {
        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public List<Tributo> Tributos { get; set; }


        public Produto(string codigo, string descricao, decimal valor)
        {
            Codigo = codigo;
            Descricao = descricao;
            Valor = valor;

            Tributos = new List<Tributo>();
        }
    }
}
