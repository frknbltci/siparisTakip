using hali.BLL.Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hali.UI.Controllers
{
    public class BaseController : Controller
    {
        protected  EntityService service = new EntityService();
    }
}