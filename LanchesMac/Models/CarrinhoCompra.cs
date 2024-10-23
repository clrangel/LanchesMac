using LanchesMac.Context;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        //---> Retorna um carrinho de compra
        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            //Difine uma sessão
            ISession session = 
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Obtem um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            //Obtem ou gera Id do carrinho - Se não existir, eu crio
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //Atribui o id do carrinho na sessão
            session.SetString("CarrinhoId", carrinhoId);

            //Retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        //---> Adiciona ao carrinho
        public void AdicionarAoCarrinho(Lanche lanche)
        {
            //Verifica se existe um lanche com o Id informado
            var CarrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                s => s.Lanche.Id == lanche.Id &&
                     s.CarrinhoCompraId == CarrinhoCompraId);

            if(CarrinhoCompraItem == null)
            {
                CarrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(CarrinhoCompraItem);
            }
            else
            {
                CarrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
                
        }
    }
}
