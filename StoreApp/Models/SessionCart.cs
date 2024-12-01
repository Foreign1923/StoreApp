using Entitites.Models;
using StoreApp.Infrastructure.Extensions;
using System.Text.Json.Serialization;

namespace StoreApp.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        //session için ekleme silme kaldırma gibi işlemleri yapıcaz
        public ISession? Session { get; set; } 

        public static Cart GetCart(IServiceProvider services)
        {
            ISession? session = services.
                GetRequiredService<IHttpContextAccessor>()
                .HttpContext.Session;
        
        SessionCart cart = session.GetJson<SessionCart>("cart")
                ?? new SessionCart();
            cart.Session = session;
            return cart;

        }
        //anlamadım bu sessionları
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session?.SetJson<SessionCart>("cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session?.Remove("cart");
        }
        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session?.SetJson<SessionCart>("cart", this);
        }
    }
}
