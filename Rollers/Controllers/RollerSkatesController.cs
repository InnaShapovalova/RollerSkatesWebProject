using Microsoft.AspNetCore.Mvc;
using Rollers.Data.interfaces;
using Rollers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Controllers
{
    [Route("[controller]")]
    public class RollerSkatesController : Controller
    {
        private readonly IAllRollerSkates _allRollerSkates;
        private readonly IRollerSkatesCategory _allCategories;

        public RollerSkatesController(IAllRollerSkates iAllRolerSkates, IRollerSkatesCategory iAllCategories)
        {
            _allRollerSkates = iAllRolerSkates;
            _allCategories = iAllCategories;
        }

        public ViewResult List()
        {
            //RollerSkatesListViewModel obj = new RollerSkatesListViewModel();
            //obj.AllRollerSkates = _allRolerSkates.RollerSkates;
            //obj.rollerSkateCategory = "Roller Skates";
            ViewBag.Title = "Page with roller skates";
            ViewBag.Category = "Some new";
            RollerSkatesListViewModel obj = new RollerSkatesListViewModel();
            obj.allRollerSkates = _allRollerSkates.RollerSkates;
            obj.rollerSkateCategory = "Roller Skates";
            var objRollerSkate = _allRollerSkates.RollerSkates;
            return View(obj);
        }
    }
}
