using DAL.Repository;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5MVCProject.Models;

namespace Task5MVCProject.Areas.Default.Controllers
{
    public class DemoController : Controller
    {
        IModelRepository<DAL.Models.Manager, Model.Managers.Manager> managerRepository;
        IModelRepository<DAL.Models.SaleInfo, Model.Managers.SaleInfo> saleInfoRepository;

        public DemoController()
        {
            managerRepository = new ManagerRepository();
            saleInfoRepository = new SaleInfoRepository();
        }

        public ActionResult Index() 
        {
            List<int> yDataCount = new List<int>();
            var xData = managerRepository.Items.Select(x => x.ManagerName).ToArray();
            foreach(var item in xData)
            {
                var count = saleInfoRepository.Items.Where(x => x.ID_Manager == saleInfoRepository.GetEntityIDByName(item).ID_Manager).Count();
                yDataCount.Add(count);
            }
            var yData = yDataCount.Select(x => new object[] { x }).ToArray();
            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart")
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Bar })
                .SetTitle(new Title { Text = "Sales information" })
                .SetXAxis(new XAxis
                {
                    Categories = xData
                })
                .SetSeries(new Series
                {
                    Name = "Sales count",
                    Data = new Data(yData)
                });

            return View(chart);
        }

    }
}
