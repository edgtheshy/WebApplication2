using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
	public class OrmApiController : Controller
	{
		// GET: OrmApi

		/// <summary>
		/// 获取用户信息,这个就会显示在说明文档里面
		/// </summary>
		/// <returns></returns>
		
		[HttpGet]
		public JsonResult SelectTableBuyin()
		{
			testEntities1 testEntities1Obj = new testEntities1();
			//supplier buyinlObj = new supplier();
			//buyinlObj.供应商全称 = "5";
			//buyinlObj.供应商电话 = "6";

			//kucun obj = new kucun()
			//{
			//	商品名称 = "hahaha",
			//	数量 = 21
			//};

			//testEntities1Obj.kucun.Add(obj);
			//testEntities1Obj.SaveChanges();
			//var obj=from a in testEntities1Obj.kucun
			//string a = "goods";.
			testEntities1Obj.Configuration.ProxyCreationEnabled = false;
			List<buyin> list = testEntities1Obj.buyin.ToList();
			return Json(new { ok = true, my = list }, JsonRequestBehavior.AllowGet);
		}
		/// <summary>
		/// 获取用户信息,这个就会显示在说明文档里面
		/// </summary>
		/// <returns></returns>		
		[HttpGet]
		public JsonResult SelectTableCustomer()
		{
			testEntities1 testEntities1Obj = new testEntities1();
			testEntities1Obj.Configuration.ProxyCreationEnabled = false;
			List<customer> list = testEntities1Obj.customer.ToList();
			return Json(new { ok = true, my = list }, JsonRequestBehavior.AllowGet);
		}

		/**
		 * 查询商品表
		 * */
		[HttpGet]
		public JsonResult SelectTableGoods()
		{
			
			testEntities1 testEntities1Obj = new testEntities1();
			testEntities1Obj.Configuration.ProxyCreationEnabled = false;
			List<goods> list = testEntities1Obj.goods.ToList();
			return Json(list, JsonRequestBehavior.AllowGet);
		}

		/**
		 * 查询库存表
		 * */
		[HttpGet]
		public JsonResult SelectTableKucun()
		{
			testEntities1 testEntities1Obj = new testEntities1();
			testEntities1Obj.Configuration.ProxyCreationEnabled = false;
			List<kucun> list = testEntities1Obj.kucun.ToList();
			return Json(list, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		[Route("hlh")]
		public JsonResult InsertinTableKucun(string[] data)
		{
			kucun obj = new kucun()
			{
				商品名称 = data[0],
				数量 = int.Parse(data[1])
			};
			testEntities1 testEntities1Obj = new testEntities1();
			testEntities1Obj.kucun.Add(obj);
			int res = testEntities1Obj.SaveChanges();
			if (res > 0)
				return Json(new { action=true});
			else
				return Json(new { action = false});
		}

		[HttpPost]
		public JsonResult UpdateTableKucun(string[] data)
		{
			kucun obj = new kucun()
			{
				商品名称 = data[0],
				数量 = int.Parse(data[1])
			};
			testEntities1 testentities1obj = new testEntities1();
			testentities1obj.Entry<kucun>(obj).State = EntityState.Modified;
			int res = testentities1obj.SaveChanges();
			if (res > 0)
				return Json(new { action = true });
			else
				return Json(new { action = false });
		}

		[HttpPost]
		public JsonResult DeleteTableKucun(string data)
		{
			kucun obj = new kucun()
			{
				商品名称 = data,
				
			};
			testEntities1 testentities1obj = new testEntities1();
			testentities1obj.Entry<kucun>(obj).State = EntityState.Deleted;
			int res = testentities1obj.SaveChanges();
			if (res > 0)
				return Json(new { action = true });
			else
				return Json(new { action = false });
		}
	}
}