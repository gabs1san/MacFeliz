using MacFeliz.Context;

namespace MacFeliz.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public  List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider Services)
        {
            //define uma sessão
            ISession session =
                Services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Obtem um serviço do tipo do nosso contexto
            var context = Services.GetService<AppDbContext>();

            //Obtem ou gera o Ide do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //Atribui o Id do carrinhoId na Sessão
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId,
            };
        }
    }
}
