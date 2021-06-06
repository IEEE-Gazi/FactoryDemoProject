using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OrderDetailManager : EfEntityRepositoryManager<OrderDetail, IOrderDetailDal>, IOrderDetailService
    {
        public OrderDetailManager(IOrderDetailDal orderDetailDal) : base(orderDetailDal)
        {
            
        }
    }
}