using hali.BLL.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hali.BLL.Repository.Service
{
   public class EntityService
    {
        public EntityService()
        {
            _cargoService = new CargoRepository();
            _marketService = new MarketRepository();
            _orderService = new OrderRepository();
            _orderStatusService = new OrderStatusRepository();
            _roleService = new RoleRepository();
            _userService = new UserRepository();
        }

        private UserRepository _userService;

        public UserRepository UserService
        {
            get { return _userService; }
            set { _userService = value; }
        }


        private RoleRepository _roleService;

        public RoleRepository RoleService
        {
            get { return _roleService; }
            set { _roleService = value; }
        }



        private OrderStatusRepository _orderStatusService;

        public OrderStatusRepository OrderStatusService
        {
            get { return _orderStatusService; }
            set { _orderStatusService = value; }
        }

        private OrderRepository _orderService;

        public OrderRepository OrderService
        {
            get { return _orderService; }
            set { _orderService = value; }
        }

        private MarketRepository _marketService;

        public MarketRepository MarketService
        {
            get { return _marketService; }
            set { _marketService = value; }
        }


        private CargoRepository _cargoService;

        public CargoRepository CargoService
        {
            get { return _cargoService; }
            set { _cargoService = value; }
        }

    }
}
