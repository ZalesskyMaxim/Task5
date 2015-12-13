using DAL.Repository;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5MVCProject.Models;

namespace Task5MVCProject.Areas.Default.Controllers
{
    public class SaleInfoController : Controller
    {
        IModelRepository<DAL.Models.Manager, Model.Managers.Manager> managerRepository;
        IModelRepository<DAL.Models.Client, Model.Managers.Client> clientRepository;
        IModelRepository<DAL.Models.Product, Model.Managers.Product> productRepository;
        IModelRepository<DAL.Models.SaleInfo, Model.Managers.SaleInfo> saleInfoRepository;

        public SaleInfoController()
        {
            managerRepository = new ManagerRepository();
            clientRepository = new CilentRepository();
            productRepository = new ProductRepository();
            saleInfoRepository = new SaleInfoRepository();
        }
        //
        // GET: /Default/SaleInfo/

        public ActionResult Index()
        {
            SaleInfoModel saleInfoModel = new SaleInfoModel();
            saleInfoModel.Managers = managerRepository.Items;
            saleInfoModel.Products = productRepository.Items;
            return View(saleInfoModel);
        }

        public ActionResult GetByFilter(string manager, string product, string date)
        {
            SaleRowsModel saleRowsModel = new SaleRowsModel();
            var newManager = managerRepository.GetEntity(new DAL.Models.Manager() { ManagerName = manager });
            if (newManager != null)
            {
                var dataM = saleInfoRepository.Items.Where(x => x.ID_Manager == newManager.ID_Manager);
                
                foreach (var saleInfo in dataM)
                {
                    var newDate = saleInfo.SaleDate;
                    var managerName = managerRepository.GetEntityNameById(saleInfo.ID_Manager.Value);
                    var clientName = clientRepository.GetEntityNameById(saleInfo.ID_Client.Value);
                    var newProduct = productRepository.GetEntityNameById(saleInfo.ID_Product.Value);
                    saleRowsModel.ListRow.Add(new SaleRowModel(){ ManagerName = managerName.ManagerName, Date = newDate, ClientName = clientName.ClientName, ProductName = newProduct.ProductName, ProductCost = newProduct.ProductCost});
                }

            }
            if (!string.IsNullOrEmpty(product) && !product.Equals("-"))
            {
                saleRowsModel.ListRow = saleRowsModel.ListRow.Where(x => x.ProductName.Equals(product)).ToList();
            }
            if (!string.IsNullOrEmpty(date))
            {
                saleRowsModel.ListRow = saleRowsModel.ListRow.Where(x => x.Date.Contains(date)).ToList();
            }
            return View("~/Areas/Default/Views/Saleinfo/SaleRows.cshtml", saleRowsModel);
        }

        public ActionResult IndexPartial()
        {
            return View();
        }

    }
}
