using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5MVCProject.Controllers;
using Task5MVCProject.Models;

namespace Task5MVCProject.Areas.Admin.Controllers
{
    public class SalesController : BaseController
    {
        IModelRepository<DAL.Models.Manager, Model.Managers.Manager> managerRepository;
        IModelRepository<DAL.Models.Client, Model.Managers.Client> clientRepository;
        IModelRepository<DAL.Models.Product, Model.Managers.Product> productRepository;
        IModelRepository<DAL.Models.SaleInfo, Model.Managers.SaleInfo> saleInfoRepository;

        public SalesController()
        {
            managerRepository = new ManagerRepository();
            clientRepository = new CilentRepository();
            productRepository = new ProductRepository();
            saleInfoRepository = new SaleInfoRepository();
        }

        public ActionResult Index(int page = 1)
        {
            //var list = saleInfoRepository.Items.OrderByDescending(x => x.ID_Sale);
            SaleRowsModel saleRowsModel = new SaleRowsModel();
            //var newManager = managerRepository.GetEntity(new DAL.Models.Manager() { ManagerName = manager });
            //if (newManager != null)
            //{
                var dataM = saleInfoRepository.Items.Select(x => x);

                foreach (var saleInfo in dataM)
                {
                    var newDate = saleInfo.SaleDate;
                    var managerName = managerRepository.GetEntityNameById(saleInfo.ID_Manager.Value);
                    var clientName = clientRepository.GetEntityNameById(saleInfo.ID_Client.Value);
                    var newProduct = productRepository.GetEntityNameById(saleInfo.ID_Product.Value);
                    saleRowsModel.ListRow.Add(new SaleRowModel() { ManagerName = managerName.ManagerName, Date = newDate, ClientName = clientName.ClientName, ProductName = newProduct.ProductName, ProductCost = newProduct.ProductCost });
                }

            //}
            return View(saleRowsModel);
        }

        public ActionResult Edit(string name)
        {

            return View();
        }

    }
}
