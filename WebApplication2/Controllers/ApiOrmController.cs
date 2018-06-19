using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ApiOrmController : ApiController
    {

		/// <summary>
		/// 查询商品表信息
		/// </summary>		
		/// <returns>商品表的json串</returns>		
		[HttpGet]
		[Route("SelectGoods")]
		public IHttpActionResult SelectGoods()
		{
			testEntities1 testEntities1Obj = new testEntities1();
			testEntities1Obj.Configuration.ProxyCreationEnabled = false;
			List<goods> list = testEntities1Obj.goods.ToList();
			return Json<List<goods>>(list);
		}

		/// <summary>
		/// 查询某个供应商信息
		/// </summary>		
		/// <param name="SupplierTel">供应商电话</param>
		/// <returns>目标供应商的json串</returns>		
		[HttpGet]
		[Route("SelectOneSupplier")]
		public IHttpActionResult SelectOneGoods(string SupplierTel)
		{
			testEntities1 testEntities1Obj = new testEntities1();
			testEntities1Obj.Configuration.ProxyCreationEnabled = false;
			
			supplier obj=testEntities1Obj.supplier.Find(SupplierTel);
			return Json(obj);
		}

		/// <summary>
		/// 查询客户表信息
		/// </summary>
		/// <returns>客户表的json串</returns>		
		[HttpGet]
		[Route("SelectCustomer")]
		public IHttpActionResult SelectCustomer()
		{			
			testEntities1 testEntities1Obj = new testEntities1();
			testEntities1Obj.Configuration.ProxyCreationEnabled = false;
			List<customer> list = testEntities1Obj.customer.ToList();
			return Json<List<customer>>(list);
		}


		/// <summary>
		/// 查询库存表信息
		/// </summary>
		/// <returns>库存表的json串</returns>		
		[HttpGet]
		[Route("SelectKucun")]
		public IHttpActionResult SelectKucun()
		{
			testEntities1 testEntities1Obj = new testEntities1();
			testEntities1Obj.Configuration.ProxyCreationEnabled = false;
			List<kucun> list = testEntities1Obj.kucun.ToList();
			return Json(list);
		}


		/// <summary>
		/// 插入库存表信息
		/// </summary>
		/// <param name="goodsName">商品名称</param>
		/// <param name="goodsNum">商品数量</param>
		/// <returns>true or false</returns>		
		[HttpGet]
		[Route("InsertTableKucun")]
		public IHttpActionResult InsertinTableKucun(string goodsName,int goodsNum)
		{
			
			kucun obj = new kucun()
			{
				商品名称 = goodsName,
				数量 = goodsNum
			};
			testEntities1 testEntities1Obj = new testEntities1();
			testEntities1Obj.kucun.Add(obj);
			int res = testEntities1Obj.SaveChanges();
			
			if (res > 0)
				return Json(new { action = true });
			else
				return Json(new { action = false });
		}

		/// <summary>
		/// 更新库存表信息
		/// </summary>
		/// <param name="goodsName">商品名称</param>
		/// <param name="goodsNum">商品数量</param>
		/// <returns>true or false</returns>		
		[HttpGet]
		[Route("UpdateTableKucun")]
		public IHttpActionResult UpdateTableKucun(string goodsName,int goodsNum)
		{
			testEntities1 testEntities1Obj = new testEntities1();
			testEntities1Obj.Configuration.ProxyCreationEnabled = false;
			List<kucun> list = testEntities1Obj.kucun.ToList();


			kucun obj1 = testEntities1Obj.kucun.Find(goodsName);
			obj1.数量 = goodsNum;
			//string[] data = new string[2];
			//kucun obj = new kucun()
			//{
			//	商品名称 = goodsName,
			//	数量 = goodsNum
			//};
			//testEntities1Obj.Entry<kucun>(obj).State = EntityState.Modified;
			int res = testEntities1Obj.SaveChanges();			
			if (res > 0)
				return Json(new { action = true });
			else
				return Json(new { action = false });
		}

		[HttpPost]
		[Route("UpdateTableKucun1")]
		public IHttpActionResult UpdateTableKucun1(string goodsName, int goodsNum)
		{
			testEntities1 testEntities1Obj = new testEntities1();
			testEntities1Obj.Configuration.ProxyCreationEnabled = false;
			List<kucun> list = testEntities1Obj.kucun.ToList();


			kucun obj1 = testEntities1Obj.kucun.Find(goodsName);
			obj1.数量 = goodsNum;
			//string[] data = new string[2];
			//kucun obj = new kucun()
			//{
			//	商品名称 = goodsName,
			//	数量 = goodsNum
			//};
			//testEntities1Obj.Entry<kucun>(obj).State = EntityState.Modified;
			int res = testEntities1Obj.SaveChanges();
			if (res > 0)
				return Json(new { action = true });
			else
				return Json(new { action = false });
		}
		/// <summary>
		/// 删除库存表某个信息
		/// </summary>
		/// <param name="goodsName">商品名称</param>
		/// <returns>true or false</returns>	
		[HttpGet]
		[Route("DeleteTableKucun")]
		public IHttpActionResult DeleteTableKucun(string goodsName)
		{
			testEntities1 testEntities1Obj = new testEntities1();
			testEntities1Obj.Configuration.ProxyCreationEnabled = false;
			List<kucun> list = testEntities1Obj.kucun.ToList();

			kucun obj1 = testEntities1Obj.kucun.Find(goodsName);
			//kucun obj = new kucun()
			//{
			//	商品名称 = data				
			//};
			testEntities1Obj.Entry<kucun>(obj1).State = EntityState.Deleted;
			int res = testEntities1Obj.SaveChanges();
			
			if (res > 0)
				return Json(new { action = true });
			else
				return Json(new { action = false });
		}
	}
}
