using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EFCore.Oracle.MES;
using EFCore.Web.ViewModel;
using DataWebApi.Models;

namespace DataWebApi.Controllers
{
    /*
     * 准备工作
     * 1、EF引用并设置连接串
     * 2、Jwt引用
     * 3.Attribute特性用来过滤、校验
     * 4.每个控制器要做跨域处理
     * 5.为Action编写ViewModel用来检验提交的数据合法性
     * 6.为返回的结果编写一个ResponseData处理统一返回的数据
     */ 
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<OutputViewModel>> Get()
        {
            //var list = _service.GetAll();
            DateTime period_start, period_end;

            DateTime.TryParse("2020-08-08", out period_start);
            DateTime.TryParse("2020-08-10", out period_end);
            using (var _context = new EFCore.Oracle.MES.OracleDbContext())
            {
                var list = _context.V_OEE_Interfaces.Select(v => new OEEViewModel
                {
                    ProductionLine = v.ProductionLine,
                    OPStation = v.OPStation,
                    OPDate = v.OPDate,
                    TEEP = v.TEEP,
                    OEE = v.OEE,
                    Availability = v.Availability,
                    Performance = v.Performance,
                    QualityRate = v.QualityRate
                })
                .Where(m => m.OPStation == "E1301900")
                .ToList();

                var listOutput = _context.V_Output_Interfaces.Select(v => new EFCore.Web.ViewModel.OutputViewModel
                {
                    Date = v.Date,
                    Name = v.Name,
                    PN = v.PN,
                    Shift = v.Shift,
                    Total_Parts = v.Total_Parts,
                    Good_Parts = v.Good_Parts,
                    Fail_Parts = v.Fail_Parts,
                    Good_Parts_Ratio = v.Good_Parts_Ratio,
                    Fail_Parts_Ratio = v.Fail_Parts_Ratio,
                    Period_Start = v.Period_Start,
                    Period_End = v.Period_End
                })
                .Where(m => m.Name == "E1301900")
                .Where(n => n.Period_Start >= period_start)
                .Where(x => x.Period_End <= period_end)
                .Where(y => y.Shift == 27712)
                .ToList();

                return Ok(new BaseResultModel()
                {
                    Code = 200,
                    Result=listOutput,
                    Message=null,
                    ReturnStatus=ReturnStatus.Success
                });
            }
        }




    }
}