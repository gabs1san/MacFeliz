namespace MacFeliz.Areas.Admin.ViewModels
{
    public class RelatorioVendasViewModel
    {
        public int TotalPedidos { get; set; }

        public decimal TotalVendas { get; set; }

        public int TotalProdutosVendidos { get; set; }

        public DateTime? DataInicial { get; set; }

        public DateTime? DataFinal { get; set; }
    }
}