using denergoncalves.projetos.CaluladoraImposto.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace denergoncalves.projetos.CaluladoraImposto.Controle
{
    public class ControleProduto
    {
        public void AdicionaTributo(Produto produto, Tributo tributo)
        {
            if (tributo == null || produto == null)
                throw new ArgumentException("Produto e tributo deve ser informado.");

            if (produto.Tributos == null)
                produto.Tributos = new List<Tributo>();

            var index = produto.Tributos.FindIndex(_ => _.Descricao == tributo.Descricao);
            if (index == -1)
                produto.Tributos.Add(tributo);
            else
                produto.Tributos[index] = tributo;

            tributo.Valor = Math.Round(
                produto.Valor * Convert.ToDecimal(tributo.Porcentagem),
                decimals: 2
            );
        }

        public Tributo ObtemTributoPorDescricao(Produto produto, string descricao)
        {
            var tributos = produto.Tributos;
            if (tributos == null || tributos.Count == 0) return null;

            var result = tributos.Find(t => string.Equals(t.Descricao, descricao));
            return result;
        }

        public Tributo RemoveTributo(Produto produto, string descricao)
        {
            var tributo = produto.Tributos.Find(_ => _.Descricao == descricao);
            produto.Tributos.Remove(tributo);

            return tributo;
        }
    }
}
