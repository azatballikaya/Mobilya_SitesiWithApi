using AutoMapper;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.EntityFrameworkCore;
using Mobilya.Business.Abstract;
using Mobilya.Business.DTOs.OrderDetailDTOs;
using Mobilya.Business.DTOs.OrderDTOs;
using Mobilya.DataAccess.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly IOrderDetailDal _orderDetailDal;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        private readonly IMapper _mapper;

        public OrderManager(IOrderDal orderDal, IOrderDetailDal orderDetailDal, IMapper mapper, ICartService cartService, ICartItemService cartItemService)
        {
            _orderDal = orderDal;
            _orderDetailDal = orderDetailDal;
            _mapper = mapper;
            _cartService = cartService;
            _cartItemService = cartItemService;
        }

        public void AddOrderDetailToOrder(int quantity,int productId)
        {

            _orderDetailDal.Insert(new OrderDetail
            {
                Quantity = quantity,
                ProductId = productId,
                Price = 0
            });
        }

        public bool CreateOrder(CreateOrderDTO createOrderDTO)
        {
            
          
             var cart=   _cartService.GetCartByUserId(createOrderDTO.UserId);
          
           

            //Iyzico
            //mobilyadunyasi@info.com
            //pass=192837
            Options options = new Options();
            options.ApiKey = "sandbox-Fi57By9fIM73QJwk9GOuMZHX33UxdxWn";
            options.SecretKey = "sandbox-DpL7inCVJAv6V3YD26vKY0nmOdMwMPos";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = "123456789";
            request.Price = cart.CartItems.Sum(x=>x.Product.Price*x.Quantity).ToString().Replace(',','.');
            request.PaidPrice = cart.CartItems.Sum(x => x.Product.Price * x.Quantity).ToString().Replace(',','.');
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = createOrderDTO.FullName;
            paymentCard.CardNumber = createOrderDTO.CardNumber;
            paymentCard.ExpireMonth = createOrderDTO.ExpirationMonth;
            paymentCard.ExpireYear = createOrderDTO.ExpirationYear;
            paymentCard.Cvc = createOrderDTO.Cvv;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = createOrderDTO.FullName.Split(' ')[0];
            buyer.Surname = createOrderDTO.FullName.Split(' ')[1] ?? "";
            buyer.GsmNumber = "+905350000000";
            buyer.Email = "email@email.com";
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = createOrderDTO.Adress;
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = createOrderDTO.Adress;
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = createOrderDTO.Adress;
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = createOrderDTO.FullName;
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = createOrderDTO.Adress;
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;
            foreach (var item in cart.CartItems)
            {
                basketItem= new BasketItem();
                basketItem.Id = item.ProductId.ToString();
                basketItem.Name = item.Product.ProductName;
                basketItem.Category1 = item.Product.Category.CategoryName;
                basketItem.Category2 = "Accessories";
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                basketItem.Price = (item.Product.Price*item.Quantity).ToString().Replace(',','.');
                basketItems.Add(basketItem);
            }
            
            request.BasketItems = basketItems;
          

            Payment payment = Payment.Create(request, options);
            
            if (payment.Status == "success")
            {
                //Order database'e işleniyor
                var order = _orderDal.Insert(new Order
                {
                    Cvv = createOrderDTO.Cvv,
                    CardNumber = createOrderDTO.CardNumber,
                    ExpirationMonth = createOrderDTO.ExpirationMonth,
                    ExpirationYear = createOrderDTO.ExpirationYear,
                    FullName = createOrderDTO.FullName,
                    UserId = createOrderDTO.UserId,
                });
                foreach (var cartItem in cart.CartItems)
                {
                    _orderDetailDal.Insert(new OrderDetail
                    {
                        Quantity = cartItem.Quantity,
                        ProductId = cartItem.ProductId,
                        CreatedDate = DateTime.Now,
                        OrderId = order.Id,
                        Price = Convert.ToDecimal(cartItem.Quantity * cartItem.Product.Price),

                    });
                }
                 _cartItemService.ClearCart(createOrderDTO.UserId);
                return true;
            }
            return false;
            
        }
       
        public void DeleteOrder(int id)
        {
            var order=_orderDal.Get(x=>x.Id==id, x=>x.Include(y=>y.OrderDetails));
           
           
            _orderDal.Delete(order);
        }

        public List<ResultOrderDTO> GetAllOrders()
        {
            var orderList = _orderDal.GetAll(include:x=>x.Include(u=>u.User).Include(y=>y.OrderDetails).ThenInclude(k=>k.Product));
            var dtos=_mapper.Map<List<ResultOrderDTO>>(orderList);
            return dtos;
        }

        public List<ResultOrderDTO> GetOrderByUserId(int userId)
        {
            var orderList = _orderDal.GetAll(filter:x=>x.UserId==userId,include: x => x.Include(z => z.User).Include(y => y.OrderDetails).ThenInclude(k => k.Product));
            var dto = _mapper.Map<List<ResultOrderDTO>>(orderList);
            return dto;
        }
        public ResultOrderDTO GetOrderById(int id)
        {
            var order=_orderDal.Get(x=>x.Id==id,x=>x.Include(z=>z.OrderDetails));
            var dto=_mapper.Map<ResultOrderDTO>(order);
            return dto;
        }

        public void UpdateOrder(UpdateOrderDTO updateOrderDTO)
        {
           var order=_mapper.Map<Order>(updateOrderDTO); 
            _orderDal.Update(order);
        }
    }
}
