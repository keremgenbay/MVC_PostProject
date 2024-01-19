using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class MetaController : Controller
    {
        MetaBLL metabll = new MetaBLL();
        // GET: Admin/Meta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddMeta()
        {
            MetaDTO dto = new MetaDTO();
            return View(dto);
        }

        [HttpPost]
        public ActionResult AddMeta(MetaDTO model)
        {
            if (ModelState.IsValid)
            {
                if (metabll.AddMeta(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.ProcessState = General.Messages.GeneralError;
                }
            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }

            MetaDTO newmodel = new MetaDTO();
            return View(newmodel);
        }

        public ActionResult MetaList()
        {
            List<MetaDTO> model = new List<MetaDTO>();
            model = metabll.GetMetaData();
            return View(model);
        }

        public ActionResult UpdateMeta(int ID)
        {
            MetaDTO model= new MetaDTO();
            model = metabll.GetMetaWithID(ID);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateMeta(MetaDTO model)
        {
            if(ModelState.IsValid)
            {
                if(metabll.UpdateMeta(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                }
                else
                {
                    ViewBag.ProcessState=General.Messages.GeneralError;
                }
            }
            else
            {
                ViewBag.ProcessState= General.Messages.EmptyArea;
            }
            return View(model);
        }
    }
}