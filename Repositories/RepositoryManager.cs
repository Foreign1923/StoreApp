using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;//veritabanı bağlantısı bu injectionla oluyor
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;
        public RepositoryManager(IProductRepository repository, RepositoryContext context,
            ICategoryRepository categoryRepository, 
            IOrderRepository orderRepository)
        {
            _repository = repository;
            _context = context;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
        }
        public IProductRepository Product => _repository;

        public ICategoryRepository Category => _categoryRepository;

        public IOrderRepository Order => _orderRepository;

        public void Save()
        {
                _context.SaveChanges();//veritabını kaydediyor burada yanı bir product eklenirse kaydedecek
            }
    }
}
